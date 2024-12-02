using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DH01EventManager
{
   class test
    {
        public static void EquipmentObjectTest()
        {
            var testE = new EquipmentObject("1", "Swabs", "Medical", 100);
            MessageBox.Show("Constructing equipment object using parameters: 1, swabs, medical, 100\nResult: " + testE, "Eq Constructor Test");
            MessageBox.Show("getEquipmentID: " + testE.getEquipmentID() + "\ngetEquipmentName: " + testE.getEquipmentName() + "\ngetEquipmentType: " + testE.getEquipmentType() + "\ngetEquipmentQuantity: " + testE.getEquipmentQuantity(), "Eq Getter Test");
            MessageBox.Show("Using setters to change the following values:\nID = 2\nName = Speculum\nType = Medical\nQuantity = 10", "Eq Setter Test with Valid Data");
            testE.setEquipmentID("2");
            testE.setEquipmentName("Speculum");
            testE.setEquipmentType("Medical");
            testE.setEquipmentQuantity(10);
            MessageBox.Show("getEquipmentID: " + testE.getEquipmentID() + "\ngetEquipmentName: " + testE.getEquipmentName() + "\ngetEquipmentType: " + testE.getEquipmentType() + "\ngetEquipmentQuantity: " + testE.getEquipmentQuantity(), "Eq Setter with Valid Data Result");




        }

        public void EventObjectTest()
        {

        }

        public void LocationObjectTest()
        {

        }

        public void PastEventsTest()
        {

        }

        public void StaffObjectTest()
        {

        }

        public void UpcomingEventTest()
        {

        }

        public void UserObjectTest()
        {

        }
    }
}
