using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_ReadsStringFromConsoleAndGetsTheValueFromProducts
{
    class ReadsStringFromConsoleAndGetsTheValueFromProducts
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");

            dbCon.Open();

            string searchString = Console.ReadLine().Replace("%", "[%]")
                                                    .Replace("_", "[_]");

            using (dbCon)
            {
                SqlCommand command = new SqlCommand(@"
                                                    SELECT ProductName FROM Products
                                                    WHERE ProductName LIKE @searchString", dbCon);
                command.Parameters.AddWithValue("@searchString", "%" + searchString + "%");

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    Console.WriteLine("All products:");
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];

                        Console.WriteLine("Product name: {0}", productName);
                    }
                }
            }
        }
    }
}
