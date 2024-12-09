﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DH01EventManager
{
    internal class DBAbstractionLayer
    {
        static DBConnection Con = new DBConnection();
        //---------------------------------------Basic Methods

        //-----------------------------------------------Utils
        public static void connect()
        {
            Con.dbConnect("Database/Placeholder.db");
        }//Connect
        public static void disconnect()
        {
            Con.dbDisconnect();
        }//Disconnect
        public static void reset()
        {
            Con.dbConnect("Database/Placeholder.db");
            string schema = File.ReadAllText("Database/Placeholder.db.sql");
            Con.runSQL(schema);
            Con.dbDisconnect();

        }//ResetDB
        public static Boolean getStatus()
        {
            return Con.dbConnected();
        }//getDBStatus


        //  OWEN TODO 
        public static List<EventObject>? getAllEvents()
        { 
            List<EventObject> l = new List<EventObject>();
            SQLiteDataReader? qResults = Con.querySQL("SELECT * From  ROSE_Event;");
            while (qResults.Read())
            {
                l.Add(new EventObject(qResults.GetInt32(0),
                                      qResults.GetString(1),
                                      DBAbstractionLayer.getAssociatedLocation(qResults.GetInt32(2)),
                                      DateTime.Parse(qResults.GetString(3)),
                                      DBAbstractionLayer.getAssociatedStaff(qResults.GetInt32(0)),
                                      DBAbstractionLayer.getAssociatedEquipment(qResults.GetInt32(0))
                                      ));
            }

            return l;
        }

        private static List<EquipmentObject>? getAssociatedEquipment(Int32 EventID)
        {
            List<EquipmentObject> l = new List<EquipmentObject>();
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From  ROSE_EquipmentAssign WHERE Event_ID = {EventID} LEFT JOIN Rose_Equipment ON Rose_Equipment.Equipment_ID = Rose_EquipmentAssign.Equipment_ID;");
            while (qResults.Read())
            {
                
                l.Add(new EquipmentObject(qResults.GetInt32(0), qResults.GetString(1), qResults.GetString(2)));
            }
            return l;
        }

        private static List<StaffObject>? getAssociatedStaff(Int32 EventID)
        {
            List<StaffObject> l = new List<StaffObject>();
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From  ROSE_AssignStaff WHERE Event_ID = {EventID} LEFT JOIN Rose_Staff ON Rose_Staff.Staff_ID = ROSE_AssignStaff.Staff_ID;");
            while (qResults.Read())
            {

                l.Add(new StaffObject(qResults.GetInt32(0), qResults.GetString(1), qResults.GetString(2), qResults.GetString(3), qResults.GetString(4)));
            }
            return l;
        }

        private static LocationObject getAssociatedLocation(Int32 LocationID)
        {
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From  ROSE_Location WHERE Location_ID = {LocationID};");
            if (!qResults.Read())
            {
                return new LocationObject(LocationID, "Missing Location Please Add", "Unknown", 0);
            }
            return new LocationObject(LocationID, qResults.GetString(1), qResults.GetString(2), qResults.GetInt32(3));
        }

        public static bool isPreviousEvent(Int32 eventID)
        {
            /*
             *  Checks DB if there is an entry in the previous event table at eventID
             */
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From  ROSE_PastEvents WHERE Event_ID = {eventID};");
            if (!qResults.Read())
            {
                return false;
            }
            return true;
        }

        public static void removeUpcomingEvent(Int32 eventID)
        {
            /*
             *  Delets an upcominng event row at where = eventID
             */
            Con.runSQL($"DELETE * FROM Rose_UpcomingEvents Where Event_ID = {eventID};");
        }

        public static Boolean addPreviousEvent(EventObject e, Int32 ActualTurnout)
        {
            /*
             *  Creates a new previous event **CHECK IF ONE EXISTS FIRST**
             */
            List<Int32> l = new List<Int32>();
            SQLiteDataReader? qResults = Con.querySQL($"SELECT PastEvent_ID FROM Rose_PastEvents;");
            while (qResults.Read())
            {
                l.Add(qResults.GetInt32(0));
            }
            Int32 Mx = l.Max() + 1;
            Con.querySQL($"INSERT INTO Rose_PastEvents (PastEvent_ID,Event_ID,Actual_Turnout) VALUES ({Mx},{e.getEventID()},{ActualTurnout});");
            return true;
        }

        internal static List<UpcomingEvent>? getUpcomingEvents()
        {
            /*
             *  Gets all upcoming events from the upcoming events table
             */
            List<UpcomingEvent> l = new List<UpcomingEvent>();
            EventObject e;
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * FROM Rose_UpcomingEvents;");
            while (qResults.Read())
            {
                e = DBAbstractionLayer.getEventByID(qResults.GetInt32(1));
                l.Add(new UpcomingEvent(e,qResults.GetInt32(2)));
            }
            return l;

        }

        private static EventObject getEventByID(Int32 EventID)
        {
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From  ROSE_Event WHERE Event_ID = {EventID};");
            if (!qResults.Read())
            {
                return new EventObject(EventID,
                                   "Unknown Event",
                                   new LocationObject(-1, "Missing Location Please Add", "Unknown", 0),
                                   new DateTime(),null,null);
            }
            return new EventObject(qResults.GetInt32(0),
                                   qResults.GetString(1),
                                   DBAbstractionLayer.getAssociatedLocation(qResults.GetInt32(2)),
                                   DateTime.Parse(qResults.GetString(3)),
                                   DBAbstractionLayer.getAssociatedStaff(qResults.GetInt32(0)),
                                   DBAbstractionLayer.getAssociatedEquipment(qResults.GetInt32(0))
                                   );
        }

        internal static List<PastEvent>? getPreviousEvents()
        {
            /*
             *  Gets all Past events from the past events table
             */

            List<PastEvent> l = new List<PastEvent>();
            EventObject e;
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * FROM Rose_PastEvents;");
            while (qResults.Read())
            {
                e = DBAbstractionLayer.getEventByID(qResults.GetInt32(1));
                l.Add(new PastEvent(e, qResults.GetInt32(2)));
            }
            return l;
        }

        internal static UpcomingEvent getUpcommingEventData(Int32 EventID)
        {
            UpcomingEvent Up;
            
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From  ROSE_UpcomingEvents WHERE Event_ID = {EventID};");
            EventObject e;
            if (qResults.Read()) 
            {
                e = DBAbstractionLayer.getEventByID(qResults.GetInt32(1));
                Up = new UpcomingEvent(e, qResults.GetInt32(2));
                return Up;
            }
            e = DBAbstractionLayer.getEventByID(qResults.GetInt32(1));
            return new UpcomingEvent(e,e.getEventLocation().getLocationCapacity());


        }

        internal static List<PastEvent>? getAllPreviousTurnoutsAtLocation(LocationObject Location)
        {
            /*
             *  Using the given location retrieves a list of previous turnouts
             *  
             */
            List<PastEvent> l = new List<PastEvent>();
            
            EventObject e;
            SQLiteDataReader? qResults = Con.querySQL($" SELECT Rose_PastEvents.* FROM Rose_Event JOIN Rose_PastEvents ON Rose_PastEvents.Event_ID = Rose_Event.Event_ID AND (Rose_Event.Location_ID = {Location.getLocationID()});");
            while (qResults.Read())
            {
                e = DBAbstractionLayer.getEventByID(qResults.GetInt32(1));
                l.Add(new PastEvent(e, qResults.GetInt32(2)));
            }
            return l;


        }

        internal static void updateUpcomingEvent(UpcomingEvent upcoming)
        {
            Con.runSQL($"UPDATE Rose_UpcomingEvent SET Event_ID = {upcoming.getEventID()},Predicted_Turnout = {upcoming.getEstimatedTurnout()} WHERE NewEvent_ID = {upcoming.getEventID()};");
        }

        internal static List<UserObject> getAllUsers()
        {
            throw new NotImplementedException();
        }
    }// DBAbstractionLayer
}
