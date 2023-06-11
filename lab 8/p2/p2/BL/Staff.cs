using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2.BL
{
    class Staff : Person
    {
        string school;
        double pay;
        public Staff(string name, string address, string school, double pay) : base(name, address)
        {
            this.school = school;
            this.pay = pay;
        }
        public string getSchool()
        {
            return school;
        }
        public void setSchool(string school)
        {
            this.school = school;
        }
        public double getPay()
        {
            return pay;
        }
        public void setPay(double pay)
        {
            this.pay = pay;
        }
        public override string toString()
        {
            return (base.toString() + "School: " + school + "Pay: " + pay);
        }
    }
}
