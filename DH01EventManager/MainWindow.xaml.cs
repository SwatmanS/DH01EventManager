using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DH01EventManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            bool d = true;
            if (d)
            {
                DBAbstractionLayer.reset();
                
                Window debugWindow = new DebugWindow();
                debugWindow.Show();
            }
            
            //connects to the database
            DBAbstractionLayer.connect();
            //Gets Info for frontend
            Settings.getDBData();
            //updates the logged in image 
            UpdateLoginImage();
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
            //hides current window and goes to the veiw events page 
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
    }
}