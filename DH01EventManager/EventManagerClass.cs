using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH01EventManager
{
    internal class EventManagerClass
    {
        private List<UpcomingEvent>? UpcomingEventList;
        private List<PastEvent>? PreviousEventList;
        private List<EventObject>? FullEventList;
        public EventManagerClass()
        {
            this.FullEventList = DBAbstractionLayer.getAllEvents();
            this.PreviousEventList = new List<PastEvent>();
            this.UpcomingEventList = new List<UpcomingEvent>();
        }
        public List<PastEvent>? getPreviousEventList()
        {
            return this.PreviousEventList;
        }
        public List<UpcomingEvent>? getUpcomingEventList()
        {
            return this.UpcomingEventList;
        }
        public void addEventToUList(UpcomingEvent e)
        {
            UpcomingEventList.Add(e);
        }
        public void addEventToPList(PastEvent e)
        {
            PreviousEventList.Add(e);
        }
        public Boolean completeEvent(EventObject e)
        {
            DateTime eventDate = e.getEventDate();
            DateTime now = DateTime.Now;
            if (eventDate.Subtract(now).Days <= 0)
            {
                if (!DBAbstractionLayer.isPreviousEvent(e.getEventID()))
                {
                    DBAbstractionLayer.removeUpcomingEvent(e.getEventID());
                    
                    return DBAbstractionLayer.addPreviousEvent(e,-1);
                }
                
            }
            return false;
        }
        public Boolean updateEventLists()
        {
            while (!DBAbstractionLayer.getStatus())
            {
                DBAbstractionLayer.connect();
            }
            this.FullEventList = DBAbstractionLayer.getAllEvents();
            this.UpcomingEventList = DBAbstractionLayer.getUpcomingEvents();
            this.PreviousEventList = DBAbstractionLayer.getPreviousEvents();
            // If any of these are null the formula below will return 0  or FALSE
            return (this.FullEventList!=null) && (this.UpcomingEventList !=null) && (this.PreviousEventList!=null);
        }
        
    }
    
}