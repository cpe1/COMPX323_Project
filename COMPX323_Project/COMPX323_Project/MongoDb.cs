using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace COMPX323_Project
{
    public class MongoDB
    {
        MongoClient dbClient;

        public MongoDB(String username, String password, String hostname, int port, String database)
        {
            dbClient = new MongoClient("mongodb://"+username+":"+password+"@"+hostname+":"+port+"/"+database);
        }

        public void dbList()
        {
            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("The list of databases are: ");
            foreach (var item in dbList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
