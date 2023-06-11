using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignIn
{
    internal class MUser
    {
        public string Name;
        public string Password;
        public string Role;

        public MUser(string Name,string Password,string Role) 
        { 
            this.Name = Name;
            this.Password = Password;
            this.Role = Role;
        }

        public MUser(string Name,string Password)
        {
            this.Name = Name;
            this.Password = Password;
        }

    }
}
