using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DH01EventManager
{
    internal class DBAbstractionLayer
    {
        static DBConnection Con = new DBConnection();
        static string testpopulateDB = "PRAGMA foreign_keys = 0;INSERT INTO ROSE_Login (Login_ID,Staff_ID,User_Name,Login_Password) VALUES (1,1,'User1','Rose1'),(2,2,'User2','Rose2'),(3,3,'User3','Rose3'),(4,4,'User4','Rose4');INSERT INTO ROSE_Staff (Staff_ID,Staff_Fname,Staff_Lname,Staff_position,Staff_PhoneNumber) VALUES (1,'George','Harrison','Event leader','07954500477'),(2,'John','Lennon','Manager','07954500627'),(3,'Paul','Mcartney','Assiant Manager','07954500657'),(4,'Richard','Starkey','Lab Tech','07954500677');INSERT INTO ROSE_AssignStaff (AssignStaff_ID,Staff_ID,Event_ID) VALUES (1,1,1),(2,2,2),(3,3,3),(4,4,4);	INSERT INTO ROSE_Location (Location_ID,Location_name,Location_address,Location_Capacity) VALUES (1,'Tynemouth Pool','Tynemouth Surf Cafe',30),(2,'Monument','Monument Statue',55),(3,'Cullercoats','Cullercoats beach',40),(4,'Heaton','Simonside Terrace',50);INSERT INTO ROSE_Event (Event_ID,Location_ID,Event_Name,Event_Date,Event_Duration) VALUES (1,1,'Cervical Screenings','09/12/2024 11:40:40',60),(2,2,'Cervical Screenings','09/12/2024 11:40:40',60),(3,3,'Cervical Screenings','09/12/2024 11:40:40',60),(4,4,'Cervical Screenings','09/12/2024 11:40:40',60);INSERT INTO ROSE_PastEvents(PastEvent_ID,Event_ID,Actual_Turnout) VALUES (1,1,100),(2,2,150),(3,3,130),(4,4,107);INSERT INTO ROSE_UpcomingEvents(NewEvent_ID,Event_ID,Predicted_Turnout) VALUES (1,1,150),(2,2,100),(3,3,125),(4,4,100);	INSERT INTO ROSE_EquipmentAssign(EquipmentAssign_ID,Event_ID,Equipment_ID) VALUES (1,1,1),(2,1,2),(3,2,2),(4,2,1);INSERT INTO ROSE_Equipment(Equipment_ID,Equipment_Name,Equipment_Description) VALUES (1,'Table','Wooden Table for leaflets'),(2,'Chair','Chair for sitting on');";
        static string populateDB = "PRAGMA foreign_keys = 0;INSERT INTO ROSE_Login (Login_ID,Staff_ID,User_Name,Login_Password) VALUES  (1,1,'User1','Rose1'),(2,2,'User2','Rose2'),(3,3,'User3','Rose3'),(4,4,'User4','Rose4');INSERT INTO ROSE_Staff (Staff_ID,Staff_Fname,Staff_Lname,Staff_position,Staff_PhoneNumber) VALUES (1, 'Aishah', 'Mayang','Manager','+60 4545 989090'),(2, 'Aishah', 'Shah','Manager','+60 4545 989090'),(3, 'Alya', 'Tiara','Manager','+60 4545 989090'),(4, 'Alya', 'Wira','Volunteer','+60 4545 989090'),(5, 'Amani', 'Wati','Volunteer','+60 4545 989090'),(6, 'Amani', 'Wira','Volunteer','+60 4545 989090'),(7, 'Ammar', 'Raja','Volunteer','+60 4545 989090'),(8, 'Arissa', 'Tam','Volunteer','+60 4545 989090'),(9, 'Ashraff', 'Tengku','Volunteer','+60 4545 989090'),(10, 'Balqis', 'Darma','Volunteer','+60 4545 989090'),(11, 'Batrisyia', 'Orked','Volunteer','+60 4545 989090'),(12, 'Damia', 'Jehan','Volunteer','+60 4545 989090'),(13, 'Damia', 'Mayang' ,'Volunteer','+60 4545 989090'),(14, 'Hadif', 'Tuah','Volunteer','+60 4545 989090'),(15, 'Hakim', 'Ros','Volunteer','+60 4545 989090'),(16, 'Haziq', 'Som','Volunteer','+60 4545 989090'),(17, 'Humaira', 'Jehan','Volunteer','+60 4545 989090'),(18, 'Irfan', 'Kesuma','Volunteer','+60 4545 989090'),(19, 'Keisha', 'Joyo','Volunteer','+60 4545 989090'),(20, 'Mia', 'Kiambang','Volunteer','+60 4545 989090'),(21, 'Noor', 'Lai','Volunteer','+60 4545 989090'),(22, 'Qaisara', 'Mayang','Volunteer','+60 4545 989090'),(23, 'Qistina', 'Mirza','Volunteer','+60 4545 989090'),(24, 'Rayyan', 'Kesuma','Volunteer','+60 4545 989090'),(25, 'Syshmi', 'Megat','Volunteer','+60 4545 989090'),(26, 'Zara', 'Shah','Volunteer','+60 4545 989090');INSERT INTO ROSE_Equipment(Equipment_ID,Equipment_Name,Equipment_Description) VALUES (1,'tables','Wooden Table for leaflets'),(2,'Chairs','Chair for sitting'),(3,'stuff','some generic helpful stuff'),(4,'stuff2','some generic helpful stuff'),(5,'stuff3','some generic helpful stuff'),(6,'stuff4','some generic helpful stuff'),(7,'stuff5','some generic helpful stuff'),(8,'stuff6','some generic helpful stuff'),(9,'stuff7','some generic helpful stuff'),(10,'stuff8','some generic helpful stuff'),(11,'stuff9','some generic helpful stuff'),(12,'stuff10','some generic helpful stuff');INSERT INTO ROSE_Location (Location_ID,Location_name,Location_address,Location_Capacity) VALUES (1,'Bangsar South Medical Clinic','Malaysia',50),(2,'Klinik Primary Care 4U','Malaysia',50),(3,'BeHealth Clinic','Malaysia',50),(4,'Perdana Medical Clinic','Malaysia',50),(5,'Klinik Dr.Prevents','Malaysia',50),(6,'Medhope Family Clinic','Malaysia',50),(7,'Qualitas SV Care Clinic','Malaysia',50),(8,'Wellcare Clinic','Malaysia',50),(9,'Klinik Mediviron Metropark','Malaysia',50),(10,'Klinik Primaria','Malaysia',50),(11,'Klinik Family E-Medic','Malaysia',50),(12,'Klinik Careclinics Al-Amin','Malaysia',50),(13,'My Family Clinic','Malaysia',50),(14,'REN.CLINIC','Malaysia',50),(15,'RIIYYAH MEDICAL CLINIC','Malaysia',50),(16,'Muthus Clinic and Surgery','Malaysia',50),(17,'X Care Clinic','Malaysia',50),(18,'Family Clinic Seventeen','Malaysia',50),(19,'SV Care Clinic','Malaysia',50),(20,'Emerald Clinic Rawang','Malaysia',50),(21,'Nlee Family Clinic','Malaysia',50),(22,'MCare Clinic','Malaysia',50),(23,'TMC Health Centre','Malaysia',50),(24,'Clinic Medi-Genesis','Malaysia',50),(25,'One Med Clinic','Malaysia',50),(26, 'Medizone Family Clinic','Malaysia',50);INSERT INTO ROSE_Event (Event_ID,Location_ID,Event_Name,Event_Date,Event_Duration) VALUES (1,1,'Cervical Screenings','20/12/2024 11:30:00',60),(2,2,'Cervical Screenings','21/12/2024 11:30:00',60),(3,1,'Cervical Screenings','22/12/2024 11:30:00',60),(4,4,'Cervical Screenings','23/12/2024 11:30:00',60),(5,10,'Cervical Screenings','23/12/2024 11:30:00',60),(6,10,'Cervical Screenings','16/12/2024 11:30:00',60);INSERT INTO ROSE_AssignStaff (AssignStaff_ID,Staff_ID,Event_ID) VALUES (1,1,1),(2,2,1),(3,3,1),(4,4,1),(5,1,2),(6,5,2),(7,6,2),(8,7,2),(9,2,3),(10,8,3),(11,9,3),(12,10,3),(13,11,4),(14,3,4),(15,12,4),(16,13,4),(17,2,5),(18,14,5),(19,15,5),(20,16,5),(21,2,6),(22,14,6),(23,15,6),(24,16,6);INSERT INTO ROSE_EquipmentAssign(EquipmentAssign_ID,Event_ID,Equipment_ID) VALUES (1,1,1),(2,1,2),(3,1,3),(4,1,4),(5,2,1),(6,2,2),(7,2,6),(8,2,7),(9,3,1),(10,3,2),(11,3,7),(12,3,4),(13,4,7),(14,4,2),(15,4,4),(16,4,9),(17,5,1),(18,5,10),(19,5,3),(20,5,8),(21,6,1),(22,6,10),(23,6,3),(24,6,8);INSERT INTO ROSE_PastEvents(PastEvent_ID,Event_ID,Actual_Turnout) VALUES (1,6,46);INSERT INTO ROSE_UpcomingEvents(NewEvent_ID,Event_ID,Predicted_Turnout) VALUES(1,1,19),(2,2,35),(3,3,60),(4,4,20),(5,5,46);";
        static string schemaDB = "PRAGMA foreign_keys = 0;DROP TABLE IF EXISTS ROSE_Login;DROP TABLE IF EXISTS ROSE_Staff;DROP TABLE IF EXISTS ROSE_AssignStaff;DROP TABLE IF EXISTS ROSE_Location;DROP TABLE IF EXISTS ROSE_Event;DROP TABLE IF EXISTS ROSE_PastEvents;DROP TABLE IF EXISTS ROSE_UpcomingEvents;DROP TABLE IF EXISTS ROSE_EquipmentAssign;DROP TABLE IF EXISTS ROSE_Equipment;CREATE TABLE IF NOT EXISTS ROSE_Login(Login_ID INTEGER(32),Staff_ID INTEGER(32),User_Name TEXT,Login_Password TEXT,PRIMARY KEY(Login_ID));CREATE TABLE IF NOT EXISTS ROSE_Staff(Staff_ID INTEGER(32),Staff_Fname TEXT,Staff_Lname TEXT,Staff_position TEXT,Staff_PhoneNumber TEXT,PRIMARY KEY(Staff_ID));CREATE TABLE IF NOT EXISTS ROSE_AssignStaff(AssignStaff_ID INTEGER(32),Staff_ID INTEGER(32),Event_ID INTEGER(32),PRIMARY KEY(AssignStaff_ID));CREATE TABLE IF NOT EXISTS ROSE_Location(Location_ID INTEGER(32),Location_Name CHAR(6),Location_Address CHAR(6),Location_Capacity INTEGER(32),PRIMARY KEY(Location_ID));CREATE TABLE IF NOT EXISTS ROSE_Event(Event_ID INTEGER(32),Location_ID INTEGER(32),Event_Name TEXT,Event_Date CHAR(23),Event_Duration INTEGER(32),PRIMARY KEY(Event_ID));CREATE TABLE IF NOT EXISTS ROSE_PastEvents(PastEvent_ID INTEGER(32),Event_ID INTEGER(32),Actual_Turnout INTEGER,PRIMARY KEY(PastEvent_ID));CREATE TABLE IF NOT EXISTS ROSE_UpcomingEvents(NewEvent_ID INTEGER(32),Event_ID INTEGER(32),Predicted_Turnout INTEGER(32),PRIMARY KEY(NewEvent_ID));\tCREATE TABLE IF NOT EXISTS ROSE_EquipmentAssign(EquipmentAssign_ID INTEGER(32),Event_ID INTEGER(32),Equipment_ID INTEGER(32),PRIMARY KEY(EquipmentAssign_ID));CREATE TABLE IF NOT EXISTS ROSE_Equipment(Equipment_ID INTEGER(32), Equipment_Name TEXT,Equipment_Description TEXT,PRIMARY KEY(Equipment_ID));";
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
            var x = qResults.Read();
            //Debug.WriteLine(String.Concat(qResults.Read().ToString(),"<-qResults"));
            if (x)
            {
                return true;
            }
            return false;
        }

        public static bool removeUpcomingEvent(Int32 eventID)
        {
            /*
             *  Delets an upcominng event row at where = eventID
             */
            return Con.runSQL($"DELETE  FROM Rose_UpcomingEvents Where Event_ID = {eventID};");
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

        public static List<UpcomingEvent>? getUpcomingEvents()
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

        public static StaffObject getStaffByID(Int32 StaffID)
        {
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From  ROSE_Staff WHERE Staff_ID = {StaffID};");
            if (qResults.Read()) // (Staff_ID,Staff_Fname,Staff_Lname,Staff_Position_Staff_Phonenumber)
            {
                return new StaffObject(qResults.GetInt32(0), qResults.GetString(1), qResults.GetString(2), qResults.GetString(4), qResults.GetString(3)

                                   ); 
            }
            return new StaffObject(StaffID, "Unknown First name ", "unkown Second name", "unkown phone number", "unkown position");
                                   

      
        }

        public static LocationObject getLocationByID(Int32 LocationID)
        {
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From  ROSE_Location WHERE Location_ID = {LocationID};");
            if (qResults.Read()) // (Location_ID,Location_Name,Location_Address,Location_Capacity)
            {
                return new LocationObject(qResults.GetInt32(0), qResults.GetString(1), qResults.GetString(2), qResults.GetInt32(3));
                                  
            }
            return new LocationObject(-1, "Missing Location Please Add", "Unknown", 0);
        }

        public static PastEvent getPastEventsByID(Int32 PastEventsID)
        {
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From  ROSE_PastEvents WHERE PastEvent_ID = {PastEventsID};");
            if (qResults.Read()) // (Login_ID,Staff_ID,User_Name,Login_Password)
            {
                EventObject e = DBAbstractionLayer.getEventByID(qResults.GetInt32(1));
                return new PastEvent(e,qResults.GetInt32(2));
            }
            return new PastEvent(DBAbstractionLayer.getEventByID(-1), 0);
        }


        public static EquipmentObject getEquipmentByID(Int32 EquipmentID)
        {
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From  ROSE_Equipment WHERE Equipment_ID = {EquipmentID};");
            if (qResults.Read()) // (Equipment_ID,Equipment_Name,Equipment_Description)
            {
                return new EquipmentObject(qResults.GetInt32(0), qResults.GetString(1), qResults.GetString(2)); 
            }
        return new EquipmentObject(EquipmentID,"Unknown Equipment","unkown Description");
        }

        public static List<PastEvent>? getPreviousEvents()
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

        public static UpcomingEvent getUpcommingEventData(Int32 EventID)
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

        public static List<PastEvent>? getAllPreviousTurnoutsAtLocation(LocationObject Location)
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

        public static void updateUpcomingEvent(UpcomingEvent upcoming)
        {
            Con.runSQL($"UPDATE Rose_UpcomingEvent SET Event_ID = {upcoming.getEventID()},Predicted_Turnout = {upcoming.getEstimatedTurnout()} WHERE NewEvent_ID = {upcoming.getEventID()};");
        }

        public static List<UserObject> getAllUsers()
        {
            List<UserObject> l = new List<UserObject>();
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From ROSE_Login");
            while (qResults.Read())
            {

                l.Add(new UserObject(qResults.GetString(2),qResults.GetString(3)));
            }
            return l;
        }
        public static Boolean addNewEvent(EventObject e)
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
                    return false;
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
        public static Int32 getEquipmentIDByName(String Name)
        {
            SQLiteDataReader? qResults = Con.querySQL($"SELECT Equipment_ID From  ROSE_Equipment WHERE Equipment_Name = '{Name}';");
            if (qResults.Read())
            {
                return qResults.GetInt32(0);
            }
            return -1;
        }
        public static Int32 getStaffIDByNames(String fName,String lName)
        {
            /*  First and Last Names  */
            SQLiteDataReader? qResults = Con.querySQL($"SELECT Staff_ID From  ROSE_Staff WHERE Staff_Fname = '{fName}' AND Staff_Lname = '{lName}';");
            if (qResults.Read()) 
            {
                return qResults.GetInt32(0);
            }
            return -1;

        }
        public static Int32 getLocationIDByName(String Name)
        {
            SQLiteDataReader? qResults = Con.querySQL($"SELECT Location_ID From  ROSE_Location WHERE Location_Name = '{Name}';");
            if (qResults.Read()) 
            {
                return qResults.GetInt32(0);
            }
            return -1;

        }
        public static Int32 getEventIDByName(String Name)
        {
            SQLiteDataReader? qResults = Con.querySQL($"SELECT Event_ID From  ROSE_Event WHERE Event_Name = '{Name}';");
            if (qResults.Read()) 
            {
                return qResults.GetInt32(0);
            }
            return -1;

        }

        public static EventObject getEventByName(String Name)
        {
            return DBAbstractionLayer.getEventByID(DBAbstractionLayer.getEventIDByName(Name));
        }
        
        public static LocationObject getLocationByName(String Name)
        {
            return DBAbstractionLayer.getLocationByID(DBAbstractionLayer.getLocationIDByName(Name));
        }
        public static StaffObject getStaffByName(String firstName,String secondName)
        {
            return DBAbstractionLayer.getStaffByID(DBAbstractionLayer.getStaffIDByNames(firstName,secondName));
        }
        public static EquipmentObject getEquipmentByName(String Name)
        {
            return DBAbstractionLayer.getEquipmentByID(DBAbstractionLayer.getEquipmentIDByName(Name));
        }

        public static LocationObject getLocationFromEventName(String Name)
        {
            return DBAbstractionLayer.getEventByName(Name).getEventLocation();
        }
        public static List<EquipmentObject> getEquipmentFromEventName(String Name)
        {
            return DBAbstractionLayer.getEventByName(Name).getEventEquipment();
        }
        public static List<StaffObject> getStaffFromEventName(String Name)
        {
            return DBAbstractionLayer.getEventByName(Name).getEventStaff();
        }

        public Boolean updateEvent(EventObject e)
        {
            if (DBAbstractionLayer.isNewEventID(e.getEventID()))
            {
                return DBAbstractionLayer.addNewEvent(e);
            }
            bool a = Con.runSQL($"UPDATE Rose_Event SET Event_Name = '{e.getEventName()}, Location_ID = {e.getEventLocation().getLocationID()},Event_Date = '{e.getEventDate()}',Event_Duration = {e.getEventDuration()} WHERE Event_ID = {e.getEventID()}");
            Boolean b = DBAbstractionLayer.updateAssignedEquipment(e.getEventEquipment(), e.getEventID());
            Boolean c = DBAbstractionLayer.updateAssignedStaff(e.getEventStaff(), e.getEventID());
            return a && b && c;
        }
        public static bool updateAssignedStaff(List<StaffObject> staffObjects, Int32 EventID)
        {
            DBAbstractionLayer.ensureStatus();
            Boolean check = true;
            Con.runSQL($"Delete From Rose_AssignStaff where Event_ID = {EventID}");
            foreach (StaffObject s in staffObjects)
            {
                check = check && Con.runSQL($"PRAGMA foreign_keys = 0;INSERT INTO ROSE_EquipmentAssign(EquipmentAssign_ID,Event_ID,Equipment_ID) VALUES ({DBAbstractionLayer.getNewStaffAssignID()},{EventID},{s.getStaffID()});");
            }
            return check;
        }
        public static bool updateAssignedEquipment(List<EquipmentObject>? equipmentObjects, Int32 EventID)
        {
            DBAbstractionLayer.ensureStatus();
            Boolean check = true;
            Con.runSQL($"Delete From Rose_EquipmentAssign where Event_ID = {EventID}");
            foreach (EquipmentObject q in equipmentObjects)
            {
                check = check && Con.runSQL($"PRAGMA foreign_keys = 0;INSERT INTO ROSE_EquipmentAssign(EquipmentAssign_ID,Event_ID,Equipment_ID) VALUES ({DBAbstractionLayer.getNewEquipmentAssignID()},{EventID},{q.getEquipmentID()});");
            }
            return check;
        }

        public static List<EquipmentObject>? getAllEquipment()
        {
            {
                List<EquipmentObject> l = new List<EquipmentObject>();
                SQLiteDataReader? qResults = Con.querySQL($"SELECT * From ROSE_Equipment");
                while (qResults.Read())
                {

                    l.Add(new EquipmentObject(qResults.GetInt32(0),qResults.GetString(1), qResults.GetString(2)));
                }
                return l;
            }
            
        }

        public static List<LocationObject>? getAllLocations()
        {
            List<LocationObject> l = new List<LocationObject>();
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From ROSE_Location");
            while (qResults.Read())
            {

                l.Add(new LocationObject(qResults.GetInt32(0), qResults.GetString(1), qResults.GetString(2), qResults.GetInt32(3)));
            }
            return l; 
        }

        internal static List<StaffObject>? getAllStaff()
        {
            List<StaffObject> l = new List<StaffObject>();
            SQLiteDataReader? qResults = Con.querySQL($"SELECT * From ROSE_Staff");
            while (qResults.Read())
            {

                l.Add(new StaffObject(qResults.GetInt32(0), qResults.GetString(1), qResults.GetString(2), qResults.GetString(3), qResults.GetString(4)));
            }
            return l;
        }
    }// DBAbstractionLayer
}
