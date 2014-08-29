using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkLibrary;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            NorthwindEntities db = new NorthwindEntities();

            using (db)
            {
                foreach (var customer in db.Customers)
                {
                    Console.WriteLine(customer.ContactName);
                }
            }
        }
    }
}
