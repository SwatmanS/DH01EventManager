﻿using System;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
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
            //close the current window
            this.Close();
        }
        private void GoToSettings_Click(object sender, RoutedEventArgs e)
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
        private void SubmitLogin_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == "abc") //get this from the database
            {
                MessageBox.Show("logged in");
                //log the user in 
                this.Close();
            }
            else
            {
                MessageBox.Show("username or password incorrect");
            }
        }
        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == "Password")
            {
                statusText.Text = "'Password' is not allowed as a password.";
            }
            else if (passwordBox.Password ==  "")
            {
                statusText.Text = "Please input your Password!";
            }
            else
            {
                statusText.Text = string.Empty;
            }
        }
    }
}
