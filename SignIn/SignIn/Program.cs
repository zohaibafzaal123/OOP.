namespace SignIn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice = "";
            while(choice != "3")
            {
                choice = MUserUi.Menu();
                if(choice == "1")
                {
                    MUser u = MUserUi.TakeInputWithoutRole();
                    if(u != null)
                    {
                        string role = MUserCRUD.GetRoleForSignIn(u);
                        if(role == "admin" || role == "user")
                        {
                            Console.WriteLine("Signed in successfully...");
                            Clear();
                        }

                        else
                        {
                            Console.WriteLine("Wrong Credentials!");
                            Clear();
                        }
                    }

                    else
                    {
                        Console.WriteLine("Wrong Credentials!");
                        Clear();
                    }
                }

                else if(choice == "2") 
                {
                    MUser u = MUserUi.TakeInputWithRole();
                    if(u != null) 
                    {
                        bool checkuser = MUserCRUD.CheckUser(u);
                        if(checkuser)
                        {
                            MUserCRUD.StoreUserinList(u);
                            Console.WriteLine("Signed up successfully");
                            Clear();
                        }

                        else
                        {
                            Console.WriteLine("User already exist!");
                            Clear();
                        }
                    }

                    else
                    {
                        Console.WriteLine("Wrong Credentials!");
                        Clear();
                    }
                }

                else if(choice == "3")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid entity!");
                    Clear();
                }
            }
        }

        static void Clear()
        {
            Console.Write("\nPress any key to continue.....");
            Console.ReadKey();
            Console.Clear();
        }
    }
}