using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
//using String = System.Runtime.InteropServices.JavaScript.JSType.String;

namespace DH01EventManager
{
    public class UpcomingEvent : EventObject
    {
        private Int32 eventEstimatedTurnout;
        public UpcomingEvent(Int32 id, String name, LocationObject location, DateTime date, List<StaffObject>? staff, List<EquipmentObject>? eventEquipment,Int32 estimate) : base(id, name, location, date, staff, eventEquipment)
        {
            this.eventEstimatedTurnout = estimate;
            //do we not need to calculate the estimated turnout using flyers handed out, info from 
            //community leaders, and previous event data?
        } // Upcoming Event Constructor 
        public UpcomingEvent(EventObject e,Int32 estimate) : base(e.getEventID(), e.getEventName(), e.getEventLocation(), e.getEventDate(), e.getEventStaff(), e.getEventEquipment())
        {
            this.eventEstimatedTurnout = estimate;
        } // Upcoming Event Constructor from EventObject
        public Int32 getEstimatedTurnout() {  return this.eventEstimatedTurnout; } // GetEstimatedTurnout
        public void setEstimatedTurnout(Int32 estimate) { this.eventEstimatedTurnout = estimate; } // SetEstimatedTurnout
    } // Upcoming Event Object
}
