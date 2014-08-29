using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_AllCategoriesWithItsProducts
{
    class AllCategoriesWithItsProducts
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection("Server=.\\SQLEXPRESS; " +
                "Database=Northwind; Integrated Security=true");
            connection.Open();
            using(connection)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT CategoryName, ProductName FROM Categories c JOIN" + 
                    " Products p ON c.CategoryID = p.CategoryID ORDER BY CategoryName", connection
                    );

                SqlDataReader reader = command.ExecuteReader();

                using(reader)
                {
                    while (reader.Read())
                    {
                        string category = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];
                        Console.WriteLine("{0} -> {1}", category, productName);
                    }
                }
            }
        }
    }
}
