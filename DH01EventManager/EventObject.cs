using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xaml.Schema;

namespace DH01EventManager
{
    public class EventObject
    {
        private Int32 eventID;
        private String  eventname;
        private LocationObject eventlocation;
        private int eventDuration;
        private List<StaffObject>? eventStaff;
        private List<EquipmentObject>? eventEquipment;
        private DateTime eventDate;
        private int id;
        private string name;
        private LocationObject location;
        private DateTime date;
        private List<StaffObject>? staff;

        public  EventObject(Int32 id, String name, LocationObject location,DateTime date,Int32 duration,List<StaffObject>? staff, List<EquipmentObject>? eventEquipment) 
        {
            // Creates a new EventObject
            this.eventID = id;
            this.eventname = name;
            this.eventDate = date;  
            this.eventlocation = location;
            this.eventDuration = duration;
            // Below can be Null
            this.eventStaff = staff;
            this.eventEquipment = eventEquipment;
        }// EventObject - Constructor

        public EventObject(int id, string name, LocationObject location, DateTime date, List<StaffObject>? staff, List<EquipmentObject>? eventEquipment)
        {
            this.id = id;
            this.name = name;
            this.location = location;
            this.date = date;
            this.staff = staff;
            this.eventEquipment = eventEquipment;
        }

        // Event Getters
        public Int32 getEventID() { return this.eventID; }// GetEventID
        public String getEventName() { return this.eventname; } // GetEventName
        public DateTime getEventDate() { return this.eventDate; } // GetEventDate
        public LocationObject getEventLocation() {  return this.eventlocation; } // GetEventLocation
        public List<StaffObject>? getEventStaff() { return this.eventStaff; } // GetEventStaff
        public List <EquipmentObject>? getEventEquipment() { return this.eventEquipment; } //GetEventEquipment

        // Event Setters
        public void setEventID(Int32 id) {  this.eventID = id; } // SetEventID
        public void setEventName(String name) {  this.eventname = name; } // SetEventName
        public void setEventDate(DateTime date) { this.eventDate = date; } // SetEventDate
        public void setEventLocation(LocationObject location) { this.eventlocation = location; } // SetEventLocation
        public void setEventStaff(List<StaffObject> staff) { this.eventStaff = staff; } // SetEventStaff
        public void addEventEquipment(List<EquipmentObject> equipment) { this.eventEquipment = equipment; } // SetEventEquipment


        public String staffString()
        {
            String[] sArray;
            String sString = "";
            foreach (StaffObject staff in eventStaff)
            {
                sString = (String.Concat(staff.getForename(), " ", staff.getSurname()));
            }
            return sString;
        }

        public String equipmentString()
        {
            String[] eArray;
            String eString = "";
            foreach (EquipmentObject equip in eventEquipment)
            {
                eString = (String.Concat(equip.getEquipmentName()));
            }
            return eString;
        }

        public String toString() 
        {
            var date = DateOnly.FromDateTime(eventDate);
            var sTime = TimeOnly.FromDateTime(eventDate);
            DateTime d = eventDate.AddMinutes(eventDuration);
            var eTime = TimeOnly.FromDateTime(d);
            return string.Concat("Event Name: ", this.eventname, "\nDate: ", date.ToString(), "\nStart Time: ", sTime.ToString(), "\nEnd Time: ", eTime.ToString(), " \nLocation: ", this.eventlocation.getLocationName(), "\nStaff: ", staffString(),  "\nEquipment: ", equipmentString());
        }

        public Int32 getEventDuration()
        {
            return this.eventDuration;
        }
        public void setEventDuration(Int32 duration) 
        { 
            this.eventDuration = duration;
        }



        public static DateTime parseStartDate(DateTime startDate, String startTime)
        {
            DateTime date1 = new DateTime(2024, 12, 25).AddHours(1);
            DateTime date2 = new DateTime(2024, 12, 25, 06, 30;
            DateTime date3 = new DateTime(2024, 12, 25, 07, 00;
            DateTime date4 = new DateTime(2024, 12, 25, 07, 30;
            DateTime date5 = new DateTime(2024, 12, 25, 08, 00;
            DateTime date6 = new DateTime(2024, 12, 25, 08, 30;
            DateTime date7 = new DateTime(2024, 12, 25, 09,00;
            DateTime date8 = new DateTime(2024, 12, 25, 09, 30;
            DateTime date9 = new DateTime(2024, 12, 25, 10, 00;
            DateTime date10 = new DateTime(2024, 12, 25, 10, 30;
            DateTime date11 = new DateTime(2024, 12, 25, 11, 00;
            DateTime date12 = new DateTime(2024, 12, 25, 11, 30;
            DateTime date13 = new DateTime(2024, 12, 25, 12, 00;
            DateTime date14 = new DateTime(2024, 12, 25, 12, 30;
            DateTime date15 = new DateTime(2024, 12, 25, 01, 00;
            DateTime date16 = new DateTime(2024, 12, 25, 01, 30;
            DateTime date17 = new DateTime(2024, 12, 25, 02, 00;
            DateTime date18 = new DateTime(2024, 12, 25, 02, 30;
            DateTime date19 = new DateTime(2024, 12, 25, 03, 00;
            DateTime date20 = new DateTime(2024, 12, 25, 03, 30;
            DateTime date21 = new DateTime(2024, 12, 25, 04, 00;
            Console.WriteLine(date1.ToString()); // 12/25/2024 12:00:00 Am

        return DateTime.Now;
        }
        public static DateTime parseDuration(DateTime startDate,String StartTime, String EndTime)
        {
            return DateTime.Now;
        }



    }// EventObject
}
