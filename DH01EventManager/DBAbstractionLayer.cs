using System;
using System.Collections.Generic;
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
        }

        public static bool isPreviousEvent(Int32 eventID)
        {
            throw new NotImplementedException();
        }

        public static void removeUpcomingEvent(Int32 eventID)
        {
            throw new NotImplementedException();
        }

        public static Boolean addPreviousEvent(EventObject e, Int32 ActualTurnout)
        {
            throw new NotImplementedException();
        }

        internal static List<UpcomingEvent>? getUpcomingEvents()
        {
            throw new NotImplementedException();
        }

        internal static List<PastEvent>? getPreviousEvents()
        {
            throw new NotImplementedException();
        }
    }// DBAbstractionLayer
}
