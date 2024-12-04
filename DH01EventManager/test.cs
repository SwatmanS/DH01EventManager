using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DH01EventManager
{
   class user1
    {
        public static void EquipmentObjectTest()
        {
            var testE = new EquipmentObject(1, "Swabs", "Medical", 100);
            MessageBox.Show("Constructing equipment object using parameters: 1, swabs, medical, 100\nResult: " + testE, "Eq Constructor Test");
            MessageBox.Show("getEquipmentID: " + testE.getEquipmentID() + "\ngetEquipmentName: " + testE.getEquipmentName() + "\ngetEquipmentType: " + testE.getEquipmentType() + "\ngetEquipmentQuantity: " + testE.getEquipmentQuantity(), "Eq Getter Test");
            MessageBox.Show("Using setters to change the following values:\nID = 2\nName = Speculum\nType = Medical\nQuantity = 10", "Eq Setter Test with Valid Data");
            testE.setEquipmentID(2);
            testE.setEquipmentName("Speculum");
            testE.setEquipmentType("Medical");
            testE.setEquipmentQuantity(10);
            MessageBox.Show("getEquipmentID: " + testE.getEquipmentID() + "\ngetEquipmentName: " + testE.getEquipmentName() + "\ngetEquipmentType: " + testE.getEquipmentType() + "\ngetEquipmentQuantity: " + testE.getEquipmentQuantity(), "Eq Setter with Valid Data Result");
        }

        public static void EventObjectTest()
        {
        }

        public static void LocationObjectTest()
        {
            //int id, str name, str type, int capacity
            var testLo = new LocationObject(1, "Bukit Tinggi Medical Centre", "Doctors' Surgery", 40);
            MessageBox.Show("Constructing location object using parameters: 1, Bukit Tinggi Medical Centre, Doctors' Surgery, 40\nResult: " + testLo, "Lo Constructor Test");
            MessageBox.Show("GetLocationID: " + testLo.GetLocationName() + "\nGetLocationType: " + testLo.GetLocationType() + "\nGetLocationCapacity: " + testLo.GetLocationCapacity(), "Lo Getter Test");
            MessageBox.Show("Using setters to change the following values:\nID = 2\nName = Bentong Town Hall\nType = Town Hall\nCapacity = 100", "Lo Setter Test with Valid Data");
            testLo.SetLocationID(2);
            testLo.SetLocationName("Bentong Town Hall");
            testLo.SetLocationType("Town Hall");
            testLo.SetLocationCapacity(100);
            MessageBox.Show("GetLocationID: " + testLo.GetLocationName() + "\nGetLocationType: " + testLo.GetLocationType() + "\nGetLocationCapacity: " + testLo.GetLocationCapacity(), "Lo Setter with Valid Data Result");

        }

        public static void PastEventsTest()
        {

        }

        public static void StaffObjectTest()
        {
            //int id, str name, str type, str array workable events
            var testSt = new StaffObject(1, "Zara", "Nurse", ["Medical", "Information"]);
            MessageBox.Show("Constructing staff object using parameters: 1, Zara, Nurse, [Medical, Information]\nResult: " + testSt, "St Constructor Test");
            MessageBox.Show("getStaffID: " + testSt.getStaffID() + "\ngetStaffName: " + testSt.getStaffName() + "\ngetStaffType: " + testSt.getStaffType() + "\ngetWorkableEvents: " + testSt.GetWorkableEvents(), "St Getter Test");
            MessageBox.Show("Using setters to change the following values:\nID = 2\nName = Nor\nType = Admin\nWorkable Events = [Information]", "St Setter Test with Valid Data");
            testSt.setStaffID(2);
            testSt.setStaffName("Nor");
            testSt.setWorkableEvents(["Information"]);
            MessageBox.Show("getStaffID: " + testSt.getStaffID() + "\ngetStaffName: " + testSt.getStaffName() + "\ngetStaffType: " + testSt.getStaffType() + "\ngetWorkableEvents: " + testSt.GetWorkableEvents(), "St Setter with Valid Data Result");

        }

        public static void UpcomingEventTest()
        {

        }

        public static void UserObjectTest()
        {
            var testUs = new UserObject("jasmine", "ilovealucard");
            UserObject[] testArray = testUs.makeArray();
            MessageBox.Show("we " + testArray[0].getUsername() + testArray[1], "test");
            Dictionary<String, String> testDict = new Dictionary<String, String>();
            MessageBox.Show("we " + testUs.makeDictionary(testArray, testDict));
            foreach (KeyValuePair<String, String> user in testDict)
            {
                MessageBox.Show("Value: " + user.Value, "Key :" + user.Key);
            }

            MessageBox.Show("value for jasmine: " + testDict["jasmine"]);
            MessageBox.Show("Constructing user object using parameters: Jasmine, ilovealucard\n Result: " + testUs, "Us Constructor Test");
            MessageBox.Show("getUsername: " + testUs.getUsername() + "\ngetPassword: " + testUs.getPassword(), "Us Getter Test");
            MessageBox.Show("Using setters to change the following values:\nusername = lawson\npassword = istilllovealucard", "Us Setter Test with Valid Data");
            testUs.setUsername("lawson");
            testUs.setPassword("istilllovealucard");
            MessageBox.Show("getUsername: " + testUs.getUsername() + "\ngetPassword: " + testUs.getPassword(), "Us Setter with Valid Data Result");
        }

        public static void LogInObjectTest()
        {
        }
    }
}
