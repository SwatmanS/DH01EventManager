using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH01EventManager
{
    internal class LogInObject
    { 
        private static UserObject? LoggedInUser; 
        public LogInObject(UserObject user)
        {
            LoggedInUser = user;
        }

        public static UserObject? getUser() { return LoggedInUser; }

        public static void setUser(UserObject user) { LogInObject.LoggedInUser = user; }


    }
}
