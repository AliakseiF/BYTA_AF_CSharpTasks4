using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace DataBaseTask
{
    internal class DataBaseTask
    {
        private static void Main(string[] args)
        {
            //opening connection
            string conStr = ConfigurationManager.AppSettings["conStr"];
            var sqlCon = new SqlConnection();
            sqlCon.ConnectionString = conStr;
            Console.WriteLine("\nConnecting to server: {0}, DB: {1}", sqlCon.DataSource, sqlCon.Database);
            sqlCon.Open();

            //add new supplier
            Console.WriteLine("\nPlease enter new Supplier company name: ");
            string compName = Console.ReadLine();
            AddNewSupplier(compName, sqlCon);

            //update new supplier
            Console.WriteLine("\nPlease enter '{0}' Supplier country: ", compName);
            string compCountry = Console.ReadLine();
            Console.WriteLine("\nPlease enter '{0}' Supplier city: ", compName);
            string compCity = Console.ReadLine();
            UpdateAddedSupplier(compName, compCountry, compCity, sqlCon);

            //display new supplier
            DisplayNewSupplier(compName, sqlCon);

            //delete new supplier
            DeleteSupplier(sqlCon);

            //call stored procedure
            CallStoredProcOrderDetails(sqlCon);

            Console.ReadKey();

        }

        private static void AddNewSupplier(string compName, SqlConnection sqlCon)
        {
            DbCommand cmd = new SqlCommand();
            Console.WriteLine("Adding new Supplier to DB: '{0}'", compName);
            cmd.Connection = sqlCon;
            cmd.CommandText = string.Format("INSERT INTO [dbo].[Suppliers] (CompanyName) VALUES ('{0}')", compName);
            int affecterRows = cmd.ExecuteNonQuery();
            Console.WriteLine("\nNew Supplier has been successfully added to DB, \nNumber of inserted rows: {0}",
                affecterRows);
        }

        private static void UpdateAddedSupplier(string compName, string compCountry, string compCity,
            SqlConnection sqlCon)
        {
            DbCommand cmd = new SqlCommand();
            Console.WriteLine("Updating '{0}' Supplier company", compName);
            cmd.Connection = sqlCon;
            cmd.CommandText =
                string.Format("UPDATE[dbo].[Suppliers] SET[City] = '{2}',[Country] = '{1}' WHERE CompanyName = '{0}'",
                    compName, compCountry, compCity);
            int affecterRows = cmd.ExecuteNonQuery();
            Console.WriteLine("\nNew Supplier have been successfully updated, \nNumber of updated rows: {0}",
                affecterRows);
        }

        private static void DisplayNewSupplier(string compName, SqlConnection sqlCon)
        {
            DbCommand cmd = new SqlCommand();
            Console.WriteLine("\nDisplay stored data for '{0}' Supplier company", compName);
            cmd.Connection = sqlCon;
            cmd.CommandText = string.Format("SELECT * FROM [dbo].[Suppliers] WHERE CompanyName = '{0}'", compName);
            var exRead = cmd.ExecuteReader();
            exRead.Read();

            Console.WriteLine(
                "\nSupplierID: {0}, CompanyName: {1}, {2}, {3}, {4}, SupplierCity: {5}, {6}, {7}, SupplierCountry: {8}, {9}, {10}, {11}",
                exRead["SupplierID"]
                , exRead["CompanyName"]
                , exRead["ContactName"]
                , exRead["ContactTitle"]
                , exRead["Address"]
                , exRead["City"]
                , exRead["Region"]
                , exRead["PostalCode"]
                , exRead["Country"]
                , exRead["Phone"]
                , exRead["Fax"]
                , exRead["HomePage"]);

            exRead.Close();
        }

        private static void DeleteSupplier(SqlConnection sqlCon)
        {
            Console.WriteLine("\nDo you want to delete any Supplier now? \n press 'Y' to procced: ");
            var choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                Console.WriteLine("\nPlease enter SupplierID which you want to delete");
                var compId = Console.ReadLine();
                DbCommand cmd = new SqlCommand();
                Console.WriteLine("Deleting Supplier with SupplierID = '{0}'", compId);
                cmd.Connection = sqlCon;
                cmd.CommandText = string.Format("DELETE FROM [dbo].[Suppliers] WHERE SupplierID = '{0}'", compId);
                int affecterRows = cmd.ExecuteNonQuery();
                Console.WriteLine("\nSupplier have been successfully deleted, \nNumber of deleted rows: {0}",
                    affecterRows);
            }
            else
            {
                Console.WriteLine("\n No Suppliers were deleted, \n Press any key to exit");
            }
        }

        private static void CallStoredProcOrderDetails(SqlConnection sqlCon)
        {
            Console.WriteLine("\nPlease enter OrderID, (10249 - 11077)");
            var orderId = Console.ReadLine();
            var orderDetails = new DataTable();
            SqlCommand cmd = new SqlCommand("CustOrdersDetail", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter = new SqlParameter("@OrderID", SqlDbType.NChar, 5);
            parameter.Value = orderId;
            cmd.Parameters.Add(parameter);
            var exRead = cmd.ExecuteReader();
            orderDetails.Load(exRead);
            foreach (DataRow row in orderDetails.Rows)
            {
                Console.WriteLine(
                    "-> ProductName: {0}, UnitPrice{1}, Quantity: {2}, Discount: {3}, ExtendedPrice {4}\n",
                    row["ProductName"],
                    row["UnitPrice"],
                    row["Quantity"],
                    row["Discount"],
                    row["ExtendedPrice"]);
            }
            exRead.Close();
        }
    }
}
