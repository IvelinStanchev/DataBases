using EntityFrameworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_AllSalesByGivenRegionAndPeriod
{
    class Program
    {
        static void Main()
        {
            PrintAllSales("Co. Cork", 1998, 2000);
        }

        private static void PrintAllSales(string region, int startYear, int endYear)
        {
            NorthwindEntities db = new NorthwindEntities();

            using(db)
            {
                var orders = db.Orders.Where(o => o.OrderDate.Value.Year >= startYear 
                                                && o.OrderDate.Value.Year <= endYear 
                                                && o.ShipRegion == region).GroupBy(c => c.Customer.ContactName);

                foreach (var order in orders)
                {
                    Console.WriteLine(order.Key);
                }
            }
        }
    }
}
