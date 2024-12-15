using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DH01EventManager
{
    class Settings
    {
        //the public logged in value which is set to false when the application is opened
        public static Boolean loggedIn = false;

        public static int eventIndex = -1;

        public static List<EquipmentObject>? equipmentObjects = new List<EquipmentObject>();
        public static List<LocationObject>? locationObjects = new List<LocationObject>();  
        public static List<StaffObject>? staffObjects = new List<StaffObject>();    
        public static void getDBData()
        {
            equipmentObjects = DBAbstractionLayer.getAllEquipment();
            locationObjects = DBAbstractionLayer.getAllLocations();
            staffObjects = DBAbstractionLayer.getAllStaff();
            
            List<String> l1 = new List<String>();
            foreach (EquipmentObject eq in equipmentObjects)
            {
                l1.Add(eq.getEquipmentName());
            }

            List<String> l2 = new List<String>();
            foreach (StaffObject st in staffObjects)
            {
                l2.Add(st.getStaffFullName());
            }

            List<String> l3 = new List<String>();
            foreach (LocationObject lo in locationObjects)
            {
                l3.Add(lo.getLocationName());
            }
            staffList = l2.ToArray();
            equipmentList = l1.ToArray();
            locationList = l3.ToArray();
        }

    }
}
