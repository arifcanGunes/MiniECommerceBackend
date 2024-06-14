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
using MiniETicaretBackend.Application.Repositories.RepositoryOfFile;
using MiniETicaretBackend.Persistence.Repositories.RepositoryOfFile;
using MiniETicaretBackend.Application.Repositories.RepositoryOfProductImageFile;
using MiniETicaretBackend.Persistence.Repositories.RepositoryOfProductImageFile;
using MiniETicaretBackend.Application.Repositories.RepositoryOfInvoiceFile;
using MiniETicaretBackend.Persistence.Repositories.RepositoryOfInvoiceFile;
using MiniETicaretBackend.Domain.Entities.Identity;

namespace MiniETicaretBackend.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<MiniETicaretDbContext>(options=> options.UseNpgsql(Configuration.GetConnectionString));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false; 
            }).AddEntityFrameworkStores<MiniETicaretDbContext>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IFileReadRepository, FileReadRepository>();

            services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();

            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
        }
    }
}
