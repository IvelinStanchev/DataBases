using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _5_SavingImagesInTheFil
{
    class RetrievesPicturesFormDatabaseAndSavesThem
    {
        const string FILE_LOCATION = @"..\..\images\";
        const string FILE_EXTENSION = @".jpg";

        static void Main()
        {
            ExtractImageFromDB();
        }

        static void ExtractImageFromDB()
        {
            SqlConnection dbConn = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");

            dbConn.Open();

            using (dbConn)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT Picture, CategoryID FROM Categories", dbConn);

                var reader = command.ExecuteReader();

                using(reader)
                {
                    while (reader.Read())
                    {
                        byte[] image = (byte[])reader["Picture"];
                        string categoryId = reader["CategoryID"].ToString().Replace('/', '_');
                        int len = image.Length;
                        int header = 78;
                        byte[] imgData = new byte[len - header];
                        Array.Copy(image, 78, imgData, 0, len - header);

                        WriteBinaryFile(imgData, FILE_LOCATION + categoryId + FILE_EXTENSION);
                        image = null;
                    }
                }

                Console.WriteLine("Successfully added! Check Images folder in the project folder!");
            }
        }

        static void WriteBinaryFile(byte[] fileContents, string fileLocation)
        {
            FileStream stream = new FileStream(fileLocation, FileMode.Create);
            using (stream)
            {
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }
    }
}
