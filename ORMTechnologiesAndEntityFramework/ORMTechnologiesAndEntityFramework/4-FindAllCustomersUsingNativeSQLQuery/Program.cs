using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkLibrary;

namespace _4_FindAllCustomersUsingNativeSQLQuery
{
    class Program
    {
        static void Main()
        {
            PrintAllCustomersWhoMadeOrdersInCertainYear("Canada", 1997);
        }

        static void PrintAllCustomersWhoMadeOrdersInCertainYear(string country, int year)
        {
            NorthwindEntities db = new NorthwindEntities();

            string nativeSqlQuery =
                "SELECT c.CustomerID " +
                "FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID " +
                "WHERE YEAR(o.OrderDate) = {0} " +
                "AND o.ShipCountry = {1} " +
                "GROUP BY c.CustomerID";

            object[] parameters = { year, country };
            var customers = db.Database.SqlQuery<string>(nativeSqlQuery, parameters);

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
