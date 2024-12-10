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

            //dummy data of events
            string[] ListOf = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];

            //makes the canvas height dynamic
            canvas.Height = (ListOf.Length+1)*240;

            //variables needed for the canvas
            int width = 800;
            int height = 400;
            CornerRadius corner = new CornerRadius(100);
            int top;
            int left;
            int textIndex = 0;

            //creates the two columns
            for (int x = 0; x < 2; x++) 
            {
                //the rows 
                for (int y = 0; y < (ListOf.Length / 2 + 1); y++) 
                {
                    // Create the Border
                    Border outline = new Border()
                    {
                        Width = width,
                        Height = height,
                        Background = Brushes.White,
                        CornerRadius = corner,
                    };

                    // Calculate position
                    left = 50 + width * x + x * 75; 
                    top = 50 + height * y + y * 75; 

                    // Add border to canvas
                    canvas.Children.Add(outline);
                    Canvas.SetTop(outline, top);
                    Canvas.SetLeft(outline, left);

                    // Add TextBlock to Border
                    if (textIndex < ListOf.Length) 
                    {
                        TextBlock eventText = new TextBlock()
                        {
                            Text = ListOf[textIndex],
                            Foreground = Brushes.Black,
                            FontSize = 32,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center
                        };

                        //add it to the borders and up the index
                        outline.Child = eventText; 
                        textIndex++;
                    }
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
