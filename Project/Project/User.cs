using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class User
    {
        public string Name;
        public string Password;
        public string Role;

        public User()
        {
            
        }
        public User(string Name, string Password)
        {
            this.Name = Name;
            this.Password = Password;
        }

        public User(string Name, string Password, string Role)
        {
            this.Name = Name;
            this.Password = Password;
            this.Role = Role;
        }

        public bool CheckUserName(List<User> User)
        {
            bool flag = true;
            foreach (User U in User)
            {
                if(Name == U.Name)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        public string ReturnRoleForSignIn(List<User> User)
        {
            string role = "";
            foreach (User U in User)
            { 
                if(Name == U.Name && Password == U.Password)
                { 
                    role = U.Role;
                    break;
                }
            }
            return role;
        }
    }
}
