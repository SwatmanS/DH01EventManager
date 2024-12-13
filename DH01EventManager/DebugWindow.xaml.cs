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
    /// Interaction logic for DebugWindow.xaml
    /// </summary>
    public partial class DebugWindow : Window
    {
        public DebugWindow()
        {
            InitializeComponent();
        }
        private void GoToSamTest(object sender, RoutedEventArgs e)
        {
            Window x = new SamsTestPage();
            x.Show();
        }

        private void GoToJasmineTest(object sender, RoutedEventArgs e)
        {
            Window x = new jasmineTest();
            x.Show();

        }
        private void GoToOwenTest(object sender, RoutedEventArgs e)
        {
            Window x = new OwenTestPage();
            x.Show();
        }
        private void GoToGinaTest(object sender, RoutedEventArgs e)
        {
            Window x = new MainWindow();
            x.Show();
        }
    }
}
