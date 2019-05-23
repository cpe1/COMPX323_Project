using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace COMPX323_Project
{
    public class Oracle
    {
        private String oradb;
        public OracleConnection conn;
        public OracleDataReader reader;


        public Oracle(String datasource, String userid, String password)
        {
            oradb = "Data Source="+datasource+";User Id="+userid+"; Password="+password+";";
        }


        public void Execute(String query)
        {
            try
            {
                conn = new OracleConnection(oradb);
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();

                Console.WriteLine("ORACLE EXECUTION: SUCCESS");
            } catch (Exception e)
            {
                Console.WriteLine("ORACLE EXECUTION: " + e);
            }
        }

        public List<Product> getProducts(String query)
        {
            List<Product> productList = new List<Product>();

            Execute(query);

            while (reader.Read())
            {
                Product product = new Product(
                        reader.GetDecimal(0), //serial_number
                        reader.GetString(1), //name
                        reader.GetDecimal(2), //price
                        reader.GetString(3), //weight_unit
                        reader.GetDecimal(4), //stock
                        reader.GetDecimal(5) //discount
                        );
                productList.Add(product);
            }

            reader.Close();
            conn.Dispose();

            return productList;
        }

        public List<Category> getCategories(String query)
        {
            List<Category> categoryList = new List<Category>();

            Execute(query);

            while (reader.Read())
            {
                Category category = new Category(
                    reader.GetString(0),
                    reader.GetString(1)
                );
                categoryList.Add(category);
            }

            reader.Close();
            conn.Dispose();

            return categoryList;
        }

        public bool checkCategory(String category)
        {
            String query = "select lower(name) from category where name like lower('" + category+"')";
            Execute(query);
            bool exists = false;

            if (reader.HasRows)
            {
                //return true if the category exists
                exists = true;
            }

            //close and release all resources
            reader.Close();
            conn.Dispose();

            return exists;
            
        }

        public List<String> getWeightUnits()
        {
            List<String> weightUnitList = new List<String>();
            String query = "select distinct(weight_unit) from product";
            Execute(query);

            while (reader.Read())
            {
                weightUnitList.Add(reader.GetString(0));
            }

            reader.Close();
            conn.Dispose();

            return weightUnitList;
        }
    }
}
