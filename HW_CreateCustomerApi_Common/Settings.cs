using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_CreateCustomerApi_Common
{
    public class Settings
    {
        public DatabaseSettings Database { get; set; }

        public class DatabaseSettings
        {
            public string ConnectionString { get; set; }
        }
    }
}

