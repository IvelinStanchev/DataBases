using EntityFrameworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_FindAllCustomersWhoseOrdersAreAtRange
{
    class Program
    {
        static void Main()
        {
            PrintAllCustomersWhoMadeOrdersInCertainYear("Canada", 1997);
        }

        private static void PrintAllCustomersWhoMadeOrdersInCertainYear(string country, int year)
        {
            NorthwindEntities db = new NorthwindEntities();

            using(db)
            {
                var orders = db.Orders.Where(o => o.OrderDate.Value.Year == year && o.ShipCountry == country).GroupBy(c => c.Customer.ContactName);

                foreach (var order in orders)
                {
                    Console.WriteLine(order.Key);
                }
            }
        }
    }
}
