using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Customers
    {
        //encapsulated variables
        private string custName;
        private string custSurname;
        private string custID;
        private string custMob;

        //parametrised constructor
        public Customers(string name, string surname, string id, string mobile)
        {
            custName = name;
            custSurname = surname;
            custID = id;
            custMob = mobile;
        }

        //setting up properties & mutators
        public string customerID
        {
            get
            {
                return custID;
            }
            set
            {
                custID = value;
            }
        }

        public string customerName
        {
            get
            {
                return custName;
            }
            set
            {
                custName = value;
            }
        }

        public string customerSurname
        {
            get
            {
                return custSurname;
            }
            set
            {
                custSurname = value;
            }
        }

        public string customerMobile
        {
            get
            {
                return custMob;
            }
            set
            {
                custMob = value;
            }
        }

        public override string ToString()
        {
            return "ID: "+customerID + ", Name: " + customerName + ", Surname: " + customerSurname + ", Mobile: " +customerMobile;
        }
    }
}
