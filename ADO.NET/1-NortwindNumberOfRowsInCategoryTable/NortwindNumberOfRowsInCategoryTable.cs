using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_NortwindNumberOfRowsInCategoryTable
{
    class NortwindNumberOfRowsInCategoryTable
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", dbCon);
                int rowsCount = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("Rows count: {0} ", rowsCount);
                Console.WriteLine();
            }
        }
    }
}
