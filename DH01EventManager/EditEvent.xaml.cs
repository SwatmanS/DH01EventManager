using System;
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
            SetEvents(Settings.eventIndex);
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

        private void SetEvents(int index)
        {
            //depending on index show a different event from the class

            EventObject edit = DBAbstractionLayer.getEventByID(1);

            DateTime datetime = edit.getEventDate();


            eventTitleBox.Text = edit.getEventName();
            eventDateBox.Text = datetime.ToString();
            //eventStartTimeBox.Text = edit.getStartTime();
            //eventEndTimeBox.Text = edit.getEndTime();
            eventCapacityBox.Text = "40";
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
                eventEndTimeBox.Text != "" && eventCapacityBox.Text != "" && eventTurnoutBox.Text != "")
            {
                //makes lists of the staff and equipment 
                List<string> checkedStaff = GetCheckedItems(StaffList);
                List<string> checkedEquipment = GetCheckedItems(EquipmentList);
                List<string> checkedLocation = GetCheckedItems(LocationList);

                //prints off the add event form which would go into the database
                MessageBox.Show(
                    "Event Title:\n" + eventTitleBox.Text +
                    "\n\nEvent Date:\n" + eventDateBox.Text +
                    "\n\nEvent Start Time:\n" + eventStartTimeBox.Text +
                    "\n\nEvent End Time:\n" + eventEndTimeBox.Text +
                    "\n\nEvent Capacity:\n" + eventCapacityBox.Text +
                    "\n\nEvent Expected Turnout:\n" + eventTurnoutBox.Text +
                    "\n\nChecked staff:\n" + string.Join(", ", checkedStaff) +
                    "\n\nChecked Equipment:\n" + string.Join(", ", checkedEquipment) +
                    "\n\nEvent Location:\n" + string.Join(", ", checkedLocation));

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