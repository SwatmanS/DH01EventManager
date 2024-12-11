using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
            var d = DateTime.Now.Minute;
            var d2 = DateTime.Now.Hour;
            Debug.WriteLine(d);
            Debug.WriteLine(d2);
            Debug.WriteLine(EventObject.dateTimeToStr(DateTime.Now));
            Debug.WriteLine(EventObject.strTimeToInt("6:30am"));

        }
    }
} 
