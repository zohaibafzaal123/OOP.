using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignIn
{
    internal class MUserCRUD
    {
        public static List<MUser> Users = new List<MUser>();

        
        public static void StoreUserinList(MUser u)
        {
            Users.Add(u);
        }
        public static bool CheckUser(MUser user)
        {
            bool flag = true;
            foreach(var U in Users) 
            { 
                if(U.Name == user.Name)
                { 
                    flag = false;
                }
            }
            return flag;
        }

        public static string GetRoleForSignIn(MUser user)
        {
            string role = "";
            foreach(var U in Users) 
            {
                if(U.Name == user.Name && U.Password == user.Password)
                {
                    role = U.Role;
                }
            }
            return role;
        }
    }
}
