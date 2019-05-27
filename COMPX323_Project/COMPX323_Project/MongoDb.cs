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
using System.Text.RegularExpressions;

namespace COMPX323_Project
{
    public class MongoDB
    {
        MongoClient dbClient;
        IMongoDatabase db;

        public MongoDB(String username, String password, String hostname, int port, String database)
        {
            dbClient = new MongoClient("mongodb://" + username + ":" + password + "@" + hostname + ":" + port + "/" + database);
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
            foreach (var item in collList)
            {
                Console.WriteLine(item);
            }
        }


        public List<Product> getAllProducts()
        {
            List<Product> productList = new List<Product>();

            var products = db.GetCollection<BsonDocument>("Products");
            var resultDoc = products.Find(new BsonDocument()).ToList();

            foreach (var item in resultDoc)
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

            var categories = db.GetCollection<BsonDocument>("Categories");
            var resultDoc = categories.Find(new BsonDocument()).ToList();

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
            var categories = db.GetCollection<BsonDocument>("Categories");

            var pipeline = new BsonDocument[] {
                new BsonDocument { { "$match", new BsonDocument("name", category) } }
            };

            var resultDoc = categories.Aggregate<BsonDocument>(pipeline).ToList();

            if (resultDoc.Count > 0)
            {
                Console.Write("Check Category - returned results " + resultDoc.Count);
                return true;
            }

            return false;
        }

        public List<String> getWeightUnits()
        {
            List<String> weightUnitList = new List<String>();

            var products = db.GetCollection<BsonDocument>("Products");
            var pipeline = new BsonDocument[] {
                new BsonDocument{ { "$group", new BsonDocument("_id", "$weightunit") }}
            };


            var resultDoc = products.Aggregate<BsonDocument>(pipeline).ToList();

            foreach (var item in resultDoc)
            {
                weightUnitList.Add(item.GetElement("_id").Value.ToString());
            }

            return weightUnitList;
        }

        public void insertCategory(String category, String description)
        {

            try
            {
                var categories = db.GetCollection<BsonDocument>("Categories");

                BsonDocument categoryDoc = new BsonDocument();

                BsonElement categoryName = new BsonElement("name", category);
                BsonElement categoryDescription = new BsonElement("description", description);
                categoryDoc.Add(categoryName);
                categoryDoc.Add(categoryDescription);

                categories.InsertOne(categoryDoc);
            }
            catch (Exception e)
            {
                Console.Write(e);
            };
        }

        public void insertProduct(String name, decimal price, String weight_unit, decimal stock, decimal discount, String category)
        {
            try
            {
                var products = db.GetCollection<BsonDocument>("Products");

                BsonDocument productDoc = new BsonDocument();

                BsonElement productNumber = new BsonElement("number", getProductNumber());
                BsonElement productName = new BsonElement("name", name);
                BsonElement productPrice = new BsonElement("price", price);
                BsonElement productWeightUnit = new BsonElement("weightunit", weight_unit);
                BsonElement productStock = new BsonElement("stock", stock);
                BsonElement productDiscount = new BsonElement("discount", discount);
                BsonElement productCategory = new BsonElement("category", category);

                productDoc.Add(productNumber);
                productDoc.Add(productName);
                productDoc.Add(productPrice);
                productDoc.Add(productWeightUnit);
                productDoc.Add(productStock);
                productDoc.Add(productDiscount);
                productDoc.Add(productCategory);

                products.InsertOne(productDoc);

            } catch (Exception e)
            {
                Console.Write(e);
            }
        }

        public int getProductNumber()
        {
            var products = db.GetCollection<BsonDocument>("Products");

            var pipeline = new BsonDocument[] {
                new BsonDocument{ { "$count", "name" }}
            };


            var resultDoc = products.Aggregate<BsonDocument>(pipeline).ToList();
            int productNumber = 0;

            foreach (var item in resultDoc)
            {
                productNumber = item.GetElement("name").Value.ToInt32();
            }

            return productNumber + 1;

        }

        public List<Product> getProducts(String field, String input)
        {
            List<Product> productList = new List<Product>();

            var products = db.GetCollection<BsonDocument>("Products");

           // var pipeline = new BsonDocument[] {
           //     new BsonDocument { { "$match", new BsonDocument("name", input) } }
           // };

            BsonDocument doc = new BsonDocument { { field, new Regex("(?i)" + input) } };
            var resultDoc = products.Find<BsonDocument>(doc).ToList();

            //var resultDoc = products.Aggregate<BsonDocument>(pipeline).ToList();

            foreach (var item in resultDoc) {
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

    }
}
