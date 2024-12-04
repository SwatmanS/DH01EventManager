using System;
using System.Collections.Generic;
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
        
    }
    
}