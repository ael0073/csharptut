using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrdersConsoleApplication
{
    class OrderStore
    {
        List<Orders> orderList = new List<Orders>();
        public void loadOrdersFromFile()
        {
            //check if file exists
            string f = "OrderStore.dat";
            if (File.Exists(f))
            {
                /*if file exists, customers must be read one at a time from the file
                 * all the customer properties are stored on separate lines of the file
                 * file is read one line at a time and after all the properties of each customer are read, customerList is updated
                 */
                using (StreamReader stream = new StreamReader(f))
                {
                    while (!stream.EndOfStream)
                    {
                        string ID = stream.ReadLine();
                        string cID = stream.ReadLine();
                        List<string> prods = new List<string>();
                        for(;;)
                        {
                            string check = stream.ReadLine();
                            int value;
                            if(int.TryParse(check, out value))
                            {
                                //in the case where an integer is found, this is the qty field not the product field so list of products has ended
                                break;
                            } 
                            else
                            {
                                //a product ID has been found and so must be added to the product list
                                prods.Add(check);
                            }
                        }

                        int qty = Int32.Parse(stream.ReadLine());
                        double price = Double.Parse(stream.ReadLine());
                        string date = stream.ReadLine();
                        Orders ordr = new Orders(ID, cID, prods, qty, price, date);
                        addOrder(ordr);
                    }
                    stream.Close();
                }
            }
            else
            {
                Console.WriteLine("Creating file");
                //file must be created
                FileStream F = new FileStream("CustomerStore.dat", FileMode.CreateNew, FileAccess.ReadWrite);
                F.Close();
            }
        }

        public void addOrder(Orders o)
        {
            Console.WriteLine("Order Store ID: {0}", o.orderID);
            //check if the ID of the customer to be added is already in the list
            bool check = searchOrders(o.orderID);
            if (check)
            {
                Console.WriteLine("ID ALREADY EXISTS");
                //throw new Exception("Duplicate Order ID");
            }
            else
            {
                orderList.Add(o);
            }

        }

        public bool searchOrders(string id)
        {
            foreach (Orders ordr in orderList)
            {
                if ((ordr.orderID).Equals(id, StringComparison.Ordinal))
                {
                    Console.WriteLine("An order with that ID already exists\n");
                    return true;
                }
            }
            return false;
        }

        public bool removeOrder(string id)
        {
            bool check = searchOrders(id);
            if (check)
            {
                Console.WriteLine("remove order");
                var itemToRemove = orderList.Single(r => r.customerID == id);
                orderList.Remove(itemToRemove);
                return true;
            }
            else
            {
                //throw new Exception("Customer not found");
                Console.WriteLine("Order not found");
                return false;
            }
        }

        public void saveCustomersToFile()
        {
            Console.WriteLine("These are the contents of the order list\n");
            foreach (Orders o in orderList)
            {
                Console.WriteLine(o.orderID);
                Console.WriteLine(o.productID);
                Console.WriteLine(o.customerID);
                Console.WriteLine(o.orderQuantity);
                Console.WriteLine(o.orderPrice);
                Console.WriteLine(o.orderDate);
            }
            StreamWriter sw = new StreamWriter("OrderStore.dat", true);
            foreach (Orders o in orderList)
            {
                sw.WriteLine(o.orderID);
                sw.WriteLine(o.customerID);
                
                foreach(string pID in o.productID)
                {
                    sw.WriteLine(pID);
                }
                sw.WriteLine(o.orderQuantity);
                sw.WriteLine(o.orderPrice);
                sw.WriteLine(o.orderDate);

            }
            sw.Close();
        }

    }
}
