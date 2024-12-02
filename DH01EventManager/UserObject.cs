using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH01EventManager
{
    public class UserObject
    {
        private String username;
        private String password;
        private Boolean loggedIn;

        public UserObject(String username, String password, Boolean loggedIn)
        {
            this.username = username;
            this.password = password;
            this.loggedIn = loggedIn;
        }
        //constructor

        public String getUsername() { return username; }
        public String getPassword() { return password; }    
        public Boolean getLoggedIn() { return loggedIn; }

        public void setUsername(String username) { this.username = username; }
        public void setPassword(String password) { this.password = password; }  

        public void setLoggedIn(Boolean loggedIn) { this.loggedIn = loggedIn;}
     }
}
