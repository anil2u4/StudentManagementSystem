using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.DBModel
{
    public class ObjectContext
    {
        public IConfigurationRoot Configuration {get;}
        private IMongoDatabase _database = null;
        public ObjectContext(IOptions<Settings>settings)
        {
            Configuration = settings.Value.iConfigurationRoot;
          //  settings.Value.ConnectionString = Configuration.GetSection();
        }


    }
}
