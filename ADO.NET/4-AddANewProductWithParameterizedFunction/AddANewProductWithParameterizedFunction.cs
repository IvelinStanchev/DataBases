using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace _4_AddANewProductWithParameterizedFunction
{
    class AddANewProductWithParameterizedFunction
    {
        private SqlConnection dbCon;

        private void ConnectToDB()
        {
            dbCon = new SqlConnection(Settings.Default.DBConnectionString);
            dbCon.Open();
        }

        private void DisconnectFromDB()
        {
            if (dbCon != null)
            {
                dbCon.Close();
            }
        }

        private int InsertProduct(string productName, int supplierID, 
            int categoryID, string quantityPerUnit, decimal unitPrice,
            int unitsInStock, int unitOnOrder, int reorderLevel, bool discontinued)
        {
            SqlCommand cmdInsertProduct = new SqlCommand(
                "INSERT INTO Products(ProductName, SupplierID, " + 
                "CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                "VALUES (@productName, @supplierID, @categoryID, @quantityPerUnit, " + 
                "@unitPrice, @unitsInStock, @unitOnOrder, @reorderLevel, @discontinued)", dbCon);
            cmdInsertProduct.Parameters.AddWithValue("@productName", productName);
            cmdInsertProduct.Parameters.AddWithValue("@supplierID", supplierID);
            cmdInsertProduct.Parameters.AddWithValue("@categoryID", categoryID);
            cmdInsertProduct.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            cmdInsertProduct.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmdInsertProduct.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            cmdInsertProduct.Parameters.AddWithValue("@unitOnOrder", unitOnOrder);
            cmdInsertProduct.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            cmdInsertProduct.Parameters.AddWithValue("@discontinued", discontinued);
            cmdInsertProduct.ExecuteNonQuery();

            SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
            int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
            return insertedRecordId;
        }

        static void Main()
        {
            AddANewProductWithParameterizedFunction example = new AddANewProductWithParameterizedFunction();
            try
            {
                example.ConnectToDB();

                int newProductId = example.InsertProduct("PeshoTest", 1, 1, "16 pies", 15, 5, 2, 3, false);
                Console.WriteLine("Inserted new project. " +
                    "ProductID = {0}", newProductId);
            }
            finally
            {
                example.DisconnectFromDB();
            }
        }
    }
}
