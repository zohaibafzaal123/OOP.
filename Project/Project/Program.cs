using System.Diagnostics.CodeAnalysis;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "F:\\OOP PDs\\Lab 4\\Project\\Users.txt";
            List<User> users = new List<User>();
            string choice = "";
            ReadUserData(path, users);
            while(choice!="3")
            {
                choice = MainMenu();
                if(choice=="1")
                {
                    User U = TakeInputForSignUp();
                    if(U!=null) 
                    {
                        bool checkuser = U.CheckUserName(users);
                        if(checkuser) 
                        {
                            StoreUserInList(U, users);
                            WriteUserData(path,users);
                            Console.WriteLine("Signed up successfully...");
                            Clear();
                        }
                        else
                        {
                            Console.WriteLine("User already exist");
                            Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong Credentials entered!");
                        Clear();
                    }
                }

                else if(choice=="2") 
                {
                    User U = TakeInputForSignIn();
                    if(U!=null)
                    {
                        string role = U.ReturnRoleForSignIn(users);
                        if (role == "user" || role == "manager" || role == "User" || role == "User")
                        {
                            Console.WriteLine("Signed in successfully..");
                            Clear();
                            if (role == "user" || role == "User")
                            {

                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong Credentials entered!");
                            Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong Credentials entered!");
                        Clear();
                    }
                }
            }
        }

        static void Clear()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Header()
        {
            Console.Clear();
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("*                              BUS MANAGEMENT SYSTEM                                 *");
            Console.WriteLine("**************************************************************************************");
        }

        static string MainMenu()
        {
            Header();
            string choice = "";
            Console.WriteLine("+-----------------------------------------------------+");
            Console.WriteLine("1.\tSign up");
            Console.WriteLine("2.\tSign in");
            Console.WriteLine("3.\tExit");
            Console.WriteLine("+.....................................................+");
            Console.Write("Please enter your choice : ");
            choice = Console.ReadLine();
            return choice;
        }

        static string UserMenu()
        {
            string choice = "";
            Console.WriteLine("+-----------------------------------------------------+");
            Console.WriteLine("1.\tBook a seat");
            Console.WriteLine("2.\tChange your info");
            Console.WriteLine("3.\tGive feedback");
            Console.WriteLine("4.\tBack");
            Console.WriteLine("+.....................................................+");
            Console.Write("Please enter your choice : ");
            choice = Console.ReadLine();
            return choice;
        }

        static User TakeInputForSignUp()
        {
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your password : ");
            string password = Console.ReadLine();
            Console.Write("Enter your role (user/manager) : ");
            string role = Console.ReadLine();
            if(name!=null && password!=null && role!=null)
            {
                User U = new User(name,password,role);
                return U;
            }
            return null;
        }

        static void StoreUserInList(User U,List<User> user)
        {
            user.Add(U);
        }

        static User TakeInputForSignIn()
        {
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your password : ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                User U = new User(name, password);
                return U;
            }
            return null;
        }

        static void WriteUserData(string path,List<User> users)
        {
            if(File.Exists(path))
            {
                StreamWriter file = new StreamWriter(path);
                foreach(User u in users)
                {
                    file.WriteLine(u.Name + "," + u.Password + "," + u.Role);
                }
                file.Flush();
                file.Close();
            }   
        }

        static void ReadUserData(string path,List<User> user)
        {
            if(File.Exists (path))
            {
                string record = "";
                StreamReader file = new StreamReader(path);
                while ((record = file.ReadLine()) != null)
                {
                    User U = new User();
                    U.Name = ParseData(record, 1);
                    U.Password = ParseData(record, 2);
                    U.Role = ParseData(record, 3);
                    user.Add(U);
                }
                file.Close();
            }
        }

        static string ParseData(string data,int comma)
        {
            string record = "";
            int commacount = 1;
            foreach(var c in data)
            {
                if(c == ',')
                {
                    commacount++;
                }
                else if(comma == commacount)
                {
                    record = record + c;
                }
            }
            return record;
        }

        static void UserInterface()
        {
            string choice = "";
            while(choice != "5")
            {
                choice = UserMenu();
                if(choice == "1")
                {

                }
                else if(choice == "2")
                {

                }
                else if( choice == "3")
                {

                }
                else if(choice == "4")
                {

                }
                else if(choice== "5")
                {

                }
                else
                {
                    Console.WriteLine("Invalid Entity!");
                    Clear();
                }
            }
        }
    }
}