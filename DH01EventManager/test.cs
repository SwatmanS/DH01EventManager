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

            MessageBox.Show("Constructing equipment object using parameters: 1, swabs, medical, 100","EquipmentObject Test");
            
            var testE = new EquipmentObject("1", "Swabs", "Medical", 100);

            MessageBox.Show("getEquipmentID: " + testE.getEquipmentID() + "\ngetEquipmentName: " + testE.getEquipmentName() + "\ngetEquipmentType: " + testE.getEquipmentType() + "\ngetEquipmentQuantity: " + testE.getEquipmentQuantity(), "EquipmentObject Test");
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
