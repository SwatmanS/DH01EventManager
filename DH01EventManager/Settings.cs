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

        public static string[] staffList = ["Ammar Raja", "Syshmi Megat", "Ashraff Tengku", "Damia Jehan", "Zara Shah",
            "Qaisara Mayang", "Mia Kiambang", "Keisha Joyo", "Arissa Tam", "Hadif Tuah", "Rayyan Kesuma", "Haziq Som",
            "Alya Wira", "Amani Wati", "Aishah Mayang", "Noor Lai", "Balqis Darma", "Aishah Shah", "Qistina Mirza",
            "Hakim Ros", "Alya Tiara", "Batrisyia Orked", "Irfan Kesuma", "Humaira Jehan", "Damia Mayang ", "Amani Wira"];

        public static string[] equipmentList = ["tables", "stuff", "stuff2", "stuff3", "stuff4", "stuff5", "stuff6", "stuff7", "stuff8", "stuff9", "stuff10"];

        public static string[] locationList = ["Bangsar South Medical Clinic", "Klinik Primary Care 4U", "BeHealth Clinic",
            "Perdana Medical Clinic", "Klinik Dr.Prevents", "Medhope Family Clinic", "Qualitas SV Care Clinic",
            "Wellcare Clinic", "Klinik Mediviron Metropark", "Klinik Primaria", "Medizone Family Clinic", 
            "Klinik Family E-Medic", "Klinik Careclinics Al-Amin", "My Family Clinic", "REN.CLINIC", "RIIYYAH MEDICAL CLINIC",
            "Muthu's Clinic and Surgery", "X Care Clinic", "Family Clinic Seventeen", "SV Care Clinic", "Emerald Clinic Rawang",
            "Nlee Family Clinic", "MCare Clinic", "TMC Health Centre", "Clinic Medi-Genesis", "One Med Clinic"];

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
