using EntityFrameworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_CreateOrderWithTransaction
{
    class Program
    {
        static void InsertOrder(
        string shipName, string shipAddress,
        string shipCity, string shipRegion,
        string shipPostalCode, string shipCountry,
        string customerID = null, int? employeeID = null,
        DateTime? orderDate = null, DateTime? requiredDate = null,
        DateTime? shippedDate = null, int? shipVia = null,
        decimal? freight = null)
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                Order newOrder = new Order
                {
                    ShipAddress = shipAddress,
                    ShipCity = shipCity,
                    ShipCountry = shipCountry,
                    ShipName = shipName,
                    ShippedDate = shippedDate,
                    ShipPostalCode = shipPostalCode,
                    ShipRegion = shipRegion,
                    ShipVia = shipVia,
                    EmployeeID = employeeID,
                    OrderDate = orderDate,
                    RequiredDate = requiredDate,
                    Freight = freight,
                    CustomerID = customerID
                };

                context.Orders.Add(newOrder);

                context.SaveChanges();

                Console.WriteLine("Row is inserted.");
            }
        }

        static void InsertMultiple()
        {
            for (int i = 0; i < 5; i++)
            {
                InsertOrder(null, null, null, null, null, null, null, null, null, null, null, null, null);
            }
        }

        static void Main()
        {
            NorthwindEntities context = new NorthwindEntities();

            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                using (context)
                {
                    InsertMultiple();
                    context.SaveChanges();

                    dbContextTransaction.Rollback();
                }
            }
        }
    }
}
