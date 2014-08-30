using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_NameAndDescriptionFromCategoriesTable
{
    class NameAndDescriptionFromCategoriesTable
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection("Server=.\\SQLEXPRESS; " +
                "Database=Northwind; Integrated Security=true");
            connection.Open();
            using(connection)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT CategoryName, Description FROM Categories", connection
                    );

                SqlDataReader reader = command.ExecuteReader();

                using(reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("Name: {0} -> Description: {1}", name, description);
                    }
                }
            }
        }
    }
}

/*SqlDataReader reader = cmdAllEmployees.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    decimal salary = (decimal)reader["Salary"];
                    Console.WriteLine("{0} {1} - {2}", firstName, lastName, salary);
                }
            }*/
