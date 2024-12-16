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
            Debug.WriteLine("    #################\n****####Sam Tests####****\n    #################");

            Debug.WriteLine("\nTest DBAL-01 DBAL Connection test");
            DBAbstractionLayer.connect();

            Debug.WriteLine("\nTest DBAL-02 DBAL Disconnection test");
            DBAbstractionLayer.disconnect();

            Debug.WriteLine("\nTest DBAL-03 DBAL Reset test");
            DBAbstractionLayer.reset();

            Debug.WriteLine("\nTest DBAL-04 DBAL Get status when connected");
            DBAbstractionLayer.connect();
            Debug.WriteLine(DBAbstractionLayer.getStatus());
            DBAbstractionLayer.disconnect();

            Debug.WriteLine("\nTest DBAL-05DBAL Get status when disconnected");
            Debug.WriteLine(DBAbstractionLayer.getStatus());

            Debug.WriteLine("\nTest DBAL-06 DBAL Ensure status when connected");
            DBAbstractionLayer.connect();
            DBAbstractionLayer.ensureStatus();
            DBAbstractionLayer.disconnect();

            Debug.WriteLine("\nTest DBAL-07 DBAL Ensure status when disconnected");
            DBAbstractionLayer.ensureStatus();
            DBAbstractionLayer.disconnect();

            DBAbstractionLayer.ensureStatus();
            Debug.WriteLine("\nTest DBAL-08 DBAL Is previous event with valid event");
            Debug.WriteLine(DBAbstractionLayer.isPreviousEvent(1));

            Debug.WriteLine("\nTest DBAL-09 DBAL Is previous event with invalid event");
            Debug.WriteLine(DBAbstractionLayer.isPreviousEvent(-1));

            Debug.WriteLine("\nTest DBAL-10");
            Debug.WriteLine(DBAbstractionLayer.removeUpcomingEvent(1));

           // Debug.WriteLine("\nTest DBAL-11");
           // Debug.WriteLine(DBAbstractionLayer.addPreviousEvent

           Debug.WriteLine("\nTest DBAL-12");
          // Debug.WriteLine(DBAbstractionLayer.updateUpcomingEvent(1));
          // Debug.WriteLine updates upcoming events in the programme

            Debug.WriteLine("\nTest DBAL-14");
           // Debug.WriteLine(DBAbstractionLayer.addNewEvent 
           // Debug.writeLine test works in the programme

            Debug.WriteLine("\nTest DBAL-15");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-16");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-17");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-18");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-19");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-20");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-21");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-22");
            Debug.WriteLine(DBAbstractionLayer.(1));
#
            Debug.WriteLine("\nTest DBAL-23");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-24");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-25");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-26");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-27");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-28");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-29");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-30");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-31");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-32");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-33");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-34");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-35");
            Debug.WriteLine(DBAbstractionLayer.(1));
#
            Debug.WriteLine("\nTest DBAL-36");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-37");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-38");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-39");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-40");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-41");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-42");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-43");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-44");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-45");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-46");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-47");
            Debug.WriteLine(DBAbstractionLayer.(1));
#
            Debug.WriteLine("\nTest DBAL-48");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-49");
            Debug.WriteLine(DBAbstractionLayer.(1));

            Debug.WriteLine("\nTest DBAL-50");
            Debug.WriteLine(DBAbstractionLayer.(1));















            Debug.WriteLine("Testing Writing New Event to DB");
            List<StaffObject> staffList = new List<StaffObject>();
            Debug.WriteLine(DBAbstractionLayer.getStaffByID(1));
            staffList.Add(DBAbstractionLayer.getStaffByID(1));
            EventObject newEvent = new EventObject(
                DBAbstractionLayer.getNewEventID(),
                "TestEvent :)",
                DBAbstractionLayer.getLocationByID(1),
                new DateTime(2024,12,31),
                60,
                staffList,
                new List<EquipmentObject>() {DBAbstractionLayer.getEquipmentByID(1), DBAbstractionLayer.getEquipmentByID(2)}
                );
            Debug.WriteLine(newEvent.toString());
            Debug.WriteLine(DBAbstractionLayer.addNewEvent(newEvent));
            
            Debug.WriteLine("Testing Updating New Event to DB");
            staffList.Add(DBAbstractionLayer.getStaffByID(2));
            EventObject updatedEvent = new EventObject(
                7,
                "TestEvent Updated :O",
                DBAbstractionLayer.getLocationByID(2),
                new DateTime(2024, 12, 31),
                60,
                staffList,
                new List<EquipmentObject>() { DBAbstractionLayer.getEquipmentByID(2), DBAbstractionLayer.getEquipmentByID(3) }
                );
            Debug.WriteLine(updatedEvent.toString());
            DBAbstractionLayer.updateEvent(updatedEvent);

            Debug.WriteLine($"\n EventObject Testing");
            foreach (String s in EventObject.timeList)
            {
                Debug.WriteLine(s);
                Debug.WriteLine(EventObject.strTimeToInt(s));
            }
        }
    }
} 
