using EntityFrameworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace _6_CreateNorthwindTwinDatabase
{
    class Program
    {
        static void Main()
        {
            NorthwindEntities db = new NorthwindEntities();

            //I have changed the connection string Catalog name from Northwind to NorthwindTwin. The next row creates the twin database
            db.Database.CreateIfNotExists();

            Console.WriteLine("The NorthwindTwin data has been created!");
        }
    }
}
