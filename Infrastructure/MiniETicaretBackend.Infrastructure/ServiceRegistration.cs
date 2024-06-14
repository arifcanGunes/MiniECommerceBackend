using Microsoft.Extensions.DependencyInjection;
using MiniETicaretBackend.Application.Abstractions.Storage;
using MiniETicaretBackend.Application.Abstractions.Token;
using MiniETicaretBackend.Infrastructure.Concretes.Storage;
using MiniETicaretBackend.Infrastructure.Concretes.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniETicaretBackend.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T: Storage, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
