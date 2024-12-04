using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window
    {
        //should be taken from user class
        public static bool isLoggedIn = true;

        public AddEvent()
        {
            InitializeComponent();
            //decides which image to use for the login/logout image
            UpdateLoginImage();

            string[] choreList = ["Do Dishes", "Fold and Put Away Clothes", "Clean Bathroom", "Cook Tea", "Clean Kitchen", "Make Bed"];
            ItemsList.ItemsSource = choreList;

        }

        private void UpdateLoginImage()
        {
            //decides on the image that will be shown depending on the state of isloggedin
            string imagePath = isLoggedIn
        ? "pack://application:,,,/images/Logout.png"
        : "pack://application:,,,/images/Login.png";

            //shows the image as a bitmap
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
            //close the current window
            this.Close();
        }
        private void GoToLogin_Click(object sender, RoutedEventArgs e)
        {
            //hides current window and goes to the login page 
            Login l_page = new();
            this.Hide();
            l_page.ShowDialog();
            this.Show();
        }
        public List<string> GetCheckedItems()
        {
            //creates a list for checked items to go into
            List<string> checkedItems = new List<string>();
            //loops through the item list
            foreach (var item in ItemsList.Items)
            {
                //gets the name of the current item and makes sure its not null
                var name = ItemsList.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                if (name != null)
                {
                    //gets the checkbox linked to the item and if its checked and not null
                    var checkBox = FindCheckbox<CheckBox>(name);
                    if (checkBox != null && checkBox.IsChecked == true)
                    {
                        //adds item to list
                        checkedItems.Add(item.ToString());
                    }
                }
            }
            return checkedItems;
        }



        public List<string> GetUncheckedItems()
        {
            //creates a list for unchecked items to go into
            List<string> uncheckedItems = new List<string>();
            //loops through the item list
            foreach (var item in ItemsList.Items)
            {
                //gets the name of the current item and makes sure its not null
                var name = ItemsList.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                if (name != null)
                {
                    //gets the checkbox linked to the item and that its not checked and not null
                    var checkBox = FindCheckbox<CheckBox>(name);
                    if (checkBox != null && checkBox.IsChecked == false)
                    {
                        //adds item to list
                        uncheckedItems.Add(item.ToString());
                    }
                }
            }
            return uncheckedItems;
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

            //loops though items and disables all checkboxes after submit button is clicked
            foreach (var item in ItemsList.Items)
            {
                var name = ItemsList.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                if (name != null)
                {
                    var checkBox = FindCheckbox<CheckBox>(name);
                    if (checkBox != null)
                    {
                        checkBox.IsEnabled = false;
                    }
                }
            }



            //displays the checked asnd unchecked list as a message box which would go into the database
            List<string> checkedItems = GetCheckedItems();
            List<string> unCheckedItems = GetUncheckedItems();
            MessageBox.Show("Checked items:\n" + string.Join(", ", checkedItems) + "\n\nUnchecked items:\n" + string.Join(", ", unCheckedItems));

        }
    }
}
