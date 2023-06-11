using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean
{
    internal class Ship
    {
        public string ShipNumber;
        public Angle Longitude;
        public Angle Latitude;

        public Ship(string shipNumber)
        {
            this.ShipNumber = shipNumber;
        }
        public Ship(string ShipNumber,Angle Longitude,Angle Latitude)
        {
            this.ShipNumber = ShipNumber;
            this.Longitude = Longitude;
            this.Latitude = Latitude;
        }

        public void ShowPosition()
        {
            char degree = '\u00b0';
            Console.WriteLine("Ship is at " + Latitude.Degrees + degree + Latitude.Minutes + " " + Latitude.Direction + " " + Longitude.Degrees + degree + Longitude.Minutes + " " + Longitude.Direction);
        }

        

        public void ShowShip(List<Ship> Ship) 
        {
            foreach(Ship S in Ship)
            {
                if(ShipNumber == S.ShipNumber)
                {
                    S.ShowPosition();
                }
            } 
        }

        public int ViewIndex(List<Ship> ship)
        {
            int index = -1;
            for (int i = 0; i < ship.Count; i++)
            {
                if (ShipNumber == ship[i].ShipNumber)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }

    
}
