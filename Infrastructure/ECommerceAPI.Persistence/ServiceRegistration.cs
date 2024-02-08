using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using ECommerceAPI.Persistence.Configurations;
using System.Data.Common;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistence.Repositories;

namespace ECommerceAPI.Persistence
{
    public static class ServiceRegistration
    {
            
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration
                
            ) {

            //IConfigManager config = configManager;
            //string connectionString = config.GetConnectionString();
            
            services.AddDbContext<ECommerceAPIDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

        }
    }
}
