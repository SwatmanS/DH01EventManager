using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
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
            throw new NotImplementedException();
            /*
            List<EventObject> l = new List<EventObject>();
            SQLiteDataReader? qResults = Con.querySQL("SELECT * From  ROSE_Event;");
            while (qResults.Read())
            {
                l.Add(new EventObject(qResults.GetInt32(0),
                                      qResults.GetString(1),
                                      DBAbstractionLayer.getAssociatedLocation(qResults.GetInt32(2)),
                                      DateTime.Parse(qResults.GetString(3)),
                                      DBAbstractionLayer.getAssociatedStaff(qResults.GetInt32(4),
                                      )));
            }

            return l;
        */}

        private static LocationObject getAssociatedStaff(int v)
        {
            throw new NotImplementedException();
        }

        public static bool isPreviousEvent(Int32 eventID)
        {
            /*
             *  Checks DB if there is an entry in the previous event table at eventID
             */
            return true;
        }

        public static void removeUpcomingEvent(Int32 eventID)
        {
            /*
             *  Delets an upcominng event row at where = eventID
             */
            throw new NotImplementedException();
        }

        public static Boolean addPreviousEvent(EventObject e, Int32 ActualTurnout, Int32? actual)
        {
            /*
             *  Creates a new previous event **CHECK IF ONE EXISTS FIRST**
             */
            return true;
            //throw new NotImplementedException();
        }

        internal static List<UpcomingEvent>? getUpcomingEvents()
        {
            /*
             *  Gets all upcoming events from the upcoming events table
             */

            //

            //    DUMMY DATA BELOW
            LocationObject testLoc = new LocationObject(0, "Location Name", "1 Null Avenue, AA1 1XD", 60);
            DateTime d = DateTime.Now;
            StaffObject member1 = new StaffObject(0, "0Foo", "Bar", "+44 1234 123 123", "CEO");
            StaffObject member2 = new StaffObject(1, "1Foo", "Bar", "+44 2234 123 123", "Manager");

            EquipmentObject kit1 = new EquipmentObject(0, "Table", "Its a Table", 1);
            EquipmentObject kit2 = new EquipmentObject(1, "Chair", "Its a Chair", 1);

            List<EquipmentObject> kitList = [kit1, kit2];
            List<StaffObject> staffList = [member1, member2];
            List<UpcomingEvent> eventsList = new List<UpcomingEvent>();
            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(new UpcomingEvent(i, String.Concat("Event", i), testLoc, d.AddDays(i * 2), staffList, kitList,50+i));
            }
            return eventsList;
        }

        internal static List<PastEvent>? getPreviousEvents()
        {
            /*
             *  Gets all Past events from the upcoming events table
             */

            //

            //    DUMMY DATA BELOW
            LocationObject testLoc = new LocationObject(0, "Location Name", "1 Null Avenue, AA1 1XD", 60);
            DateTime d = DateTime.Now;
            StaffObject member1 = new StaffObject(0, "0Foo", "Bar", "+44 1234 123 123", "CEO");
            StaffObject member2 = new StaffObject(1, "1Foo", "Bar", "+44 2234 123 123", "Manager");

            EquipmentObject kit1 = new EquipmentObject(0, "Table", "Its a Table", 1);
            EquipmentObject kit2 = new EquipmentObject(1, "Chair", "Its a Chair", 1);

            List<EquipmentObject> kitList = [kit1, kit2];
            List<StaffObject> staffList = [member1, member2];
            List<PastEvent> eventsList = new List<PastEvent>();
            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(new PastEvent(i, String.Concat("Event", i), testLoc, d.AddDays(i * 2), staffList, kitList, 50 + i));
            }
            return eventsList;
        }

        internal static UpcomingEvent getUpcommingEventData(int EventID)
        {
            LocationObject testLoc = new LocationObject(0, "Location Name", "1 Null Avenue, AA1 1XD", 60);
            DateTime d = DateTime.Now;
            StaffObject member1 = new StaffObject(0, "0Foo", "Bar", "+44 1234 123 123", "CEO");
            StaffObject member2 = new StaffObject(1, "1Foo", "Bar", "+44 2234 123 123", "Manager");

            EquipmentObject kit1 = new EquipmentObject(0, "Table", "Its a Table", 1);
            EquipmentObject kit2 = new EquipmentObject(1, "Chair", "Its a Chair", 1);

            List<EquipmentObject> kitList = [kit1, kit2];
            List<StaffObject> staffList = [member1, member2];
            List<PastEvent> eventsList = new List<PastEvent>();

            return new UpcomingEvent(0, String.Concat("Event", 0), testLoc, d.AddDays(2), staffList, kitList, 50);

            //throw new NotImplementedException();
        }

        internal static List<PastEvent> getAllPreviousTurnoutsAtLocation(LocationObject Location)
        {
            /*
             *  Using the given location retrieves a list of previous turnouts
             *  Sorted with recent dates at a lower index
             */
            //    DUMMY DATA BELOW
            DateTime d = DateTime.Now;
            StaffObject member1 = new StaffObject(0, "0Foo", "Bar", "+44 1234 123 123", "CEO");
            StaffObject member2 = new StaffObject(1, "1Foo", "Bar", "+44 2234 123 123", "Manager");

            EquipmentObject kit1 = new EquipmentObject(0, "Table", "Its a Table", 1);
            EquipmentObject kit2 = new EquipmentObject(1, "Chair", "Its a Chair", 1);

            List<EquipmentObject> kitList = [kit1, kit2];
            List<StaffObject> staffList = [member1, member2];
            List<PastEvent> eventsList = new List<PastEvent>();
            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(new PastEvent(i, String.Concat("Event", i), Location, d.AddDays(i * 2), staffList, kitList, 50 + i));
            }
            return eventsList;
            throw new NotImplementedException();
        }

        internal static void updateUpcomingEvent(UpcomingEvent upcoming)
        {
            //throw new NotImplementedException();
        }
    }// DBAbstractionLayer
}
