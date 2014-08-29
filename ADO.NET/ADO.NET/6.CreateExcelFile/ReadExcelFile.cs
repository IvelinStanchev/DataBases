using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.CreateExcelFile
{
    class ReadExcelFile
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
                    "SELECT * FROM [Sheet1$]", dbConn);

                OleDbDataReader reader = cmd.ExecuteReader();
                
                using (reader)
                {
                    while(reader.Read())
                    {
                        string name = (string)reader["Name"];
                        double scores = (double)reader["Score"];
                        Console.WriteLine("Name: {0} -> Scores: {1}", name, scores);
                    }
                }
            }
        }
    }
}
