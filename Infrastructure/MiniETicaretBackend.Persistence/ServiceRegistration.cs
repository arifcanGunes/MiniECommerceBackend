using Microsoft.Extensions.DependencyInjection;
using MiniETicaretBackend.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MiniETicaretBackend.Application.Repositories.RepositoryOfCustomer;
using MiniETicaretBackend.Persistence.Repositories.RepositoryOfCustomer;
using MiniETicaretBackend.Application.Repositories.RepositoryOfOrder;
using MiniETicaretBackend.Persistence.Repositories.RepositoryOfOrder;
using MiniETicaretBackend.Application.Repositories.RepositoryOfProduct;
using MiniETicaretBackend.Persistence.Repositories.RepositoryOfProduct;

namespace MiniETicaretBackend.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<MiniETicaretDbContext>(options=> options.UseNpgsql(Configuration.GetConnectionString));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();



        }
    }
}
