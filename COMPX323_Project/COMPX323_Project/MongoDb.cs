using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace COMPX323_Project
{
    public class MongoDB
    {
        MongoClient dbClient;
        IMongoDatabase db;

        public MongoDB(String username, String password, String hostname, int port, String database)
        {
            dbClient = new MongoClient("mongodb://"+username+":"+password+"@"+hostname+":"+port+"/"+database);
            db = dbClient.GetDatabase("compx323-20");
        }

        public void databases()
        {
            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("The list of databases are: ");
            foreach (var item in dbList)
            {
                Console.WriteLine(item);
            }
        }

        public void collections()
        {
            var collList = db.ListCollections().ToList();

            Console.WriteLine("The list of collections are: ");
            foreach(var item in collList)
            {
                Console.WriteLine(item);
            }
        }

        public void insert(String collectionName, BsonDocument document)
        {
            try
            {
                //get the collection we want to store the data in
                var collection = db.GetCollection<BsonDocument>(collectionName);

                //insert the document into the collection
                collection.InsertOne(document);
            }
            catch(Exception e)
            {
                MessageBox.Show("An error occurred: " + e);

            }
        }


        public void Execute(String query)
        {
            //try
            //{
            //    conn = new OracleConnection(oradb);
            //    conn.Open();
            //    OracleCommand cmd = new OracleCommand();
            //    cmd.Connection = conn;
            //    cmd.CommandText = query;
            //    cmd.CommandType = CommandType.Text;
            //    reader = cmd.ExecuteReader();

            //    Console.WriteLine("ORACLE EXECUTION: SUCCESS");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("ORACLE EXECUTION: " + e);
            //}
        }


        public List<Product> getAllProducts()
        {
            List<Product> productList = new List<Product>();

            var products = db.GetCollection<BsonDocument>("Products");
            var resultDoc = products.Find(new BsonDocument()).ToList();

            foreach(var item in resultDoc)
            {
                Product product = new Product(
                    item.GetElement("number").Value.ToDecimal(),
                    item.GetElement("name").Value.ToString(),
                    item.GetElement("price").Value.ToDecimal(),
                    item.GetElement("weightunit").Value.ToString(),
                    item.GetElement("stock").Value.ToDecimal(),
                    item.GetElement("discount").Value.ToDecimal()
                    );

                productList.Add(product);
            }

            return productList;
        }

        public List<Category> getAllCategories()
        {
            List<Category> categoryList = new List<Category>();

            var products = db.GetCollection<BsonDocument>("Products");
            var resultDoc = products.Find(new BsonDocument()).ToList();

            foreach (var item in resultDoc)
            {
                Category category = new Category(
                    item.GetElement("name").Value.ToString(),
                    item.GetElement("description").Value.ToString()
                );

                categoryList.Add(category);
            }

            return categoryList;
        }

        public bool checkCategory(String category)
        {
            //Execute(query);
            //bool exists = false;

            //if (reader.HasRows)
            //{
            //    //return true if the category exists
            //    exists = true;
            //}

            ////close and release all resources
            //reader.Close();
            //conn.Dispose();

            try
            {
                var categories = db.GetCollection<BsonDocument>("Categories");
                string myjson = "[{$match:{\"name\": \""+category+"\"}}, {$count: 'name'}]";
                var doc = new BsonDocument {
                    { "values", BsonSerializer.Deserialize<BsonArray>(myjson) }
                };

                categories.Find(doc);


            }
            catch(Exception e)
            {

            }

            return false;
            
        }

        public List<String> getWeightUnits()
        {
            List<String> weightUnitList = new List<String>();
            String query = "select distinct(weight_unit) from product";
            //Execute(query);

            //while (reader.Read())
            //{
            //    weightUnitList.Add(reader.GetString(0));
            //}

            //reader.Close();
            //conn.Dispose();

            return weightUnitList;
        }

    }
}
