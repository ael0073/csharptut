using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            productStore storep = new productStore();
            CustomerStore storec = new CustomerStore();
           
           

           storep.Load();
            Products p = new Products("gt35", "garteh T-32", 7, 9);
            Customers c = new Customers("Alastair","vella","352494m","0");
            Customers c1 = new Customers("Katia", "Abela", "352494m", "0");
           // Products p1 = new Products("gt32F", "garteh T-31", 7, 9);

            storec.addCustomer(c);
            storec.addCustomer(c1);
            try
            {
                storep.addProduct(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            /*try
            {
                storep.addProduct(p1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }*/
            

            Console.WriteLine("The first product is :" + storep.getProd(0));
            Console.WriteLine("The first product is :" + storep.getProd(1));
            Console.ReadLine();

            /*try
            {
                storep.removeProduct(p.Prodid);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }*/
            Console.WriteLine("all Products");
            storep.print();
            Console.WriteLine("all Customers");
            storec.print();
            storep.Save();
            
            Console.ReadLine();
        }
    }
}
