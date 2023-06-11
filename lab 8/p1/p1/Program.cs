using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p1.BL;

namespace p1
{
    class Program
    {
        static void Main(string[] args)
        {
            Cylinder object1 = new Cylinder();
            Cylinder object2 = new Cylinder(12,3);
            Cylinder object3 = new Cylinder(15 ,5, "Grey");
            object1.setHeight(3);
            object2.setHeight(4);
            object3.setHeight(6);
            Console.WriteLine("Volume: {0}", object1.getVolume());
            Console.WriteLine("Volume: {0}", object2.getVolume());
            Console.WriteLine("Volume: {0}", object3.getVolume());
            Console.ReadKey();
        }
    }
}
