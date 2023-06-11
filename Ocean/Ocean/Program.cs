namespace Ocean
{
    internal class Program
    {
        static char degree = '\u00b0';
        static List<Ship> ships = new List<Ship>();
        static void Main(string[] args)
        {
            string choice = "";
            while(choice != "5")
            {
                choice = Menu();
                if(choice == "1") 
                {
                    Ship S = Addship();
                    ships.Add(S);
                    Console.WriteLine("Ship info has been saved..");
                    Clear();
                }
                else if(choice == "2") 
                {
                    Console.WriteLine("Enter serial number : ");
                    string serial = Console.ReadLine();
                    Ship S = new Ship(serial);
                    S.ShowShip(ships);
                    Clear();
                }
                else if (choice == "3")
                {
                    Console.Write("Enter longitude : ");
                    string longitude = Console.ReadLine();
                    Console.Write("Enter latitude : ");
                    string latitude = Console.ReadLine();
                    string serial = GetSerialNumber(longitude, latitude,ships);
                    Console.WriteLine("Serial number is : {0}",serial);
                    Clear();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Enter serial number : ");
                    string serial = Console.ReadLine();
                    Ship S = new Ship(serial);
                    int index = S.ViewIndex(ships);
                    if(index!=-1)
                    {
                        Ship ship = ChangeShipInfo();
                        ships.Insert(index, ship);
                        Console.WriteLine("\nShip information has been changed successfully...");
                        Clear();
                    }
                }
                else if (choice == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid entity!");
                    Clear();
                }
            }
        }

        static void Clear()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        static void Header()
        {
            Console.Clear();
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine("*                            OCEAN NAVIGATION SYSTEM                          *");
            Console.WriteLine("*******************************************************************************");
        }
        static string Menu()
        {
            Header();
            string choice = "";
            Console.WriteLine("+----------------------------------------------------------+");
            Console.WriteLine("1.\tAdd Ship");
            Console.WriteLine("2.\tView Ship position");
            Console.WriteLine("3.\tView Ship serial number");
            Console.WriteLine("4.\tChange Ship position");
            Console.WriteLine("5.\tExit");
            Console.WriteLine("+..........................................................+");
            Console.Write("Please enter a choice : ");
            choice = Console.ReadLine();
            return choice;
        }

        static Ship Addship()
        {
            Console.Write("Enter Ship Number  : ");
            string number = Console.ReadLine();
            Console.WriteLine("Enter Ship Latitude : ");
            Console.Write("Enter Latitude's Degree : ");
            int latdegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Minutes : ");
            float latminutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Direction : ");
            char latdirection = char.Parse(Console.ReadLine());

            Console.WriteLine("Enter Ship Longitude : ");
            Console.Write("Enter Lonngitude's Degree : ");
            int longdegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Minutes : ");
            float longminutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Direction : ");
            char longdirection = char.Parse(Console.ReadLine());
            if (number != null && latdegree != null && latminutes != null && latdirection != null && longdegree != null && longminutes != null && longdirection != null)
            {
                Angle lati = new Angle(latdegree, latminutes, latdirection);
                Angle longi = new Angle(longdegree, longminutes, longdirection);
                Ship S = new Ship(number, lati, longi);
                return S;
            }
            return null;
        }

        static string GetSerialNumber(string longitude, string latitude, List<Ship> S)
        {
            char degree = '\u00b0';
            string longi = "";
            string lati = "";
            string SerialNumber = "";
            foreach (Ship s in S)
            {
                lati = s.Latitude.Degrees + " "+ s.Latitude.Minutes + " " + s.Latitude.Direction;
                longi = s.Longitude.Degrees+ " " + s.Longitude.Minutes + " " + s.Longitude.Direction;
                if (lati == latitude && longi == longitude)
                {
                    SerialNumber = s.ShipNumber;
                    break;
                }
                longi = "";
                lati = "";
            }
            return SerialNumber;
        }

        static Ship ChangeShipInfo()
        {
            Console.Write("Enter new ship number  : ");
            string number = Console.ReadLine();
            Console.WriteLine("Enter new ship latitude....");
            Console.Write("Enter Latitude's Degree : ");
            int latdegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Minutes : ");
            float latminutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Direction : ");
            char latdirection = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter new ship longitude...");
            Console.Write("Enter Lonngitude's Degree : ");
            int longdegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Minutes : ");
            float longminutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Direction : ");
            char longdirection = char.Parse(Console.ReadLine());
            if (number != null && latdegree != null && latminutes != null && latdirection != null && longdegree != null && longminutes != null && longdirection != null)
            {
                Angle lati = new Angle(latdegree, latminutes, latdirection);
                Angle longi = new Angle(longdegree, longminutes, longdirection);
                Ship S = new Ship(number, lati, longi);
                return S;
            }
            return null;
        }

  


    }
}