using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DH01EventManager
{
    internal class DBAbstractionLayer
    {
        static DBConnection Con = new DBConnection();
        static string populateDB = "PRAGMA foreign_keys = 0;INSERT INTO ROSE_Login (Login_ID,Staff_ID,User_Name,Login_Password) VALUES (1,1,'User1','Rose1'),(2,2,'User2','Rose2'),(3,3,'User3','Rose3'),(4,4,'User4','Rose4');INSERT INTO ROSE_Staff (Staff_ID,Staff_Fname,Staff_Lname,Staff_position,Staff_PhoneNumber) VALUES (1,'George','Harrison','Event leader','07954500477'),(2,'John','Lennon','Manager','07954500627'),(3,'Paul','Mcartney','Assiant Manager','07954500657'),(4,'Richard','Starkey','Lab Tech','07954500677');INSERT INTO ROSE_AssignStaff (AssignStaff_ID,Staff_ID,Event_ID) VALUES (1,1,1),(2,2,2),(3,3,3),(4,4,4);	INSERT INTO ROSE_Location (Location_ID,Location_name,Location_address,Location_Capacity) VALUES (1,'Tynemouth Pool','Tynemouth Surf Cafe',30),(2,'Monument','Monument Statue',55),(3,'Cullercoats','Cullercoats beach',40),(4,'Heaton','Simonside Terrace',50);INSERT INTO ROSE_Event (Event_ID,Location_ID,Event_Name,Event_Date,Event_Duration) VALUES (1,1,'Cervical Screenings','09/12/2024 11:40:40',60),(2,2,'Cervical Screenings','09/12/2024 11:40:40',60),(3,3,'Cervical Screenings','09/12/2024 11:40:40',60),(4,4,'Cervical Screenings','09/12/2024 11:40:40',60);INSERT INTO ROSE_PastEvents(PastEvent_ID,Event_ID,Actual_Turnout) VALUES (1,1,100),(2,2,150),(3,3,130),(4,4,107);INSERT INTO ROSE_UpcomingEvents(NewEvent_ID,Event_ID,Predicted_Turnout) VALUES (1,1,150),(2,2,100),(3,3,125),(4,4,100);	INSERT INTO ROSE_EquipmentAssign(EquipmentAssign_ID,Event_ID,Equipment_ID) VALUES (1,1,1),(2,1,2),(3,2,2),(4,2,1);INSERT INTO ROSE_Equipment(Equipment_ID,Equipment_Name,Equipment_Description) VALUES (1,'Table','Wooden Table for leaflets'),(2,'Chair','Chair for sitting on');";
        static string schemaDB = "PRAGMA foreign_keys = 0;DROP TABLE IF EXISTS ROSE_Login;DROP TABLE IF EXISTS ROSE_Staff;DROP TABLE IF EXISTS ROSE_AssignStaff;DROP TABLE IF EXISTS ROSE_Location;DROP TABLE IF EXISTS ROSE_Event;DROP TABLE IF EXISTS ROSE_PastEvents;DROP TABLE IF EXISTS ROSE_UpcomingEvents;DROP TABLE IF EXISTS ROSE_EquipmentAssign;DROP TABLE IF EXISTS ROSE_Equipment;CREATE TABLE IF NOT EXISTS ROSE_Login(Login_ID INTEGER(32),Staff_ID INTEGER(32),User_Name TEXT,Login_Password TEXT,PRIMARY KEY(Login_ID),FOREIGN KEY(Staff_ID)REFERENCES  ROSE_Staff (Staff_ID));CREATE TABLE IF NOT EXISTS ROSE_Staff(Staff_ID INTEGER(32),Staff_Fname TEXT,Staff_Lname TEXT,Staff_position TEXT,Staff_PhoneNumber TEXT,\tPRIMARY KEY(Staff_ID));CREATE TABLE IF NOT EXISTS ROSE_AssignStaff(AssignStaff_ID INTEGER(32),Staff_ID INTEGER(32),Event_ID INTEGER(32),PRIMARY KEY(AssignStaff_ID),FOREIGN KEY (Staff_ID) REFERENCES  ROSE_Staff (Staff_ID)\tFOREIGN KEY(Event_ID) REFERENCES  ROSE_Event (Event_ID));CREATE TABLE IF NOT EXISTS ROSE_Location(Location_ID INTEGER(32),Location_Name CHAR(6),Location_Address CHAR(6),Location_Capacity INTEGER(32),PRIMARY KEY(Location_ID));CREATE TABLE IF NOT EXISTS ROSE_Event(Event_ID INTEGER(32),Location_ID INTEGER(32),Event_Name TEXT,Event_Date CHAR(23),Event_Duration INTEGER(32),PRIMARY KEY(Event_ID),FOREIGN KEY (Location_ID) REFERENCES  ROSE_Location (Location_ID));CREATE TABLE IF NOT EXISTS ROSE_PastEvents(PastEvent_ID INTEGER(32),Event_ID INTEGER(32),Actual_Turnout INTEGER,PRIMARY KEY(PastEvent_ID),\tFOREIGN KEY(Event_ID) REFERENCES  ROSE_Event (Event_ID));CREATE TABLE IF NOT EXISTS ROSE_UpcomingEvents(NewEvent_ID INTEGER(32),Event_ID INTEGER(32),Predicted_Turnout INTEGER(32),PRIMARY KEY(NewEvent_ID),FOREIGN KEY(Event_ID) REFERENCES  ROSE_Event (Event_ID));CREATE TABLE IF NOT EXISTS ROSE_EquipmentAssign(EquipmentAssign_ID INTEGER(32),Event_ID INTEGER(32),Equipment_ID INTEGER(32),PRIMARY KEY(EquipmentAssign_ID),FOREIGN KEY(Event_ID) REFERENCES  ROSE_Event (Event_ID) FOREIGN KEY(Equipment_ID) REFERENCES  ROSE_Equipment (Equipment_ID));CREATE TABLE IF NOT EXISTS ROSE_Equipment(Equipment_ID INTEGER(32),Equipment_Name TEXT,Equipment_Description TEXT,PRIMARY KEY(Equipment_ID));";
        //---------------------------------------Basic Methods

        //-----------------------------------------------Utils
        public static void connect()
        {
            Con.dbConnect("Database/Rose_Database.db");
        }//Connect
        public static void disconnect()
        {
            Con.dbDisconnect();
        }//Disconnect
        public static void reset()
        {
            bool exists = System.IO.Directory.Exists("/Database/");

            if (!exists)
                System.IO.Directory.CreateDirectory("./Database/");
            Con.dbConnect("Database/Rose_Database.db");
            
            Con.runSQL(DBAbstractionLayer.schemaDB);
            Con.runSQL(DBAbstractionLayer.populateDB);
            Con.dbDisconnect();

        }//ResetDB
        public static Boolean getStatus()
        {
            return Con.dbConnected();
        }//getDBStatus

        public static void ensureStatus()
        {
            while (!DBAbstractionLayer.getStatus())
            {
                DBAbstractionLayer.connect();
            }
        }

        //  OWEN TODO 
        public static List<EventObject>? getAllEvents()
        { 
            List<EventObject> l = new List<EventObject>();
            SQLiteDataReader? qResults = Con.querySQL("SELECT * From  ROSE_Event;");
            while (qResults.Read())
            {
                l.Add(new EventObject(qResults.GetInt32(0),
                                      qResults.GetString(2),
                                      DBAbstractionLayer.getAssociatedLocation(qResults.GetInt32(1)),
                                      DateTime.Parse(qResults.GetString(3)),
                                      qResults.GetInt32(4),
                                      DBAbstractionLayer.getAssociatedStaff(qResults.GetInt32(0)),
                                      DBAbstractionLayer.getAssociatedEquipment(qResults.GetInt32(0))
                                      ));
            }

            return l;
        }

        public static List<EquipmentObject>? getAssociatedEquipment(Int32 EventID)
        {
            List<EquipmentObject> l = new List<EquipmentObject>();
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From  ROSE_EquipmentAssign INNER JOIN Rose_Equipment ON Rose_Equipment.Equipment_ID = Rose_EquipmentAssign.Equipment_ID AND (ROSE_EquipmentAssign.Event_ID = {EventID});");
            while (qResults.Read())
            {
                
                l.Add(new EquipmentObject(qResults.GetInt32(3), qResults.GetString(4), qResults.GetString(5)));
            }
            return l;
        }

        public static List<StaffObject>? getAssociatedStaff(Int32 EventID)
        {
            List<StaffObject> l = new List<StaffObject>();
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From  ROSE_AssignStaff INNER JOIN Rose_Staff ON Rose_Staff.Staff_ID = ROSE_AssignStaff.Staff_ID  AND (ROSE_AssignStaff.Event_ID = {EventID});");
            while (qResults.Read())
            {

                l.Add(new StaffObject(qResults.GetInt32(3), qResults.GetString(4), qResults.GetString(5), qResults.GetString(6), qResults.GetString(7)));
            }
            return l;
        }

        public static LocationObject getAssociatedLocation(Int32 LocationID)
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

        public static EventObject getEventByID(Int32 EventID)
        {
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From  ROSE_Event WHERE Event_ID = {EventID};");
            if (qResults.Read()) // (Event_ID,Location_ID,Event_Name,Event_Date,Event_Duration)
            {
                return new EventObject(qResults.GetInt32(0),
                                   qResults.GetString(2),
                                   DBAbstractionLayer.getAssociatedLocation(qResults.GetInt32(1)),
                                   DateTime.Parse(qResults.GetString(3)),
                                   qResults.GetInt32(4),
                                   DBAbstractionLayer.getAssociatedStaff(qResults.GetInt32(0)),
                                   DBAbstractionLayer.getAssociatedEquipment(qResults.GetInt32(0))
                                   ); ; ; ; ;
            }
            return new EventObject(EventID,
                                   "Unknown Event",
                                   new LocationObject(-1, "Missing Location Please Add", "Unknown", 0),
                                   new DateTime(), 0, null, null);
            
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
            List<UserObject> l = new List<UserObject>();
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From ROSE_Login");
            while (qResults.Read())
            {

                l.Add(new UserObject(qResults.GetString(2),qResults.GetString(3)));
            }
            return l;
        }
        internal static Boolean addNewEvent(EventObject e)
        {
            /*
             * Returns True If Written to DB
             */
            DBAbstractionLayer.ensureStatus();
            if (!DBAbstractionLayer.validStaffCheck(e.getEventStaff()))
            {
                return false;
            }
            else if (!DBAbstractionLayer.validLocationCheck(e.getEventLocation()))
            {
                return false;
            }
            else if (!DBAbstractionLayer.validEquipmentCheck(e.getEventEquipment()))
            {
                return false;
            }
            else if (!DBAbstractionLayer.isNewEventID(e.getEventID()))
            {
                return false;
            }
            
            Boolean a = Con.runSQL($"PRAGMA foreign_keys = 0; INSERT INTO ROSE_Event (Event_ID,Location_ID,Event_Name,Event_Date,Event_Duration) VALUES ({e.getEventID()},{e.getEventLocation().getLocationID()},'{e.getEventName()}','{e.getEventDate()}',{e.getEventDuration()});");
            Boolean b = DBAbstractionLayer.AssignEquipment(e.getEventEquipment(),e.getEventID());
            Boolean c = DBAbstractionLayer.AssignStaff(e.getEventStaff(),e.getEventID());
            return (a)&&(b)&&(c);
        }

        public static bool AssignStaff(List<StaffObject> staffObjects,Int32 EventID)
        {
            DBAbstractionLayer.ensureStatus();
            Boolean check = true;
            foreach (StaffObject s in staffObjects)
            {
                check = check && Con.runSQL($"PRAGMA foreign_keys = 0;INSERT INTO ROSE_EquipmentAssign(EquipmentAssign_ID,Event_ID,Equipment_ID) VALUES ({DBAbstractionLayer.getNewStaffAssignID()},{EventID},{s.getStaffID()});");
            }
            return check;
    }


        public static bool AssignEquipment(List<EquipmentObject>? equipmentObjects,Int32 EventID)
        {
            DBAbstractionLayer.ensureStatus();
            Boolean check = true;
            foreach (EquipmentObject q in equipmentObjects)
            {
                check = check && Con.runSQL($"PRAGMA foreign_keys = 0;INSERT INTO ROSE_EquipmentAssign(EquipmentAssign_ID,Event_ID,Equipment_ID) VALUES ({DBAbstractionLayer.getNewEquipmentAssignID()},{EventID},{q.getEquipmentID()});");
            }
            return check;
        }

        public static object getNewEquipmentAssignID()
        {
            List<Int32> l = new List<Int32>();
            SQLiteDataReader? qResults = Con.querySQL($"SELECT EquipmentAssign_ID FROM ROSE_EquipmentAssign;");
            while (qResults.Read())
            {
                l.Add(qResults.GetInt32(0));
            }
            Int32 Mx = l.Max() + 1;
            return Mx;
        }

        public static bool isValidDate(String d)
        {
            try
                
            {
                DateTime.Parse(d);
                return true;
            }
            catch (Exception e) 
            {
                return false;
            }
        }

        public static Boolean isNewEventID(Int32 EventID)
        {
            SQLiteDataReader? qResults = Con.querySQL($"SELECT EquipmentAssign_ID FROM ROSE_EquipmentAssign;");
            while (qResults.Read())
            {
                if (EventID == qResults.GetInt32(0))
                {
                    return true;
                }
            }
            
            return true;
        }
        public static Int32 getNewStaffAssignID()
        {
            List<Int32> l = new List<Int32>();
            SQLiteDataReader? qResults = Con.querySQL($"SELECT AssignStaff_ID FROM ROSE_AssignStaff;");
            while (qResults.Read())
            {
                l.Add(qResults.GetInt32(0));
            }
            Int32 Mx = l.Max() + 1;
            return Mx;
        }

        public static Boolean validEquipmentCheck(List<EquipmentObject>? equipmentObjects)
        {
            foreach (EquipmentObject q in equipmentObjects)
            {
                // Test ID
                if (null != Con.querySQL($"SELECT * FROM ROSE_Equipment WHERE Equipment_ID = {q.getEquipmentID()};"))
                {
                    return false;
                }
            }
            return true;
        }

        public static Boolean validLocationCheck(LocationObject locationObject)
        {
            // Test ID
            if (null != Con.querySQL($"SELECT * FROM ROSE_Equipment WHERE Equipment_ID = {locationObject.getLocationID()};"))
            {
                return false;
            }
            return true;
        }

        public static Boolean validStaffCheck(List<StaffObject>? staffObjects)
        {
            foreach (StaffObject s in staffObjects)
            {
                // Test ID
                if (null != Con.querySQL($"SELECT * FROM ROSE_Staff WHERE Staff_ID = {s.getStaffID()};"))
                {
                    return false;
                }
            }
            return true;
        }
        // could there be a way to get the information for a location, staff, and equipment from the name
        // And then do the same thing for staff and equipment
        // I also need to be able to update an event
        
        public static Int32 getLocationIDByName(String Name)
        {
            SQLiteDataReader? qResults = Con.querySQL($"SELECT Location_ID From  ROSE_Location WHERE Location_Name = '{Name}';");
            if (qResults.Read()) // (Event_ID,Location_ID,Event_Name,Event_Date,Event_Duration)
            {
                return qResults.GetInt32(0);
            }
            return -1;

        }
        public static Int32 getEventIDByName(String Name)
        {
            SQLiteDataReader? qResults = Con.querySQL($"SELECT Event_ID From  ROSE_Event WHERE Event_Name = '{Name}';");
            if (qResults.Read()) // (Event_ID,Location_ID,Event_Name,Event_Date,Event_Duration)
            {
                return qResults.GetInt32(0);
            }
            return -1;

        }




    }// DBAbstractionLayer
}
