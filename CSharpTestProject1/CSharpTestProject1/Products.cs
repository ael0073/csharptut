using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTestProject1
{
    class Products
    {
        private string prodid;
        private string prodname;
        private int stock;
        private int unitprice;

        public Products()
        {
            prodid = "";
            prodname = "";
            stock = 0;
            unitprice = 0;
        }
        public Products(string id, string name, int stk, int prc)
        {
            prodid = id;
            prodname = name;
            stock = stk;
            unitprice = prc;

        }
        public string Prodid
        {
            get { return prodid; }
            set { prodid = value; }
        }
        public string Prodname
        {
            get { return prodname; }
            set { prodname = value; }
        }
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        public int Unitprice
        {
            get { return unitprice; }
            set { unitprice = value; }
        }
    }
}
