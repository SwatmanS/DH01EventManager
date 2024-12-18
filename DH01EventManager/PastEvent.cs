﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH01EventManager
{
    public class PastEvent : EventObject
    {
        private Int32 eventActualTurnout;
        public PastEvent(Int32 id, String name, LocationObject location, DateTime date, List<StaffObject>? staff, List<EquipmentObject>? eventEquipment, Int32 actual) : base(id, name, location, date, staff, eventEquipment)
        {
            this.eventActualTurnout = actual;
        } // PastEvent Constructor 
        public PastEvent(EventObject e, Int32 actual) : base(e.getEventID(), e.getEventName(), e.getEventLocation(), e.getEventDate(), e.getEventStaff(), e.getEventEquipment())
        {
            this.eventActualTurnout = actual;
        } // PastEvent Constructor from EventObject
        public Int32 getActualTurnout() { return this.eventActualTurnout; } // GetActualTurnout
        public void setActualTurnout(Int32 actual) { this.eventActualTurnout = actual; } // SetActualTurnout
    } // PastEvent Object
}
