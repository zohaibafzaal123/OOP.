using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3.BL
{
    class Animal
    {
        protected string name;
        public Animal(string name)
        {
            this.name = name;
        }
        public string toString()
        {
            return ("Name: "+name);
        }
    }
}
