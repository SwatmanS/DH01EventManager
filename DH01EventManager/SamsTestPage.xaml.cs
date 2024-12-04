using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for SamsTestPage.xaml
    /// </summary>
    public partial class SamsTestPage : Window
    {
        public SamsTestPage()
        {
            InitializeComponent();
            DateTime d = DateTime.Now;
            String d1 = "03 / 12 / 2024 14:54:08";
            Debug.WriteLine(d1.Length);
            DateTime d2 = DateTime.Parse(d1);
            Debug.WriteLine(d.Subtract(d2));
        }
    }
}
