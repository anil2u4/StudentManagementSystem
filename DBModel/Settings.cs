using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.DBModel
{
    public class Settings
    {
        public string ConfigurationString;
        public string Database;
        public IConfigurationRoot iConfigurationRoot;
    }
}
