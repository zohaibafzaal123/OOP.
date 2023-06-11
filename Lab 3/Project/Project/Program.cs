namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "F:\\OOP PDs\\Lab 3\\Project\\Users.txt";
            List<MUser> Users = new List<MUser>();
            string choice =  "";
            ReadUserData(path, Users);
            while(choice != "3")
            {
                choice = MainMenu();
                if(choice == "1")
                {
                    MUser user = TakeInputwithoutRole();
                    if (user != null)
                    {
                        string role = CheckUserForSignIn(user, Users);
                        if (role=="manager" || role=="user")
                        {
                            SignedInSuccessfully();
                            if(role == "user")
                            {
                                UserInterface();
                            }
                        }
                        else
                        {
                            Console.WriteLine("User not registered yet!");
                            Clear();
                        }
                    }

                    else
                    {
                        Console.WriteLine("\nWrong Credentials entered!");
                        Clear();
                    }


                }

                else if(choice == "2") 
                {
                    MUser user = TakeInputWithRole();
                    if(user != null) 
                    {
                        bool checkuser = CheckUser(user, Users);
                        if(checkuser)
                        {
                            StoreUserInList(user, Users);
                            WriteUserData(path, Users);
                            SignedUpSuccessfully();
                        }
                        else
                        {
                            Console.WriteLine("User already present!");
                            Clear();
                        }
                    }

                    else
                    {
                        Console.WriteLine("\nWrong Credentials entered!");
                        Clear();
                    }
                    
                }

                else if( choice == "3")
                {
                    break;
                }

                else
                {
                    Invalid();
                }
            }


        }

        static void WriteUserData(string path, List<MUser> U)
        {
            if (File.Exists(path))
            {
                StreamWriter file = new StreamWriter(path);
                foreach(MUser u in U) 
                {
                    file.WriteLine(u.name + "," + u.password + "," + u.role);
                }
                file.Flush();
                file.Close();
            }

        }

        static void ReadUserData(string path, List<MUser> user)
        {
            string record;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((record = file.ReadLine()) != null)
                {
                    MUser U = new MUser();
                    U.name = ParseData(record, 1);
                    U.password = ParseData(record, 2);
                    U.role = ParseData(record, 3);
                    user.Add(U);
                }
                file.Close();
            }
        }

        static string ParseData(string record, int field)
        {
            string str = "";
            int commaCount = 1;
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                }

                else if (commaCount == field)
                {
                    str = str + record[i];
                }
            }
            return str;
        }


        static void Header()
        {
            Console.Clear();
            Console.WriteLine("*****************************************************************************************");
            Console.WriteLine("*                               SKY TRAVELS                                             *");
            Console.WriteLine("*****************************************************************************************");
        }

        static void Clear()
        {
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
            Console.Clear();
        }

        static void Invalid()
        {
            Console.WriteLine("\nInvalid entity!");
            Clear();
        }

        static void SignedUpSuccessfully()
        {
            Console.WriteLine("Signed up successfully..");
            Clear();
        }

        static void SignedInSuccessfully()
        {
            Console.WriteLine("Signed in successfully..");
            Clear();
        }

        static string MainMenu()
        {
            string choice;
            Header();
            Console.WriteLine("+_____________________________________________+");
            Console.WriteLine("1.\tSign in");
            Console.WriteLine("2.\tSign up");
            Console.WriteLine("3.\tExit");
            Console.WriteLine("+.............................................+");
            Console.WriteLine("Please enter your choice : ");
            choice = Console.ReadLine();
            return choice;
        }

        static MUser TakeInputWithRole()
        {
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your password : ");
            string password = Console.ReadLine();
            Console.Write("Enter your role (manager/user) : ");
            string role = Console.ReadLine();
            if(name != null &&  password != null && role != null)
            {
                MUser user = new MUser(name,password,role);
                return user;
            }
            return null;
        }

        static MUser TakeInputwithoutRole()
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

        static bool CheckUser(MUser user, List<MUser> Users)
        {
            bool flag = true;
            foreach (MUser u in Users)
            {
                if (user.name == u.name)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        static void StoreUserInList(MUser u,List<MUser> user)
        {
            user.Add(u);
        }

        static string CheckUserForSignIn(MUser user, List<MUser> Users)
        {
            string role = "";
            foreach (MUser u in Users)
            {
                if (user.name == u.name && user.password == u.password)
                {
                    role = u.role;
                    break;
                }
            }
            return role;
        }

        static string UserMenu()
        {
            string choice;
            Header();
            Console.WriteLine("+------------------------------------+");
            Console.WriteLine("1.\tBook a ticket");
            Console.WriteLine("2.\tView your infromation");
            Console.WriteLine("3.\tUpdate your information");
            Console.WriteLine("4.\tCancel your ticket");
            Console.WriteLine("5.\tExit");
            Console.WriteLine("+....................................+");
            Console.WriteLine("Please enter your choice : ");
            choice = Console.ReadLine();
            return choice;
        }

        static void UserInterface()
        {
            string path = "F:\\OOP PDs\\Lab 3\\Project\\Passengers.txt";
            List<Passengers> passenger = new List<Passengers>();
            List<string> Locations = new List<string>() { "lahore","faisalabad","sialkot","islamabad","multan"};
            List<int> Prices = new List<int>() { 1200,1100,1500,2000,1000};
            string choice = "";
            ReadPassengerData(path, passenger);
            while(choice != "5")
            {
                choice = UserMenu();
                if(choice == "1")
                {
                    Passengers P = TakeInputForPassengers();
                    if(P!= null)
                    {
                        if(P==null)
                        {
                            Console.WriteLine("\nWrong Credentials entered!");
                            Clear();
                        }
                        else
                        {
                            bool checkPassenger = P.CheckSeat(passenger);
                            bool checkCniclength = P.CheckCNICLength();
                            bool checkcnic = P.CheckCNIC(passenger);
                            bool checklocation = P.CheckLocation(Locations);
                            bool checkSeatlength = P.CheckSeatNumberLength();
                            if(checkPassenger && checkCniclength && checklocation && checkcnic && checkSeatlength)
                            {
                                int fare = P.GetFare(Locations, Prices);
                                Passengers Pass = new Passengers(P.name, P.CNIC, P.seatNo, P.location, fare);
                                StorePassengerDataInList(Pass, passenger);
                                WritePassengerData(path, passenger);
                                SeatBookedSuccessfully();
                            }
                            else if(!checkPassenger)
                            {
                                SeatBookedError();
                            }
                            else if(!checkCniclength)
                            {
                                CNICLengthError();
                            }
                            else if(!checkcnic)
                            {
                                CNICAlreadyPresentError();
                            }
                            else if(!checklocation)
                            {
                                InvalidLocationError();
                            }
                            else if(!checkSeatlength)
                            {
                                InvalidSeatError();
                            }
                        }
                    }

                }
                else if(choice == "2") 
                {
                    Console.Write("Please confirm your name : ");
                    string name = Console.ReadLine();
                    Passengers pass = new Passengers(name);
                    int index = pass.GetIndex(passenger);
                    if(index == -1)
                    {
                        NoSeatBookedError();
                    }
                    else
                    {
                        ShowPassenggerInfo(index, passenger);
                    }
                }
                else if(choice == "3")
                {
                    Console.Write("Please confirm your name : ");
                    string name = Console.ReadLine();
                    Passengers pass = new Passengers(name);
                    int index = pass.GetIndex(passenger);
                    if (index == -1)
                    {
                        NoSeatBookedError();
                    }
                    else
                    {
                        string option = "";
                        while (option != "5")
                        {
                            option = UpdateMenu();
                            if (option == "1")
                            {
                                Console.Write("Enter new name : ");
                                string newname = Console.ReadLine();
                                Passengers P = new Passengers(newname);
                                bool checkpassenger = P.CheckPassengerName(passenger);
                                if(checkpassenger)
                                {
                                    P.ChangePassengerName(index, passenger);
                                    NameChangedSuccessfully();
                                }
                                else
                                {
                                    PassengerNameErroor();
                                }
                            }
                            else if (option == "2")
                            {
                                Console.Write("Enter new CNIC number : ");
                                string cnic = Console.ReadLine();
                                Passengers P = new Passengers("",cnic);
                                bool checkCniclength = P.CheckCNICLength();
                                bool checkcnic = P.CheckCNIC(passenger);
                                if(checkCniclength && checkcnic)
                                {
                                    P.ChangeCNICNumber(index, passenger);
                                    CNICChangedSuccessfully();
                                }
                                else if(!checkCniclength)
                                {
                                    CNICLengthError();

                                }
                                else if(!checkcnic)
                                {
                                    CNICAlreadyPresentError();
                                }
                            }
                            else if (option == "3")
                            {
                                Console.Write("Enter new seat number : ");
                                int newseat = int.Parse(Console.ReadLine());
                                Passengers P = new Passengers("",newseat);
                                bool checkseat = P.CheckSeatNumber(passenger);
                                bool checkseatlength = P.CheckSeatNumberLength();
                                if(checkseat && checkseatlength)
                                {
                                    P.ChangeSeatNumber(index, passenger);
                                    SeatChangedSuccessfully();
                                }
                                else if(!checkseat)
                                {
                                    SeatBookedError();
                                }
                                else if (!checkseatlength)
                                {
                                    InvalidSeatError();
                                }
                            }
                            else if(option == "4")
                            {
                                Console.Write("Enter new location : ");
                                string location = Console.ReadLine();
                                Passengers P = new Passengers("",location,0);
                                bool checklocation = P.CheckLocation(Locations);
                                if(checklocation)
                                {
                                    P.price = P.GetFare(Locations, Prices);
                                    P.ChangeLocationAndFare(index, passenger);
                                    LocationChangedSuccessfully();
                                }
                                else
                                {
                                    InvalidLocationError();
                                }
                            }
                            else if(option == "5")
                            {
                                break;
                            }
                            else
                            {
                                Invalid();
                            }
                        }
                    }
                }
                else if( choice == "4")
                {
                    Console.Write("Please confirm your name : ");
                    string name = Console.ReadLine();
                    Passengers pass = new Passengers(name);
                    int index = pass.GetIndex(passenger);
                    if (index == -1)
                    {
                        NoSeatBookedError();
                    }
                    else
                    {
                        string confirmation = Confirmation();
                        if (confirmation == "y")
                        {
                            DeleteTicketInfo(index,passenger);
                            TicketCancelledSuccessfully();
                        }
                        else if (confirmation == "n")
                        {
                            OperationCancelled();
                        }
                        else
                        {
                            Invalid();
                        }   
                    }
                }
                else if(choice == "5")
                {
                    break;
                }
                else
                {
                    Invalid();
                }
            }
        }

        static void WritePassengerData(string path, List<Passengers> P)
        {
            if (File.Exists(path))
            {
                StreamWriter file = new StreamWriter(path);
                foreach(Passengers p in P)
                {
                    file.WriteLine(p.name + "," + p.CNIC + "," + p.seatNo + "," + p.location + "," + p.price);
                }
                file.Flush();
                file.Close();
            }
        }

        static void ReadPassengerData(string path, List<Passengers> P)
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    Passengers Passen = new Passengers();
                    Passen.name = ParseData(record, 1);
                    Passen.CNIC = ParseData(record, 2);
                    Passen.seatNo = int.Parse(ParseData(record, 3));
                    Passen.location = ParseData(record, 4);
                    Passen.price = int.Parse(ParseData(record, 5));
                    P.Add(Passen);
                }
                file.Close();
            }
        }
        static Passengers TakeInputForPassengers()
        {
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your CNIC number : ");
            string cnic = Console.ReadLine();
            Console.Write("Enter seat number you want : ");
            int seatNo = int.Parse(Console.ReadLine());
            Console.Write("Enter location you want to go : ");
            string location = Console.ReadLine();
            if (name != null && cnic != null && location != null && seatNo>0)
            {
                Passengers passenger = new Passengers(name,cnic,seatNo,location);
                return passenger;
            }
            return null;
        }

        static void SeatBookedError()
        {
            Console.WriteLine("\nSeat already booked!");
            Clear();
        }

        static void CNICLengthError()
        {
            Console.WriteLine("\nInvalid CNIC entered!");
            Clear();
        }

        static void CNICAlreadyPresentError()
        {
            Console.WriteLine("\nCNIC is already in use!");
            Clear();
        }

        static void InvalidLocationError()
        {
            Console.WriteLine("\nInvalid location entered!");
            Clear();
        }

        static void InvalidSeatError()
        {
            Console.WriteLine("\nInvalid seat number entered!");
            Clear();
        }

        static void NoSeatBookedError()
        {
            Console.WriteLine("\nThere is no passenger with this name!");
            Clear();
        }
        static void StorePassengerDataInList(Passengers P, List<Passengers> Pass)
        {
            Pass.Add(P);
        }

        static void SeatBookedSuccessfully()
        {
            Console.WriteLine("\nSeat has been booked successfully..");
            Clear();
        }
     

        static void ShowPassenggerInfo(int i,List<Passengers> P)
        {
            Header();
            Console.WriteLine("+____________________________________________________________________+");
            Console.WriteLine("Name : {0}", P[i].name);
            Console.WriteLine("CNIC number : {0}", P[i].CNIC);
            Console.WriteLine("Seat number : {0}", P[i].seatNo);
            Console.WriteLine("Location : {0}", P[i].location);
            Console.WriteLine("Fare : {0}", P[i].price);
            Console.WriteLine("+....................................................................+");
            Clear();
        }

        static string UpdateMenu()
        {
            string choice;
            Header();
            Console.WriteLine("+------------------------------------+");
            Console.WriteLine("1.\tChange name");
            Console.WriteLine("2.\tChange CNIC number");
            Console.WriteLine("3.\tChange seat");
            Console.WriteLine("4.\tChange location");
            Console.WriteLine("5.\tBack");
            Console.WriteLine("+....................................+");
            Console.WriteLine("Please enter your choice : ");
            choice = Console.ReadLine();
            return choice;
        }

        static void PassengerNameErroor()
        {
            Console.WriteLine("\nThere is already a passenger with this name!");
            Clear();
        }

        static void NameChangedSuccessfully()
        {
            Console.WriteLine("\nName has been changed successfully..");
            Clear();
        }

        static void CNICChangedSuccessfully()
        {
            Console.WriteLine("\nCNIC number has been changed successfully..");
            Clear();
        }

        static void SeatChangedSuccessfully()
        {
            Console.WriteLine("\nSeat has been changed successfully..");
            Clear();
        }

        static void LocationChangedSuccessfully()
        {
            Console.WriteLine("\nLocation has been updated successfully..");
            Clear();
        }

        static string Confirmation()
        {
            string confirm = "";
            Console.Write("Do you really want to proceed (y/n) : ");
            confirm = Console.ReadLine();
            return confirm;
        }

        static void DeleteTicketInfo(int index,List<Passengers> P)
        {
            P.RemoveAt(index);
        }

        static void TicketCancelledSuccessfully()
        {
            Console.WriteLine("\nTicket has been cancelled successfully..");
            Clear();
        }

        static void OperationCancelled()
        {
            Console.WriteLine("\nOperation has been cancelled..");
            Clear();
        }
    }
}
