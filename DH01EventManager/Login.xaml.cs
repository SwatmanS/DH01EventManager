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

        public UserObject dummy = new UserObject("dummy", "user");
        public UserObject[] userArray;
        public Dictionary<String, String> userDict = new Dictionary<String, String>();
        

        public Login()
        {
            InitializeComponent();
            Settings.loggedIn = false;
            //decides which image to use for the login/logout image
            UpdateLoginImage();

            userArray = dummy.makeArray();
            userDict = dummy.makeDictionary(userArray, userDict);
        }

        private void UpdateLoginImage()
        {
            //decides on the image that will be shown depending on the state of loggedin
            string imagePath = Settings.loggedIn
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
        private void GoToAddEvent_Click(object sender, RoutedEventArgs e)
        {
            //hides current window and goes to the add event page 
            if (Settings.loggedIn == true)
            {
                AddEvent l_page = new();
                this.Hide();
                l_page.ShowDialog();
                this.Show();
            }
            else
            {
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
            //if true, user is logged in
            //if false, error message
            if (userDict.ContainsKey(usernameBox.Text) && userDict[usernameBox.Text] == passwordBox.Password)
            {
                Settings.loggedIn = true;
                UpdateLoginImage();
                MessageBox.Show("logged in");
                MainWindow l_page = new();
                this.Hide();
                l_page.ShowDialog();
                this.Show();
            }
            
            {
                MessageBox.Show("incorrect username or password");
            }
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password ==  "") //lets user know to input something if box is empty
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
