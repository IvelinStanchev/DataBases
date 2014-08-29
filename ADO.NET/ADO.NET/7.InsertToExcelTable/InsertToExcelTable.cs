using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.InsertToExcelTable
{
    class InsertToExcelTable
    {
        static void Main()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=..\..\NamesAndScores.xlsx;Extended Properties=""Excel 12.0 XML;HDR=Yes""";

            OleDbConnection dbConn = new OleDbConnection(connectionString);

            dbConn.Open();
            using (dbConn)
            {
                OleDbCommand cmd = new OleDbCommand(
                    "INSERT INTO [Sheet1$] ([Name], [Score]) VALUES (@name, @score)", dbConn);

                cmd.Parameters.AddWithValue("@user", "PeshoTest");
                cmd.Parameters.AddWithValue("@score", 100);

                try
                {
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Row inserted successfully.");
                }
                catch (OleDbException exception)
                {
                    Console.WriteLine("SQL Error occured: " + exception);
                }
            }
        }
    }
}
