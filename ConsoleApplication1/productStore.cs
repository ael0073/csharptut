using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace ConsoleApplication1
{
   
    public class productStore
    {
        private List<Products> Prodstore = new List<Products>();
        private const string DATA_FILENAME = "ProductStore.dat";
       
       
         

        public void Save()
        {
            using (StreamWriter myFile = new StreamWriter(DATA_FILENAME))
            {
                foreach (Products p in Prodstore)
                {
                   
                   myFile.WriteLine(p.Prodid);
                   myFile.WriteLine(p.Prodname);
                   myFile.WriteLine(p.Stock);
                   myFile.WriteLine(p.Unitprice);

                }
            }
            

        } // end public bool Load()

        public void Load()
        {
            using (StreamReader myFile = new StreamReader(DATA_FILENAME))
            {
                int index = 0;
                while (!myFile.EndOfStream)
                {
                    Products E = new Products();
                    E.Prodid = myFile.ReadLine();
                    E.Prodname = myFile.ReadLine();
                    E.Stock =Int32.Parse( myFile.ReadLine());
                    E.Unitprice = Int32.Parse(myFile.ReadLine());
                    Prodstore.Add(E);
                    index++;
                }
            }
           

        } 


        public int addProduct(Products p)
        {
            if (Prodstore.Count == 0)
            {
                Prodstore.Add(p);
                return 1;
            }
            else if (searchbyId(p.Prodid) == -1)
            {
                Prodstore.Add(p);
               // Console.WriteLine("ghadda minn hawn");
               // Console.WriteLine(p);
                return 1;
            }
            else
            {
                throw new Exception("Product already exists");
               // return 0;
            }

        }
        public int removeProduct(string id)
        {
            int index=searchbyId(id);
            if (index != -1)
            {
                Prodstore.RemoveAt(index);
                return 1;
            }
            else
            {
                throw new Exception("Product is not in the list");

            }
        }
        public Products getProd(int index)
        {
            return Prodstore[index];
        }
        public void print()
        {
            for (int i = 0; i < Prodstore.Count; i++)
            {
                Console.WriteLine(Prodstore[i]);
            }
        }
     
        public int searchbyId(string id)
        {
            
            for (int i = 0; i < Prodstore.Count; i++)
            {
                Console.WriteLine("hawn dahal");
                if (Prodstore[i].Prodid==id)
                {
                    
                    return i;
                }
            }
            return -1;
        }

    }
}
