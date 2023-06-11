using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class MUser
    {
        
        public string name;
        public string password;
        public string role;

        public MUser() 
        {
            name = "";
            password = "";
            role = "";
        }

        public MUser(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        public MUser(string username, string Password,string Role)
        {
            name = username;
            password = Password;
            role = Role;
        }
    }
}