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
           
           
           

           storep.Load();
            Products p = new Products("gt32", "garteh T-32", 7, 9);
           // Products p1 = new Products("gt32F", "garteh T-31", 7, 9);
            

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
            storep.print();
            storep.Save();
            
            Console.ReadLine();
        }
    }
}
