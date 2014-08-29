using EntityFrameworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_DAO
{
    class Program
    {
        static void Main()
        {
            AddCustomer("ZPESH", "Pesho");

            //ModifyCustomer("ZPESH", "NewComanyNameTest");

            //DeleteCustomer("ZPESH");
        }

        private static void AddCustomer(string id, string companyName)
        {
            NorthwindEntities db = new NorthwindEntities();

            using (db)
            {
                Customer customer = new Customer()
                {
                    CustomerID = id,
                    CompanyName = companyName
                };

                db.Customers.Add(customer);
                db.SaveChanges();
                Console.WriteLine("Succefully added a customer with ID: {0}", id);
            }
        }

        private static void ModifyCustomer(string id, string companyName)
        {
            NorthwindEntities db = new NorthwindEntities();

            using (db)
            {
                var getCustomer = db.Customers.Find(id);

                getCustomer.CompanyName = companyName;

                db.SaveChanges();
                Console.WriteLine("Succefully modified a customer with ID: {0}", id);
            }
        }

        private static void DeleteCustomer(string id)
        {
            NorthwindEntities db = new NorthwindEntities();

            using (db)
            {
                var getCustomer = db.Customers.Find(id);

                db.Customers.Remove(getCustomer);

                db.SaveChanges();
                Console.WriteLine("Succefully deleted a customer with ID: {0}", id);
            }
        }
    }
}
