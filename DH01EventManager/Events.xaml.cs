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

            List<EventObject> events = new List<EventObject>();
            events = DBAbstractionLayer.getAllEvents();
            List < UpcomingEvent > upEvent = new List<UpcomingEvent>();
            upEvent = DBAbstractionLayer.getUpcomingEvents();

            
            List<String> ListOf = new List<String>();
            String evString;
            String temp;

            for(int i =0; i < upEvent.Count; i++)
            {
                evString = upEvent[i].toString();
                evString = upEvent[i].addString(evString);
                ListOf.Add(evString);

            }
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
            int textIndex = 1;

            //loops for each row
            for (int row = 0; row < numRows; row++)
            {
                //loops for each column
                for (int col = 0; col < numColumns; col++)
                {
                    //stops when index reaches length of array
                    if (textIndex - 1 >= ListOf.Count) break;

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
                        Text = ListOf[textIndex - 1],
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

                    //adds the items to the grid container
                    container.Children.Add(eventText);

                    if (Settings.loggedIn == true)
                    {
                        //button clicked method
                        container.Children.Add(editButton);
                        editButton.Tag = textIndex - 1; 
                        editButton.Click += EditButton_Click;
                    }

                    //adds the grid container to the canvas
                    outline.Child = container;

                    //+1 to index
                    textIndex++;
                }
            }

            void EditButton_Click(object sender, RoutedEventArgs e)
            {
                Button clickedButton = sender as Button;
                if (clickedButton != null && clickedButton.Tag is int index)
                {
                    Settings.eventIndex = index+1;
                    OpenEditPage();
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

        private void OpenEditPage()
        {
            //hides current window and goes to the edit event page 
            EditEvent l_page = new();
            this.Hide();
            l_page.ShowDialog();
            this.Show();
        }
    }
}
