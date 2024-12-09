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
    /// Interaction logic for Events.xaml
    /// </summary>
    public partial class Events : Window
    {
        public Events()
        {
            InitializeComponent();
            //decides which image to use for the login/logout image
            UpdateLoginImage();

            string[] ListOf = ["", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""];


            canvas.Height = ListOf.Length*240;


            int width = 800;
            int height = 400;
            CornerRadius corner = new CornerRadius(100);
            int top;
            int left;

            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < (ListOf.Length/2); y++)
                {
                    Border rec = new Border()
                    {
                        Width = width,
                        Height = height,
                        Background = Brushes.White,
                        CornerRadius = corner,
                    };
                    left = 50 + width*x + x*75;
                    top = 50 + height*y + y*75;
                    canvas.Children.Add(rec);
                    Canvas.SetTop(rec, top);
                    Canvas.SetLeft(rec, left);
                }
            }

        }

        private void UpdateLoginImage()
        {
            //decides on the image that will be shown depending on the state of isloggedin
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
    }
}
