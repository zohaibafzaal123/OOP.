using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3.BL
{
    class Mammal : Animal
    {
        public Mammal(string name)
        {
            this.name = name;
        }
        public string toString()
        {
            return (base.toString());
        }
    }
}
