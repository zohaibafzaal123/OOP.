using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MyProject
{
    internal class Program
    {
        static List<Passengers> Passenger = new List<Passengers>();
        static List<string> Locations = new List<string> { "faisalabad", "lahore", "multan", "sialkot", "islamabad" };
        static List<int> Fares = new List<int> { 1100, 1200, 1000, 1500, 2000 };
        static List<Feedback> feedbacks = new List<Feedback>();
        static void Main(string[] args)
        {
            string path = "F:\\OOP PDs\\Lab 2\\MyProject\\Users.txt";
            string username, password, role;
            List<Users> users = new List<Users>();
            string choice = "";
            ReadUserData(path, users);
            while (choice != "3")
            {
                choice = MainMenu();

                if (choice == "1")
                {
                    Console.Write("Enter Username : ");
                    username = Console.ReadLine();
                    Console.Write("Enter Password : ");
                    password = Console.ReadLine();
                    string checkRole = SignIn(users, username, password);
                    if (checkRole == "manager" || checkRole == "user")
                    {
                        Console.WriteLine("\nSigned in successfully...");
                        CLear();
                        if (checkRole == "manager")
                        {
                            ManagerInterface();
                        }
                        else
                        {
                            UserInterface();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nWrong Credentials!");
                        CLear();
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Enter Username : ");
                    username = Console.ReadLine();
                    Console.Write("Enter Password : ");
                    password = Console.ReadLine();
                    Console.Write("Enter the role : ");
                    role = Console.ReadLine();
                    bool checkUser = CheckUsers(username, users);
                    if (checkUser)
                    {
                        users.Add(Signup(username, password, role));
                        WriteUserData(path, users);
                        Console.WriteLine("\nSigned up successfully...");
                        CLear();
                    }
                    else
                    {
                        Console.WriteLine("\nUser already exist!");
                        CLear();
                    }
                }

                else if (choice == "3")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("\nInvalid Entity!");
                    CLear();
                }
            }

        }

        static void CLear()
        {
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
            Console.Clear();
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

        static bool CheckUsers(string name, List<Users> user)
        {
            bool flag = true;
            for (int i = 0; i < user.Count; i++)
            {
                if (name == user[i].Username)
                {
                    flag = false;
                }
            }
            return flag;
        }

        static Users Signup(string username, string password, string role)
        {
            Users user = new Users();
            user.Username = username;
            user.Password = password;
            user.Role = role;
            return user;
        }

        static string SignIn(List<Users> user, string username, string password)
        {
            string role = "";
            for (int i = 0; i < user.Count; i++)
            {
                if (username == user[i].Username && password == user[i].Password)
                {
                    role = user[i].Role;

                }
            }
            return role;
        }

        static void WriteUserData(string path, List<Users> U)
        {
            if (File.Exists(path))
            {
                StreamWriter file = new StreamWriter(path);
                for (int i = 0; i < U.Count; i++)
                {
                    file.WriteLine(U[i].Username + "," + U[i].Password + "," + U[i].Role);
                }
                file.Flush();
                file.Close();
            }
        }
        static void ReadUserData(string path, List<Users> user)
        {
            string record;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((record = file.ReadLine()) != null)
                {
                    Users U = new Users();
                    U.Username = ParseData(record, 1);
                    U.Password = ParseData(record, 2);
                    U.Role = ParseData(record, 3);
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
        static string UserMenu()
        {
            string choice;
            Header();
            Console.WriteLine("+------------------------------------+");
            Console.WriteLine("1.\tBook a ticket");
            Console.WriteLine("2.\tView your infromation");
            Console.WriteLine("3.\tUpdate your information");
            Console.WriteLine("4.\tCancel your ticket");
            Console.WriteLine("5.\tGive your feedback");
            Console.WriteLine("6.\tExit");
            Console.WriteLine("+....................................+");
            Console.WriteLine("Please enter your choice : ");
            choice = Console.ReadLine();
            return choice;
        }

        static void UserInterface()
        {
            string path = "F:\\OOP PDs\\Lab 2\\MyProject\\Passengers.txt";
            string feedbackPath = "F:\\OOP PDs\\Lab 2\\MyProject\\Feedbacks.txt";
            string name, CNIC, location;
            int seatNo, bill;
            string choice = "";
            ReadPassengerData(path, Passenger);
            ReadUserFeedback(feedbackPath, feedbacks);
            while (choice != "6")
            {
                choice = UserMenu();
                if (choice == "1")
                {
                    Console.Write("Enter name of the passenger : ");
                    name = Console.ReadLine();
                    Console.Write("Enter passenger's CNIC number : ");
                    CNIC = Console.ReadLine();
                    Console.Write("Enter seat number : ");
                    seatNo = int.Parse(Console.ReadLine());
                    Console.Write("Enter location you want to go : ");
                    location = Console.ReadLine();
                    bool seatCheck = SeatCheck(Passenger, name, seatNo);
                    bool checkCNIC = CNICcheck(Passenger, CNIC);
                    bool CNIClength = checkCNICLength(CNIC);
                    bool checkLocation = CheckLocation(location, Locations);
                    if (seatCheck && checkLocation && checkCNIC && CNIClength)
                    {
                        Passenger.Add(BookTicket(name, CNIC, seatNo, location, Locations, Fares));
                        WritePassengerData(path, Passenger);
                        Console.WriteLine("Ticket has been booked successfully...");
                        CLear();
                    }
                    else if (!seatCheck)
                    {
                        Console.WriteLine("Seat already booked!");
                        CLear();
                    }
                    else if (!checkCNIC)
                    {
                        Console.WriteLine("CNIC already in use!");
                        CLear();
                    }
                    else if (!CNIClength)
                    {
                        Console.WriteLine("Invalid CNIC entered!");
                        CLear();
                    }
                    else if (!checkLocation)
                    {
                        Console.WriteLine("Invalid location entered!");
                        CLear();
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Please confirm your name : ");
                    name = Console.ReadLine();
                    int index = GetIndex(Passenger, name);
                    ViewInformation(index);
                }

                else if (choice == "3")
                {
                    Console.Write("Please confirm your name : ");
                    name = Console.ReadLine();
                    int index = GetIndex(Passenger, name);
                    if (index != -1)
                    {
                        ChangeInformation(index,Locations, Fares);
                        WritePassengerData(path, Passenger);
                    }
                    else
                    {
                        InvalidName();
                    }
                }

                else if (choice == "4")
                {
                    Console.Write("Please confirm your name : ");
                    name = Console.ReadLine();
                    int index = GetIndex(Passenger, name);
                    if(index!=-1)
                    {
                        CancelTicket(index);
                    }
                    else
                    {
                        InvalidName();
                    }
                }

                else if (choice == "5")
                {
                    feedbacks.Add(GiveFeedback());
                    StoreUsersFeedback(feedbackPath, feedbacks);
                    Console.WriteLine("Thank you for your feedback...");
                    CLear();
                }
            }

        }

        static Passengers BookTicket(string name, string CNIC, int seatNo, string location, List<string> Location, List<int> Price)
        {
            Passengers P = new Passengers();
            P.PassenName = name;
            P.CNICnumber = CNIC;
            P.Location = location;
            P.SeatNumber = seatNo;
            int price = GetFare(location, Location, Price);
            P.bill = price;
            return P;
        }

        static bool SeatCheck(List<Passengers> passengers, string name, int seatNo)
        {
            bool flag = true;
            for (int i = 0; i < passengers.Count; i++)
            {
                if (name == passengers[i].PassenName || seatNo == passengers[i].SeatNumber)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        static int GetIndex(List<Passengers> passengers, string name)
        {
            int index = -1;
            for (int i = 0; i < passengers.Count; i++)
            {
                if (name == passengers[i].PassenName)
                {
                    index = i;
                }
            }
            return index;
        }

        static void InvalidName()
        {
            Console.WriteLine("Invalid name entered!");
            CLear();
        }
        static bool CNICcheck(List<Passengers> passengers, string CNIC)
        {
            bool flag = true;
            for (int i = 0; i < passengers.Count; i++)
            {
                if (CNIC == passengers[i].CNICnumber)
                {
                    flag = false;
                }
            }
            return flag;
        }

        static bool checkCNICLength(string CNIC)
        {
            int count = 0;
            bool flag = false;
            for (int i = 0; i < CNIC.Length; i++)
            {
                int num = CNIC[i] - '0';
                if (num >= 0 && num <= 9)
                {
                    count++;
                }
                if (count == 13)
                {
                    break;
                }
            }
            if (count == 13)
            {
                flag = true;
            }
            return flag;
        }

        static bool CheckLocation(string location, List<string> Location)
        {
            bool flag = false;
            for (int i = 0; i < Location.Count; i++)
            {
                if (Location[i] == location)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        static int GetFare(string location, List<string> Location, List<int> Price)
        {
            int Fare = 0;
            for (int i = 0; i < Location.Count; i++)
            {
                if (Location[i] == location)
                {
                    Fare = Price[i];
                }
            }
            return Fare;
        }

        static void ViewInformation(int i)
        {
            if (i != -1)
            {
                Header();
                Console.WriteLine("Name : {0}", Passenger[i].PassenName);
                Console.WriteLine("CNIC number : {0}", Passenger[i].CNICnumber);
                Console.WriteLine("Seat number : {0}", Passenger[i].SeatNumber);
                Console.WriteLine("Location : {0}", Passenger[i].Location);
                Console.WriteLine("Fare : {0}", Passenger[i].bill);
                Console.WriteLine("+..................................................+");
                CLear();
            }
            else
            {
                Console.WriteLine("Seat has not booked yet!");
                CLear();
            }
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

        static void ChangeInformation(int index, List<string> Locations, List<int> Price)
        {
            if (index != -1)
            {
                string choice = "";
                while (choice != "5")
                {
                    choice = UpdateMenu();
                    if (choice == "1")
                    {
                        string name;
                        Console.Write("Enter new name : ");
                        name = Console.ReadLine();
                        int i = GetIndex(Passenger, name);
                        if (i == -1)
                        {
                            ChangeName(index, name);
                            
                        }
                        else
                        {
                            Console.WriteLine("Name is already in use!");
                            CLear();
                        }

                    }
                    else if (choice == "2")
                    {
                        string CNIC;
                        Console.Write("Enter new CNIC number : ");
                        CNIC = Console.ReadLine();
                        bool checkCNIC = CNICcheck(Passenger, CNIC);
                        bool CNIClength = checkCNICLength(CNIC);
                        if (checkCNIC && CNIClength)
                        {
                            ChangeCNIC(index, CNIC);
                        }
                        else if (!checkCNIC)
                        {
                            Console.WriteLine("CNIC already in use!");
                            CLear();
                        }
                        else if (!CNIClength)
                        {
                            Console.WriteLine("Invalid CNIC entered!");
                            CLear();
                        }
                    }
                    else if (choice == "3")
                    {
                        int SeatNo;
                        Console.Write("Enter new seat number you want : ");
                        SeatNo = int.Parse(Console.ReadLine());
                        bool seatCheck = CheckSeat(SeatNo, Passenger);
                        if (seatCheck)
                        {
                            ChangeSeat(index, SeatNo);
                        }
                    }
                    else if (choice == "4")
                    {
                        string location;
                        int fare;
                        Console.Write("Enter new location : ");
                        location = Console.ReadLine();
                        bool checkLocation = CheckLocation(location, Locations);
                        if (checkLocation)
                        {
                            ChangeLocation(index, location);
                        }
                        else
                        {
                            Console.WriteLine("Invalid location entered!");
                            CLear();
                        }
                    }
                }
            }
            else
            {
                InvalidName();
            }
        }

        static void ChangeName(int index, string name)
        {
            Passenger[index].PassenName = name;
            Console.WriteLine("Name has been canged successfully...");
            CLear();


        }
        static void ChangeCNIC(int index, string CNIC)
        {
            Passenger[index].CNICnumber = CNIC;
            Console.WriteLine("CNIC number has been canged successfully...");
            CLear();
        }

        static void ChangeSeat(int index, int SeatNo)
        {
            Passenger[index].SeatNumber = SeatNo;
            Console.WriteLine("Seat number has been canged successfully...");
            CLear();
        }
        static bool CheckSeat(int seatNo, List<Passengers> passengers)
        {
            bool flag = true;
            for (int i = 0; i < passengers.Count; i++)
            {
                if (seatNo == passengers[i].SeatNumber)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        static void ChangeLocation(int index,string location)
        {
            int fare = GetFare(location, Locations, Fares);
            Passenger[index].Location = location;
            Passenger[index].bill = fare;
            Console.WriteLine("Location has been updated successfully...");
            CLear();
        }

        static void CancelTicket(int index)
        {
                string confirm = Confirmation();
                if (confirm == "y")
                {
                    Passenger.RemoveAt(index);
                    Console.WriteLine("Ticket has been cancelled successfully...");
                    CLear();
                }
                else if (confirm == "n")
                {
                    OperationCancelled();
                }
                else
                {
                    Invalid();
                }       
        }

        static void OperationCancelled()
        {
            Console.WriteLine("Operation  has been cancelled successfully....");
            CLear();

        }

        static Feedback GiveFeedback()
        {
            Header();
            Feedback F = new Feedback();
            Console.WriteLine("     Your Feedback is very important for us      ");
            Console.WriteLine("+...............................................+");
            Console.Write("Enter your name here : ");
            F.Name = Console.ReadLine();
            Console.Write("Enter your feedback here : ");
            F.feedback = Console.ReadLine();
            return F;
        }
        static string Confirmation()
        {
            string confirm;
            Console.Write("Do you really want to continue? (y/n): ");
            confirm = Console.ReadLine();
            return confirm;
        }

        static void Invalid()
        {
            Console.WriteLine("\nInvalid entity"!);
            CLear();
        }

        static void WritePassengerData(string path, List<Passengers> P)
        {
            if (File.Exists(path))
            {
                StreamWriter file = new StreamWriter(path);
                for (int i = 0; i < P.Count; i++)
                {
                    file.WriteLine(P[i].PassenName + "," + P[i].CNICnumber + "," + P[i].SeatNumber + "," + P[i].Location + "," + P[i].bill);
                }
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
                    Passen.PassenName = ParseData(record, 1);
                    Passen.CNICnumber = ParseData(record, 2);
                    Passen.SeatNumber = int.Parse(ParseData(record, 3));
                    Passen.Location = ParseData(record, 4);
                    Passen.bill = int.Parse(ParseData(record, 5));
                    P.Add(Passen);
                }
                file.Close();
            }
        }

        static void StoreUsersFeedback(string path, List<Feedback> F)
        {
            if (File.Exists(path))
            {
                StreamWriter file = new StreamWriter(path);
                for (int i = 0; i < F.Count; i++)
                {
                    file.WriteLine(F[i].Name+","+F[i].feedback);
                }
                file.Flush();
                file.Close();
            }
        }

        static void ReadUserFeedback(string path, List<Feedback> F)
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    Feedback feedback = new Feedback();
                    feedback.Name = ParseData(record,1);
                    feedback.feedback = ParseData(record, 2);
                    F.Add(feedback);
                }
                file.Close();
            }
        }

        static string ManagerMenu()
        {
            string choice;
            Header();
            Console.WriteLine("+------------------------------------+");
            Console.WriteLine("1.\tView Bus Info");
            Console.WriteLine("2.\tCancel a ticket");
            Console.WriteLine("3.\tView Available locations");
            Console.WriteLine("4.\tUpdate locations and fares");
            Console.WriteLine("5.\tView feedbacks");
            Console.WriteLine("6.\tExit");
            Console.WriteLine("+....................................+");
            Console.Write("Please enter your choice : ");
            choice = Console.ReadLine();
            return choice;
        }

        static void ManagerInterface()
        {
            string path = "F:\\OOP PDs\\Lab 2\\MyProject\\Passengers.txt";
            string BusPath = "F:\\OOP PDs\\Lab 2\\MyProject\\Bus.txt";
            string feedbackPath = "F:\\OOP PDs\\Lab 2\\MyProject\\Feedbacks.txt";
            char[,] Bus = new char[50, 50];
            string choice = "";
            ReadBusInfo(BusPath, Bus);
            ReadPassengerData(path, Passenger);
            ReadUserFeedback(feedbackPath, feedbacks);
            while(choice != "6")
            {
                choice = ManagerMenu();
                if(choice == "1")
                {
                    ShowPassengerData(Bus);
                }
                else if(choice == "2")
                {
                    Console.Write("Enter name here to confirm : ");
                    string name = Console.ReadLine();
                    int index = GetIndex(Passenger, name);
                    if(index!=-1)
                    {
                        CancelTicket(index);
                        WritePassengerData(path, Passenger);
                    }
                    else
                    {
                        InvalidName();
                    }
                }

                else if(choice == "3")
                {
                    ViewLocations();
                }

                else if(choice == "4")
                {
                    UpdateLocationsInterface();
                }

                else if(choice == "5")
                {
                    ViewFeedbacks();
                }
            }

        }

        static void Gotoxy(int x,int y)
        {
            Console.SetCursorPosition(x, y);
        }

        static void ReadBusInfo(string path, char[,] Bus)
        {
            if(File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                int row = 0;
                while((record=file.ReadLine()) != null)
                {
                    for (int i = 0; i < record.Length; i++)
                    {
                        Bus[row, i] = record[i];
                    }
                    row++;

                }
                file.Close();
            }
        }

        static void PrintBusInfo(char[,] Bus)
        {
            Console.Clear();
            for(int i=0;i < 22; i++)
            {
                Gotoxy(10, 5 + i);
                for(int j=0;j<47;j++)
                {
                    Console.Write(Bus[i,j]);

                }
            }
            Gotoxy(60,10);
            Console.WriteLine("Press '0' to return back");
            Gotoxy(10,28);
            Console.Write("Please enter the seat number : ");
        }
        static void ShowPassengerData(char[,] Bus)
        {
            string seat = "";
            while(seat != "0")
            {
                PrintBusInfo(Bus);
                seat = Console.ReadLine();
                bool integerCheck = CheckInteger(seat);
                if(integerCheck)
                {
                    int seatNo = Convert.ToInt32(seat);
                    bool checkSeat = InvalidSeat(seatNo);
                    if (checkSeat)
                    {
                        int index = GetSeatIndex(seatNo);
                        ViewInformation(index);
                    }
                    else if (!checkSeat)
                    {
                        SeatCapacityError();
                    }
                }
                else
                {
                    Invalid();
                }
            }
        }

        static bool CheckInteger(string number)
        {
            bool flag = false;
            int count = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int num = number[i] - '0';
                if(num >=0 && num<=9)
                {
                    count++; 
                }
            }
            if(count == number.Length)
            {
                flag = true;
            }
            return flag;
        }
        static void SeatCapacityError()
        {
            Console.WriteLine("Our seat capacity is between  1 & 49");
            CLear();

        }

        static bool InvalidSeat(int seat)
        {
            bool flag = false;
            if(seat>=0 && seat <50)
            {
                flag = true;
            }
            return flag;
        }

        static int GetSeatIndex(int seat)
        {
            int index = -1;
            for(int i=0;i<Passenger.Count;i++)
            {
                if(seat == Passenger[i].SeatNumber)
                {
                    index = i;
                }
            }
            return index;        
        }

        static void ViewLocations()
        {
            Header();
            Console.WriteLine("Sr.no   Fares\t\tLocations");
            Console.WriteLine("+__________________________________+");
            for(int i=0;i<Locations.Count;i++)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}", i + 1, Fares[i], Locations[i]);
            }
            Console.WriteLine("+..................................+");
            CLear();
        }

        static string UpdateLocationMenu()
        {
            string option;
            Header();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("1.\tUpdate Fares");
            Console.WriteLine("2.\tAdd new location");
            Console.WriteLine("3.\tBack");
            Console.WriteLine("+......................................+");
            Console.Write("Please select an option : ");
            option = Console.ReadLine();
            return option;
        }

        static void UpdateLocationsInterface()
        {
            string option = "";
            while(option!="3")
            {
                option = UpdateLocationMenu();
                if(option == "1")
                {
                    Console.Write("Enter name of the location : ");
                    string location = Console.ReadLine();
                    int index = GetLocationIndex(location);
                    if(index!=-1)
                    {
                        Console.Write("Enter new fare for {0} : ",location);
                        int fare = int.Parse(Console.ReadLine());
                        ChangeFare(index, fare);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Location entered!");
                        CLear();
                    }
                }

                else if(option == "2")
                {
                    Console.Write("Enter name of new location : ");
                    string location = Console.ReadLine();
                    bool checkLocation = CheckLocation(location, Locations);
                    if(!checkLocation)
                    {
                        Console.Write("Set a fare for {0} : ",location);
                        int fare = int.Parse(Console.ReadLine());
                        AddLocation(location,fare);
                    }
                    else if(checkLocation)
                    {
                        Console.WriteLine("\nLocation is already in use!");
                        CLear();
                    }    
                }
            }
        }
        static int GetLocationIndex(string location)
        {
            int index = -1;
            for(int i=0;i<Locations.Count;i++)
            {
                if(location == Locations[i])
                {
                    index = i;
                }
            }
            return index;
        }

        static void ChangeFare(int index,int fare)
        {
            Fares[index] = fare;
            Console.WriteLine("\nFare has been changed successfully..");
            CLear();
        }

        static void AddLocation(string location,int fare)
        {
            Locations.Add(location);
            Fares.Add(fare);
            Console.WriteLine("\nA new location has been added successfully..");
            CLear();
        }

        static void ViewFeedbacks()
        {
            Header();
            for(int i=0;i<feedbacks.Count;i++)
            {
                Console.WriteLine("{0} : ",i+1);
                Console.WriteLine("+---------------------------------------------+");
                Console.WriteLine("Name : {0}", feedbacks[i].Name);
                Console.WriteLine("Feedback : {0}", feedbacks[i].feedback);
                Console.WriteLine("+.............................................+");
            }
            CLear();
        }
    }
}