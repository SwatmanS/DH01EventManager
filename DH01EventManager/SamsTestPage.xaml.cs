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
            Debug.WriteLine(d2.Subtract(d).Days <= 0);
            LocationObject testLoc = new LocationObject(0, "Location Name", "1 Null Avenue, AA1 1XD", 60);
            String output = "";
            output = testLoc.toString();
            Debug.WriteLine(output);
            EventObject testE = new EventObject(0, "Test Event 1", testLoc, d2, null,null);
            output = testE.toString();
            Debug.WriteLine(output);

            StaffObject member1 = new StaffObject(0, "0Foo", "Bar", "+44 1234 123 123", "CEO");
            StaffObject member2 = new StaffObject(1, "1Foo", "Bar", "+44 2234 123 123", "Manager");
            StaffObject member3 = new StaffObject(2, "2Foo", "Bar", "+44 3234 123 123", "Volunteer");
            StaffObject member4 = new StaffObject(3, "3Foo", "Bar", "+44 4234 123 123", "Volunteer");
            StaffObject member5 = new StaffObject(4, "4Foo", "Bar", "+44 5234 123 123", "Volunteer");
            StaffObject member6 = new StaffObject(5, "5Foo", "Bar", "+44 6234 123 123", "Volunteer");

            EquipmentObject kit1 = new EquipmentObject(0, "Table", "Its a Table", 1);
            EquipmentObject kit2 = new EquipmentObject(1, "Chair", "Its a Chair", 1);

            List<EquipmentObject> kitList = [kit1, kit2];
            List<StaffObject> staffList = [member1, member2, member3, member4, member5, member6];
            List<EventObject> eventsList = new List<EventObject>(); 
            for (int i = 0; i < 10; i ++)
            {
                eventsList.Add(new EventObject(i,String.Concat("Event",i),testLoc,d.AddDays(i*2),staffList,kitList));
            }
        }
    }
} 
