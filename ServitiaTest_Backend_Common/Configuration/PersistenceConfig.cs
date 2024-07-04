using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Common.Configuration
{

    public class PersistenceConfig
    {
        public string ConnectionString { get; set; }
        public string DatabaseProvider { get; set; }
        public PersistenceConfig()
        {
            ConnectionString = string.Empty;
            DatabaseProvider = string.Empty;   
        }


    }
}
