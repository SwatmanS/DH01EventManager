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
        public static bool isLoggedIn = false;

        public Login()
        {
            InitializeComponent();

            UpdateLoginImage();
        }

        private void UpdateLoginImage()
        {
            string imagePath = isLoggedIn
        ? "pack://application:,,,/images/Logout.png"
        : "pack://application:,,,/images/Login.png";

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
            AddEvent l_page = new();
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
        private void SubmitLogin_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == "abc" && usernameBox.Text == "12345") //get this from the database
            {
                isLoggedIn = true;
                UpdateLoginImage();
                MessageBox.Show("logged in");
                this.Close();
            }
            else if (passwordBox.Password != "abc" && usernameBox.Text != "12345")
            {
                MessageBox.Show("both username and password incorrect");
            }
            else if (passwordBox.Password == "abc")
            {
                MessageBox.Show("password incorrect");
            }
            else
            {
                MessageBox.Show("username incorrect");
            }
        }
        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == "Password")
            {
                PasswordText.Text = "'Password' is not allowed as a password.";
            }
            else if (passwordBox.Password ==  "")
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
