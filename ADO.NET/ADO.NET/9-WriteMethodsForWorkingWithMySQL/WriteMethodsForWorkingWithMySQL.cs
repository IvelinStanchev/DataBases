using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_WriteMethodsForWorkingWithMySQL
{
    class WriteMethodsForWorkingWithMySQL
    {
        private static MySqlConnection dbCon;

        public static void Main()
        {
            string user = "root";
            string pass = "";
            dbCon = new MySqlConnection("Server=localhost; Port=3306; Database=Books; Uid=" + user + "; Pwd=" + pass + "; pooling=true");

            dbCon.Open();

            using (dbCon)
            {
                string search = "%";
                FindBooks(search);

                ListAllBooks();

                InsertBook("Test Book Number One", "Pesho Petrov", "123435", new DateTime(2013,07,01));
            }

        }

        private static void InsertBook(string title, string author, string isbn, DateTime publishDate)
        {
            MySqlCommand query = new MySqlCommand("Insert Into Books(Title, Author, PublishDate, ISBN) VALUES(@Title, @Author, @PublishDate, @ISBN)", dbCon);
            query.Parameters.AddWithValue("@Title", title);
            query.Parameters.AddWithValue("@Author", author);
            query.Parameters.AddWithValue("@PublishDate", publishDate);
            query.Parameters.AddWithValue("@ISBN", isbn);

            query.ExecuteNonQuery();
            Console.WriteLine("Book: {0}, Successfully added!", title);

        }

        private static void ListAllBooks()
        {
            MySqlCommand query = new MySqlCommand("SELECT Books.Title FROM Books", dbCon);

            MySqlDataReader reader = query.ExecuteReader();

            using (reader)
            {
                Console.WriteLine("All Books:");
                while (reader.Read())
                {
                    Console.WriteLine("Book:" + (string)reader["Title"]);
                }
            }
        }

        private static void FindBooks(string searchedString)
        {
            string escapeString = "/";
            searchedString = searchedString.Replace("%", escapeString + "%");
            searchedString = searchedString.Replace("_", escapeString + "_");
            searchedString = searchedString.Replace("\\", escapeString + "\\");

            MySqlCommand query = new MySqlCommand("SELECT Books.Title FROM Books WHERE Books.Title LIKE '%" + searchedString + "%' ESCAPE '" + escapeString + "' ", dbCon);
            query.Parameters.AddWithValue("@input", searchedString);

            MySqlDataReader reader = query.ExecuteReader();

            using (reader)
            {
                Console.WriteLine("Books Found:");
                while (reader.Read())
                {
                    Console.WriteLine("Book:" + (string)reader["Title"]);
                }
            }
        }
    }
}
