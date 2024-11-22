using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml.Schema;

namespace DH01EventManager
{
    internal class EventObject
    {
        private String eventID;
        private String  eventname;
        private LocationObject eventlocation;
        private List<StaffObject>? eventStaff;
        private List<EquipmentObject>? eventEquipment;
        private DateTime eventDate;
        public  EventObject(String id, String name, LocationObject location,DateTime date,List<StaffObject>? staff, List<EquipmentObject>? eventEquipment) 
        {
            // Creates a new EventObject
            this.eventID = id;
            this.eventname = name;
            this.eventDate = date;  
            this.eventlocation = location;
            // Below can be Null
            this.eventStaff = staff;
            this.eventEquipment = eventEquipment;
        }// EventObject - Constructor
        
        // Event Getters
        public String getEventID() { return this.eventID; }// GetEventID
        public String getEventName() { return this.eventname; } // GetEventName
        public DateTime getEventDate() { return this.eventDate; } // GetEventDate
        public LocationObject getEventLocation() {  return this.eventlocation; } // GetEventLocation
        public List<StaffObject>? getEventStaff() { return this.eventStaff; } // GetEventStaff
        public List <EquipmentObject>? getEventEquipment() { return this.eventEquipment; } //GetEventEquipment

        // Event Setters
        public void setEventID(String id) {  this.eventID = id; } // SetEventID
        public void setEventName(String name) {  this.eventname = name; } // SetEventName
        public void setEventDate(DateTime date) { this.eventDate = date; } // SetEventDate
        public void setEventLocation(LocationObject location) { this.eventlocation = location; } // SetEventLocation
        public void setEventStaff(List<StaffObject> staff) { this.eventStaff = staff; } // SetEventStaff
        public void addEventEquipment(List<EquipmentObject> equipment) { this.eventEquipment = equipment; } // SetEventEquipment
    }// EventObject
}
