using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH01EventManager
{
    internal class UserObject
    {
        private string username;
        private string password;
        private Boolean loggedIn;

        public UserObject(string username, string password, Boolean loggedIn)
        {
            this.username = username;
            this.password = password;
            this.loggedIn = loggedIn;
        }
        //constructor

        public string getUsername() { return username; }
        public string getPassword() { return password; }    
        public Boolean getLoggedIn() { return loggedIn; }

        public void setUsername(string username) { this.username = username; }
        public void setPassword(string password) { this.password = password; }  

        public void setLogged(Boolean loggedIn) { this.loggedIn = loggedIn;}
     }
}
