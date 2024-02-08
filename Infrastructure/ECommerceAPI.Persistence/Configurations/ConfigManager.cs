using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace ECommerceAPI.Persistence.Configurations
{
    public class ConfigManager: IConfigManager
    {
        public IConfigurationManager _configurationManager;
        public ConfigManager(IConfigurationManager configurationManager) {
            _configurationManager = configurationManager;
        }

        public string GetConnectionString()
        {
           return _configurationManager.GetConnectionString("SqlServer");
        }
    }
}
