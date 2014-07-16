using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTestProject1
{
  
        class CustomerStore
        {
            List<Customers> customerList = new List<Customers>();

            public void loadCustomersFromFile()
            {
                //check if file exists
                string f = "CustomerStore.dat";
                if(File.Exists(f))
                {
                    Console.WriteLine("File exists");
                    /*if file exists, customers must be read one at a time from the file
                     * all the customer properties are stored on separate lines of the file
                     * file is read one line at a time and after all the properties of each customer are read, customerList is updated
                     */
                    using(StreamReader stream = new StreamReader(f))
                    {
                        while (!stream.EndOfStream)
                        {
                            string ID = stream.ReadLine();
                            string name = stream.ReadLine();
                            string surname = stream.ReadLine();
                            string mobile = stream.ReadLine();
                            Customers cst = new Customers(ID, name, surname, mobile);
                            addCustomer(cst);
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

             public void addCustomer(Customers c)
            {
                Console.WriteLine("Customer Store ID: {0}", c.customerID);
               //check if the ID of the customer to be added is already in the list
               bool check = searchCustomers(c.customerID);
               if(check)
               {
                   Console.WriteLine("ID ALREADY EXISTS");
                   //throw new Exception("Duplicate ID");
               } else
               {
                   customerList.Add(c);
               }

            }

            public bool searchCustomers(string id)
            {
                foreach (Customers cst in customerList)
                {
                    if ((cst.customerID).Equals(id, StringComparison.Ordinal))
                    {
                        Console.WriteLine("A customer with that ID already exists\n");
                        return true;
                    }
                }
                return false;
            }

            public bool removeCustomer(string id)
            {
               bool check = searchCustomers(id);
               if(check)
               {
                   Console.WriteLine("remove");
                   var itemToRemove = customerList.Single(r => r.customerID == id);
                   customerList.Remove(itemToRemove);
                   return true;
               } else
               {
                  //throw new Exception("Customer not found");
                   Console.WriteLine("Customer not found");
                   return false;
               }
            }

            public void saveCustomersToFile()
            {
                Console.WriteLine("These are the contents of the customer list\n");
                foreach (Customers c in customerList)
                {
                    Console.WriteLine(c.customerID);
                    Console.WriteLine(c.customerSurname);
                    Console.WriteLine(c.customerName);
                    Console.WriteLine(c.customerMobile);

                }
                StreamWriter sw = new StreamWriter("CustomerStore.dat", true);
                foreach(Customers c in customerList)
                {
                    sw.WriteLine(c.customerID);
                    sw.WriteLine(c.customerName);
                    sw.WriteLine(c.customerSurname);
                    sw.WriteLine(c.customerMobile);
                }
                sw.Close();
            }

            
        }
    
}
