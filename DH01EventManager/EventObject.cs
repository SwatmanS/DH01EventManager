using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return string.Concat("EventObject: ", this.eventname,"\nID: ",this.eventID,"\nLocation: ", this.eventlocation.getLocationName(), "\nStaff: ", staffString(), "\nEvent Date: ", this.eventDate, "\nEquipment: ", equipmentString());
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
            return DateTime.Now;
        }
        public static DateTime parseDuration(DateTime startDate,String StartTime, String EndTime)
        {
            return DateTime.Now;
        }



    }// EventObject
}
