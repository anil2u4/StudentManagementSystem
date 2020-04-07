﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.DBModel
{
    public class ObjectContext
    {
        public IConfigurationRoot Configuration { get; }
        private IMongoDatabase _database = null;
        string dbName = null;
        public ObjectContext(IOptions<Settings> settings)
        {
            Configuration = settings.Value.iConfigurationRoot;
            dbName = settings.Value.Database;
            settings.Value.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            settings.Value.Database = Configuration.GetSection("MongoConnection:Database").Value;
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            { 
                _database = client.GetDatabase(settings.Value.Database);
            }


        }

        public IMongoCollection<Student> Students
        {

        get
         {
            return _database.GetCollection<Student>("Student");
         }

         }





    }
}
