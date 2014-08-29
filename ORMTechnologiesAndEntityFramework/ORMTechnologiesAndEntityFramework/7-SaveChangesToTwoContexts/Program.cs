using EntityFrameworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_SaveChangesToTwoContexts
{
    class Program
    {
        static void Main()
        {
            NorthwindEntities db1 = new NorthwindEntities();
            NorthwindEntities db2 = new NorthwindEntities();

            using(db1)
            {
                using(db2)
                {
                    var firstCustomer = db1.Customers.Find("BONAP");
                    firstCustomer.City = "Pesho";

                    var secondCustomer = db2.Customers.Find("BOTTM");
                    secondCustomer.City = "Gosho";

                    db1.SaveChanges();
                    db2.SaveChanges();
                }
            }

            Console.WriteLine("The changes are done!");
        }
    }
}
