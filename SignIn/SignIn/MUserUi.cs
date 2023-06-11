using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignIn
{
    internal class MUserUi
    {
        public static string Menu()
        {
            string choice = "";
            Console.WriteLine("+--------------------------------------------------------------------+");
            Console.WriteLine("1.\tSign in");
            Console.WriteLine("2.\tSign up");
            Console.WriteLine("3.\tExit");
            Console.WriteLine("+....................................................................+");
            Console.Write("Please enter your choice : ");
            choice = Console.ReadLine();
            return choice;
        }
        public static MUser TakeInputWithRole()
        {
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your password : ");
            string password = Console.ReadLine();
            Console.Write("Enter your role : ");
            string role = Console.ReadLine();
            if (name != null && password != null && role != null)
            {
                MUser user = new MUser(name, password, role);
                return user;
            }
            return null;
        }

        public static MUser TakeInputWithoutRole()
        {
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your password : ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                MUser user = new MUser(name, password);
                return user;
            }
            return null;
        }
    }
}
