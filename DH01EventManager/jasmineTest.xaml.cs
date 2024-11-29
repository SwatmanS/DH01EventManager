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
    /// Interaction logic for jasmineTest.xaml
    /// </summary>
    public partial class jasmineTest : Window
    {
        public jasmineTest()
        {
            InitializeComponent();
        }

        private void alucard(object sender, RoutedEventArgs e)
        {
            //close the current window

            //test.EquipmentObjectTest();
            test.LocationObjectTest();
        }
    }
}
