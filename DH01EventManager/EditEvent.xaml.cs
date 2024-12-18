﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DH01EventManager
{
    /// <summary>
    /// Interaction logic for EditEvent.xaml
    /// </summary>
    public partial class EditEvent : Window
    {
        public EditEvent()
        {
            InitializeComponent();

            //decides which image to use for the login/logout image
            UpdateLoginImage();

            //displays the list of items
            StaffList.ItemsSource = Settings.staffList;
            EquipmentList.ItemsSource = Settings.equipmentList;
            LocationList.ItemsSource = Settings.locationList;

            //sets form variables as the events fron the database
            SetEvents();
        }

        private void UpdateLoginImage()
        {
            //decides on the image that will be shown depending on the state of isloggedin
            string imagePath = Settings.loggedIn
        ? "pack://application:,,,/images/Logout.png"
        : "pack://application:,,,/images/Login.png";

            //changes image source to the corret image path
            LoginLogoutImage.Source = new BitmapImage(new Uri(imagePath));
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            //close the current window
            this.Close();
        }

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            //hides current window and goes to the home page 
            MainWindow l_page = new();
            this.Hide();
            l_page.ShowDialog();
            this.Show();
        }

        private void GoToEvents_Click(object sender, RoutedEventArgs e)
        {
            //hides current window and goes to the events page
            Events l_page = new();
            this.Hide();
            l_page.ShowDialog();
            this.Show();
        }

        private void GoToLogin_Click(object sender, RoutedEventArgs e)
        {
            //hides current window and goes to the login page 
            Login l_page = new();
            this.Hide();
            l_page.ShowDialog();
            this.Show();
        }

        private void SetEvents()
        {
            //depending on index show a different event from the class

            // Retrieve the stored event ID
            int eventID = Settings.eventIndex;

            EventObject edit = DBAbstractionLayer.getEventByID(eventID);

            DateTime datetime = edit.getEventDate();

            eventTitleBox.Text = edit.getEventName();
            eventDateBox.Text = datetime.ToString();
            eventStartTimeBox.Text = (edit.getStartTime()).ToString();
            eventEndTimeBox.Text = (edit.getEndTime()).ToString();
            eventTurnoutBox.Text = "120";
            LocationObject loc = edit.getEventLocation();


            currentStaff.Text = "Current Staff:\n" + edit.staffString();
            currentEquipment.Text = "Current Equipment:\n" + edit.equipmentString();
            currentLocation.Text = "Current Location:\n" + loc.getLocationName();
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            //makes sure the input can only be numbers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public List<string> GetCheckedItems(ListBox listOfStuff)
        {
            //creates a list for checked items to go into
            List<string> checkedList = new List<string>();

            //loops through the item list
            foreach (var item in listOfStuff.Items)
            {
                //gets the name of the current item and makes sure its not null
                var name = listOfStuff.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                if (name != null)
                {
                    //gets the checkbox linked to the item and if its checked and not null
                    var checkBox = FindCheckbox<CheckBox>(name);
                    if (checkBox != null && checkBox.IsChecked == true)
                    {
                        //adds item to list
                        checkedList.Add(item.ToString());
                    }
                }
            }
            return checkedList;
        }

        public void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var currentBox = sender as CheckBox;

            // Uncheck all other checkboxes in the ListBox
            foreach (var item in LocationList.Items)
            {
                // Get the ListBoxItem container
                var name = LocationList.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                if (name != null)
                {
                    // Find the CheckBox inside the ListBoxItem container
                    var checkBox = FindCheckbox<CheckBox>(name);
                    if (checkBox != null && checkBox != currentBox)
                    {
                        checkBox.IsChecked = false; // Uncheck other checkboxes
                    }
                }
            }
        }

        //method to find the checkbox linked with the name in the item list
        public Box FindCheckbox<Box>(DependencyObject list) where Box : DependencyObject
        {
            //loops through for the length of the listbox using VisualTreeHelper to count the 'children' in the list
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(list); i++)
            {
                //sets the name of the chore in the list to a varable using VisualTreeHelper
                var CName = VisualTreeHelper.GetChild(list, i);
                if (CName != null && CName is Box) //checks not null and is a checkbox
                {
                    return (Box)CName;
                }
                //sets the checkbox itself as a variable
                var Ticked = FindCheckbox<Box>(CName);
                if (Ticked != null)
                {
                    //returns state of the box
                    return Ticked;
                }
            }
            return null;
        }

        private void SubmitAddEvent_Click(object sender, RoutedEventArgs e)
        {
            //check that all the boxes are filled in before this
            if (eventTitleBox.Text != "" && eventDateBox.Text != "" && eventStartTimeBox.Text != "" &&
                eventEndTimeBox.Text != "" && eventTurnoutBox.Text != "")
            {
                int eventID = Settings.eventIndex;
                //makes lists of the staff and equipment 
                List<String> checkedStaff = GetCheckedItems(StaffList);
                List<String> checkedEquipment = GetCheckedItems(EquipmentList);
                List<String> checkedLocation = GetCheckedItems(LocationList);

                //dummy objects to access methods
                StaffObject dummy = new StaffObject(0, "a", "a", "a", "a");
                LocationObject dummy1 = new LocationObject(0, "a", "a", 0);
                EquipmentObject dummy2 = new EquipmentObject(0, "a", "a");

                //uses listToObject to make a list of staffObjects obtained by names stored in checkedStaff
                List<StaffObject> staffOb = new List<StaffObject>();
                List<EquipmentObject> equOb = new List<EquipmentObject>();

                staffOb = dummy.objListBuilder(checkedStaff, staffOb);
                LocationObject locOb = dummy1.objListBuilder(checkedLocation);
                equOb = dummy2.objListBuilder(checkedEquipment, equOb);

                String dateString = String.Concat(eventDateBox.Text + " " + eventStartTimeBox.Text);

                DateTime startDate = Convert.ToDateTime(dateString);

                //lists for eventID and upcomingEventID, saves the final ID in list
                List<Int32> evID = new List<Int32>();
                evID = DBAbstractionLayer.getAllEventID();
                Int32 lastEvID = evID.Last();
                List<Int32> upEvID = new List<Int32>();
                upEvID = DBAbstractionLayer.getAllUpEventID();
                Int32 lastUpEvID = upEvID.Last();

                DateTime date = DateTime.Parse(eventDateBox.Text);
                Int32 est = Int32.Parse(eventTurnoutBox.Text);

                //creates duration and startDate varianbles
                int dur = EventObject.parseDuration(eventStartTimeBox.Text, eventEndTimeBox.Text);


                DateTime endTime = DateTime.Parse(eventEndTimeBox.Text);
                TimeSpan difference = endTime.Subtract(startDate);
                //Int32 dur = (int)difference.TotalMinutes;

                EventObject nEvent = new EventObject(eventID, eventTitleBox.Text, locOb, startDate, dur, staffOb, equOb);
                UpcomingEvent uEvent = new UpcomingEvent(nEvent, est);

                DBAbstractionLayer.updateEvent(nEvent);

                MessageBox.Show("Event Updated: \n" + nEvent.toString(), "Edit Event");

                //close the current window
                this.Close();
            }
            else
            {
                //if all boxes are not filled in show a message
                MessageBox.Show("please fill in all the boxes");
            }

        }
    }
}