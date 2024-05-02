using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MiniETicaretBackend.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniETicaretBackend.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MiniETicaretDbContext>
    {
        public MiniETicaretDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MiniETicaretDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.GetConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
