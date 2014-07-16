using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Orders
    {
        private string ID;
        private string cID; //customer ID from Customers.cs
        private List<string> pID; //product ID from Products.cs
        private int qty;
        private double ordrprice;
        private string ordrDate;

        public Orders(string id, string customerID, List<string> productID, int quantity, double price, string date)
        {
            ID = id;
            cID = customerID;
            pID = productID;
            qty = quantity;
            ordrprice = price;
            ordrDate = date;
        }

        //setting up properties & mutators
        public string orderID
        {
            get
            {
                return ID;
            }
            set
            {
                orderID = value;
            }
        }

        public string customerID
        {
            get
            {
                return cID;
            }
            set
            {
                customerID = value;
            }
        }

        public List<string> productID
        {
            get
            {
                return pID;
            }
            set
            {
                productID = value;
            }
        }

        public int orderQuantity
        {
            get
            {
                return qty;
            }
            set
            {
                orderQuantity = value;
            }
        }

        public double orderPrice
        {
            get
            {
                return ordrprice;
            }
            set
            {
                orderPrice = value;
            }
        }

        public string orderDate
        {
            get
            {
                return ordrDate;
            }
            set
            {
                orderDate = value;
            }
        }
    }
}
