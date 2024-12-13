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
using static System.Net.Mime.MediaTypeNames;

namespace DH01EventManager
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        //creates the user
        public UserObject dummy = new UserObject("dummy", "user");
        public UserObject[] userArray;
        public Dictionary<String, String> userDict = new Dictionary<String, String>();
        

        public Login()
        {
            InitializeComponent();

            //automatically sets user to being logged out when clicking ontp this page
            Settings.loggedIn = false;

            //decides which image to use for the login/logout image
            UpdateLoginImage();

            //creates a dictionary of the users username and password
            userArray = dummy.makeArray();
            userDict = dummy.makeDictionary(userArray, userDict);
        }

        private void UpdateLoginImage()
        {
            //decides on the image that will be shown depending on the state of loggedin
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
        private void GoToAddEvent_Click(object sender, RoutedEventArgs e)
        {
            //checks to see if the user is logged in or not
            if (Settings.loggedIn == true)
            {
                // hides current window and goes to the add event page
                AddEvent l_page = new();
                this.Hide();
                l_page.ShowDialog();
                this.Show();
            }
            else
            {
                //if not logged in the user is sent to the login page
                Login l_page = new();
                this.Hide();
                l_page.ShowDialog();
                this.Show();
            }
        }
        private void GoToLogin_Click(object sender, RoutedEventArgs e)
        {
            //hides current window and goes to the login page 
            Login l_page = new();
            this.Hide();
            l_page.ShowDialog();
            this.Show();
        }
        private void SubmitLogin_Click(object sender, RoutedEventArgs e)
        {
            //search to see if dictionary contains the inputted username as a key and if that key corresponds to the inputted password
            if (userDict.ContainsKey(usernameBox.Text) && userDict[usernameBox.Text] == passwordBox.Password)
            {
                //sets loggedin to be true and updates the login image
                Settings.loggedIn = true;
                UpdateLoginImage();
                MessageBox.Show("logged in");

                //sends the user to the main window after logging in
                MainWindow l_page = new();
                this.Hide();
                l_page.ShowDialog();
                this.Show();
            }
            else
            {
                //shows error message if wrong username or password
                MessageBox.Show("incorrect username or password");
            }
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //if the password box is empty a message appears to let the user know to input something
            if (passwordBox.Password ==  "")
            {
                PasswordText.Text = "Please input your Password!";
            }
            else
            {
                PasswordText.Text = string.Empty;
            }
        }
    }
}
