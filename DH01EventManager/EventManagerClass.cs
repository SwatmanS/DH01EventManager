using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

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
        public Boolean completeEvent(EventObject e,Int32? actual)
        {
            DateTime eventDate = e.getEventDate();
            DateTime now = DateTime.Now;
            if (eventDate.Subtract(now).Days <= 0)
            {
                if (!DBAbstractionLayer.isPreviousEvent(e.getEventID()))
                {
                    if (actual == null)
                    {
                        UpcomingEvent Upcoming = DBAbstractionLayer.getUpcommingEventData(e.getEventID());
                        actual = Upcoming.getEstimatedTurnout();
                    }

                    DBAbstractionLayer.removeUpcomingEvent(e.getEventID());
                    
                    return DBAbstractionLayer.addPreviousEvent(e,-1,actual);
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
        
        public Int32 predictTurnout(Int32 impressions,Int32 impressionWeakness,EventObject e)
        {
            UpcomingEvent Upcoming = DBAbstractionLayer.getUpcommingEventData(e.getEventID());
            List<PastEvent> PastTurnouts = DBAbstractionLayer.getAllPreviousTurnoutsAtLocation(e.getEventLocation());
            float average = 0;
            for (int i = 0; i > PastTurnouts.Count;i++)
            {
                float weight = 1;
                average += PastTurnouts[i].getActualTurnout() * weight;
            }
            average = average / PastTurnouts.Count;
           
            Int32 currentEstimate = Upcoming.getEstimatedTurnout();
            
            float newEstimate = ((currentEstimate) + (impressionWeakness * impressions) + average)/3;
            
            Int32 newIntEst = (Int32)newEstimate;
            
            Upcoming.setEstimatedTurnout(newIntEst);
            
            DBAbstractionLayer.updateUpcomingEvent(Upcoming);
            
            return newIntEst;
        }

    }
    
}