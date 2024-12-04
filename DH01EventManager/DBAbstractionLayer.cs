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

        internal static List<EventObject>? getAllEvents()
        {
            throw new NotImplementedException();
        }
    }// DBAbstractionLayer
}
