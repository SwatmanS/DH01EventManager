using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Xml.Linq;

namespace DH01EventManager
{
    public partial class AddEvent : Window
    {
        public AddEvent()
        {
            InitializeComponent();

            //decides which image to use for the login/logout image
            UpdateLoginImage();

            //displays the list of items
            StaffList.ItemsSource = Settings.staffList;
            EquipmentList.ItemsSource = Settings.equipmentList;
            LocationList.ItemsSource = Settings.locationList;
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
                //makes lists of the staff and equipment 
                List<string> checkedStaff = GetCheckedItems(StaffList);
                List<string> checkedEquipment = GetCheckedItems(EquipmentList);
                List<string> checkedLocation = GetCheckedItems(LocationList);

                Random rng = new Random();
                int rand1 = rng.Next(10,100);
                DateTime startDate = DateTime.Parse(eventDateBox.Text);
                String startTime = eventStartTimeBox.Text;
                String endTime = eventEndTimeBox.Text;

                //endTime = endTime.Subtract(startTime);
                int dur = EventObject.parseDuration(startTime, endTime);

                startDate = EventObject.parseStartDate(startDate,startTime);

                //EventObject nEvent = new EventObject(rand1, eventTitleBox.Text, checkedLocation, startTime, dur, checkedStaff, checkedEquipment);

                /*to future jasmine: need to make checkedstaff, checkedequipmnet, and checkedlocation into objects. need database search method
                 * once obtained will need to use location search on location and save as locationobject which can be passed into the construct
                 * equipment and staff will require a loop (foreach?) that will convert each item in list to an object using the db search method and will save
                 * the result into the relevant object list which can then be passed into the constructor
                 * once this is done, the addevent method will hopefully work. should be testable by checking the events page
                 * id is currently random, could possibly make a list of events, get last id in list and add 1
                 * currently no estimated turn out functionality have to standby and wait to see if that is the case
                 * but we would do a similar thing hopefully of adding the turn out to the upcoming events table w a new id and corresponding event id.
                 * to get the newid would probs do a similar thing of making a list of ids and outputting them.
                 * maybe make new methods to just return ids.
                */
                //prints off the add event form which would go into the database
                MessageBox.Show(
                    "Event Title:\n" + eventTitleBox.Text +
                    "\n\nEvent Date:\n" + eventDateBox.Text +
                    "\n\nEvent Start Time:\n" + eventStartTimeBox.Text +
                    "\n\nEvent End Time:\n" + eventEndTimeBox.Text +
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