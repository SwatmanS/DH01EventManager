﻿using System;
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
            //currently hardcoded in - should pull users from database 
            UserObject user1 = new UserObject("jasmine", "ilovealucard");
            UserObject user2 = new UserObject("jasmine2", "ilovealucardmore");

            UserObject[] userArray = [user1, user2];
            return userArray;
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