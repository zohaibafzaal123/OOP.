using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean
{
    internal class Angle
    {
        public int Degrees;
        public float Minutes;
        public char Direction;

        public Angle(int Degrees, float Minutes, char Direction)
        {
            this.Degrees = Degrees;
            this.Minutes = Minutes;
            this.Direction = Direction;
        }
    }
}
