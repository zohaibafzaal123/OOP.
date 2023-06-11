using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Passengers
    {
        public string name;
        public string CNIC;
        public int seatNo;
        public string location;
        public int price;

        public Passengers()
        {
            name = string.Empty;
            seatNo = 0;
            CNIC = string.Empty;
            price = 0;
            location = string.Empty;
        }
        public Passengers(string Name)
        {
            name = Name;
        }

        public Passengers(string Name, string cnic)
        {
            name = Name;
            CNIC = cnic;
        }

        public Passengers(string Name,int seat)
        {
            name = Name;
            seatNo = seat;
        }

        public Passengers(string Name,string Loc,int fare)
        {
            name = Name;
            location = Loc;
            price = fare;
        }

        public Passengers(string Name, string cnic, int SeatNo, string Location)
        {
            name = Name;
            CNIC = cnic;
            seatNo = SeatNo;
            location = Location;
        }

        public Passengers(string Name, string cnic, int SeatNo, string Location, int Price)
        {
            name = Name;
            CNIC = cnic;
            seatNo = SeatNo;
            location = Location;
            price = Price;
        }

        public bool CheckSeat(List<Passengers> Pass)
        {
            bool flag = true;
            foreach (Passengers P in Pass)
            {
                if (name == P.name || seatNo == P.seatNo)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        public bool CheckCNICLength()
        {
            bool flag = false;
            int count = 0;
            foreach (char c in CNIC)
            {
                int num = c - '0';
                if (num >= 0 && num <= 9)
                {
                    count++;
                }
            }
            if (count == 13)
            {
                flag = true;
            }
            return flag;
        }

        public bool CheckLocation(List<string> Location)
        {
            bool flag = false;
            foreach (string loc in Location)
            {
                if (location == loc)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public bool CheckCNIC(List<Passengers> P)
        {
            bool flag = true;
            foreach (Passengers Pass in P)
            {
                if (Pass.CNIC == CNIC)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        public bool CheckSeatNumberLength()
        {
            bool flag = false;
            if (seatNo > 0 && seatNo < 50)
            {
                flag = true;
            }
            return flag;
        }

        public int GetFare(List<string> Locations, List<int> Price)
        {
            int fare = -1;
            for (int i = 0; i < Locations.Count; i++)
            {
                if (location == Locations[i])
                {
                    fare = Price[i];
                }
            }
            return fare;
        }

        public int GetIndex(List<Passengers> Pass)
        {
            int index = -1;
            for (int i = 0; i < Pass.Count; i++)
            {
                if (name == Pass[i].name)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public bool CheckPassengerName(List<Passengers> Pass)
        {
            bool flag = true;
            foreach(Passengers P in Pass)
            {
                if(name == P.name)
                {
                    flag = false;
                }
            }
            return flag;
        }

        public bool CheckSeatNumber(List<Passengers> Pass)
        {
            bool flag = true;
            foreach (Passengers P in Pass)
            {
                if (seatNo == P.seatNo)
                {
                    flag = false;
                }
            }
            return flag;
        }

        public void ChangePassengerName(int index,List<Passengers> P)
        {
            P[index].name = name;
        }

        public void ChangeCNICNumber(int index,List<Passengers> P)
        {
            P[index].CNIC = CNIC;
        }

        public void ChangeSeatNumber(int index,List<Passengers> P)
        {
            P[index].seatNo = seatNo;
        }

        public void ChangeLocationAndFare(int index,List<Passengers> P)
        {
            P[index].location = location;
            P[index].price = price;
        }




    }
}
