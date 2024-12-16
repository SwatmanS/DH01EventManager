using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
        static List<String> timeList= new List<String>() { "6:00 AM", "6:30 AM", "7:00 AM", "7:30 AM", "8:00 AM", "8:30 AM", "9:00 AM", "9:30 AM", "10:00 AM", "10:30 AM", "11:00 AM", "11:30 AM", "12:00 PM", "12:30 PM", "1:00 PM", "1:30 PM", "2:00 PM", "2:30 PM", "3:00 PM", "3:30 PM", "4:00 PM", "4:30 PM", "5:00 PM", "5:30 PM", "6:00 PM", "6:30 PM", "7:00 PM", "7:30 PM", "8:00 PM", "8:30 PM", "9:00 PM" };

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
            this.eventID = id;
            this.eventname = name;
            this.eventlocation = location;
            this.eventDate = date;
            this.eventStaff = staff;
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
                if (sString == "")
                {
                    {
                        sString = (String.Concat(staff.getForename(), " ", staff.getSurname()));
                    }
                }
                else
                {
                    sString = (String.Concat(sString + ", " + staff.getForename(), " ", staff.getSurname()));
                }
                
            } 
            return sString;
        }

        public String equipmentString()
        {
            String[] eArray;
            String eString = "";
            foreach (EquipmentObject equip in eventEquipment)
            {
                if (eString == "")
                {
                    eString = (String.Concat(equip.getEquipmentName()));
                }
                else
                {
                    eString = (String.Concat(eString + ", " + equip.getEquipmentName()));
                }
            }
            return eString;
        }

       public String toString() 
        {
            return string.Concat("Event: ", this.eventname, "\nDate: ", getStartDate(), "\nStart Time: ", getStartTime(), "\nEnd Time: ", getEndTime(), " \nLocation: ", this.eventlocation.getLocationName(), "\nStaff: ", staffString(),  "\nEquipment: ", equipmentString());
        }

        public Int32 getEventDuration()
        {
            return this.eventDuration;
        }
        public void setEventDuration(Int32 duration) 
        { 
            this.eventDuration = duration;
        }
        //6AM - 9PM (21)
        //6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21 #31
        public static Int32 strTimeToInt(String s)
        {
            Int32 x = 0;
            for (int i = 0; i > EventObject.timeList.Count;i++)
            {
                if (s == EventObject.timeList[i])
                {
                    x = i;
                }
            }
            
            Int32 halfPast = x +1 % 2;//16 Hours
            Int32 hour = x - (halfPast) / 2;
            return ((hour+6)*60)+(halfPast*30);
        }
        public static String dateTimeToStr(DateTime d)
        {
            
            Int32 Hour = Int32.Parse(d.Hour.ToString());
            Int32 Minutes = Int32.Parse(d.Minute.ToString());
            Int32 index = 0;
            Int32 hasMinute = 0;
            if (Minutes != 0 )
            {
                hasMinute = 1;
            }
            index = (Hour - 6) * 2 + hasMinute;
            return EventObject.timeList[index];
        }

        public static DateTime parseStartDate(DateTime startDate, String startTime)
        {
            Debug.WriteLine($"Start Date: {startDate}, Start Time {startTime}");
            return startDate.AddMinutes(EventObject.strTimeToInt(startTime));
        }
        public static Int32 parseDuration(String StartTime, String EndTime)
        {
            int start = EventObject.strTimeToInt(StartTime);
            int end = EventObject.strTimeToInt(EndTime);
            return end - start;
        }

        public String getStartDate()
        {
            return eventDate.ToString("dddd dd MMMM yyyy");
        }
        public String getStartTime()
        { 
            return eventDate.ToString("hh:mm tt");
            //return EventObject.dateTimeToStr(eventDate);
        }
        public String getEndTime()
        {
            eventDate = eventDate.AddMinutes(eventDuration);
            return eventDate.ToString("hh:mm tt");
        }


    }// EventObject
}
