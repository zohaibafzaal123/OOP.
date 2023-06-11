using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p2.BL;

namespace p2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            Student object1 = new Student("Ali", "Khalid Hall", "BS-CS", 1, 50000);
            Student object2 = new Student("Ali", "Khalid Hall", "BS-CS", 2, 40000);
            Staff object01 = new Staff("Ali", "Khalid Hall", "UET-Taxila", 50000);
            Staff object02 = new Staff("Ali", "Khalid Hall", "UET-Lahore", 50000);
            
            persons.Add(object1);
            persons.Add(object2);
            persons.Add(object01);
            persons.Add(object02);

            foreach (Person p in persons)
            {
                Console.WriteLine(p);
            }
            Console.ReadKey();

        }
    }
}
