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
    /// Interaction logic for OwenTestPage.xaml
    /// </summary>
    public partial class OwenTestPage : Window
    {
        public OwenTestPage()
        {
            InitializeComponent();
            /*
             * 
             *  Put Tests Below
             * 
             */
            Debug.WriteLine("Test DBAL-60 get all events test");
            List<EventObject> l =  DBAbstractionLayer.getAllEvents();
            foreach (EventObject e in l)
            {
                Debug.WriteLine(e.toString());
            }
            Debug.WriteLine("Test DBAL-67 get all upcoming events test");
            List<UpcomingEvent> l2 = DBAbstractionLayer.getUpcomingEvents();
            foreach (UpcomingEvent u in l2)
            {
                EventObject e = u;
                Debug.WriteLine(e.toString());
                Debug.WriteLine(u.getEstimatedTurnout());
            }
        }
    }
}
