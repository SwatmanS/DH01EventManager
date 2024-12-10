using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH01EventManager
{
    public class UserObject
    {
        private String username;
        private String password;

        public UserObject(String username, String password)
        {
            this.username = username;
            this.password = password;
        }
        //constructor

        public String getUsername() { return username; }
        public String getPassword() { return password; }    

        public void setUsername(String username) { this.username = username; }
        public void setPassword(String password) { this.password = password; }  

        public UserObject[] makeArray()
        {

            List<UserObject> x = DBAbstractionLayer.getAllUsers();
            UserObject[] userArray2 = new UserObject[x.Count];
            Debug.WriteLine(userArray2.Length);
            foreach (UserObject user in x) 
            {
                Debug.WriteLine(String.Concat(user.getUsername(), user.getPassword()));
            }
            for (int i = 0; i > x.Count; i++) 
            { 
                userArray2[i] = x[i]; 
            }
            return x.ToArray();
        }

        public Dictionary<String,String> makeDictionary(UserObject[] array, Dictionary<String, String> dict)
        {
            int len = array.Length;

            for(int i = 0; i < len; i++)
            {
                dict.Add(array[i].getUsername(), array[i].getPassword());
            }

            return dict;
        }
     }
}
