using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Configurations
{
    public interface IConfigManager
    {
        public string GetConnectionString();
    }
}
