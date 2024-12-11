using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            List<EventObject> events = new List<EventObject>();
            events = DBAbstractionLayer.getAllEvents();
            
            List<String> ListOf = new List<String>();
            String evString;

            foreach (EventObject ev in events)
            {
                ListOf.Add(ev.toString());
            }


            /*string[] ListOf = ["Event Title: 1st Event\n Event date: 01.01.2001,\n Event starts at 6am and ends at 5pm,\n Event Capacity: 120 people,\n Event Staff: Batrisyia Orked, Irfan Kesuma, Haziq Som, Mia Kiambang,\n Event Location: Family Clinic Seventeen",
                "Event Title: 2nd Event\n Event date: 02.02.2002,\n Event starts at 7am and ends at 12pm,\n Event Capacity: 60 people,\n Event Staff: a, b, c, d,\n Event Location: Family Clinic Seventeen",
                "Event Title: 3rd Event\n Event date: 03.03.2003,\n Event starts at 9am and ends at 9pm,\n Event Capacity: 120 people,\n Event Staff: Batrisyia Orked, Irfan Kesuma, Haziq Som, Mia Kiambang,\n Event Location: Family Clinic Seventeen",
                "Event Title: 4th Event\n Event date: 04.04.2004,\n Event starts at 6am and ends at 5pm,\n Event Capacity: 120 people,\n Event Staff: Batrisyia Orked, Irfan Kesuma, Haziq Som, Mia Kiambang,\n Event Location: Family Clinic Seventeen",
                "Event Title: 5th Event\n Event date: 05.05.2005,\n Event starts at 6am and ends at 5pm,\n Event Capacity: 120 people,\n Event Staff: Batrisyia Orked, Irfan Kesuma, Haziq Som, Mia Kiambang,\n Event Location: Family Clinic Seventeen",];
            */
            //makes the canvas height dynamic
            canvas.Height = (ListOf.Count + 1) * 240;

            //variables needed for the canvas
            int numColumns = 2;
            int numRows = (int)Math.Ceiling((double)ListOf.Count / numColumns);
            int width = 800;
            int height = 400;
            CornerRadius corner = new CornerRadius(100);
            int top;
            int left;
            int textIndex = 0;

            //loops for each row
            for (int row = 0; row < numRows; row++)
            {
                //loops for each column
                for (int col = 0; col < numColumns; col++)
                {
                    //stops when index reaches length of array
                    if (textIndex >= ListOf.Count) break;

                    //creates the border
                    Border outline = new Border()
                    {
                        Width = width,
                        Height = height,
                        Background = Brushes.White,
                        CornerRadius = corner,
                    };

                    //finds placement of blocks
                    left = 50 + col * (width + 75);
                    top = 50 + row * (height + 75);

                    //add border to canvas
                    canvas.Children.Add(outline);
                    Canvas.SetTop(outline, top);
                    Canvas.SetLeft(outline, left);

                    //adds a grid into the canvas to place multiple items
                    Grid container = new Grid();

                    //makes the textblock
                    TextBlock eventText = new TextBlock()
                    {
                        Text = ListOf[textIndex],
                        Foreground = Brushes.Black,
                        FontSize = 24,
                        FontFamily = new FontFamily("Verdana"),
                        TextWrapping = TextWrapping.Wrap,
                        TextAlignment = TextAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Center,
                        Padding = new Thickness(5)
                    };

                    //the image for the edit buttons
                    Image buttonImage = new Image()
                    {
                        Source = new BitmapImage(new Uri("pack://application:,,,/images/Edit.png")),
                        Width = 50,
                        Height = 50,
                        Stretch = Stretch.UniformToFill
                    };

                    //makes the buttons
                    Button editButton = new Button()
                    {
                        Content = buttonImage,
                        Height = 60,
                        Width = 60,
                        Background = Brushes.Transparent,
                        Foreground = Brushes.Transparent,
                        BorderBrush = Brushes.Transparent,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(30)
                    };

                    //button clicked method
                    editButton.Click += (s, e) => OpenEditPage(textIndex);

                    //adds the items to the grid container
                    container.Children.Add(eventText);
                    container.Children.Add(editButton);

                    //adds the grid container to the canvas
                    outline.Child = container;

                    //+1 to index
                    textIndex++;
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



        private void OpenEditPage(int eventNum)
        {
            Settings.eventIndex = eventNum;
            //hides current window and goes to the login page 
            EditEvent l_page = new();
            this.Hide();
            l_page.ShowDialog();
            this.Show();
        }
    }
}
