using MiniETicaretBackend.Application.Repositories.RepositoryOfProduct;
using MiniETicaretBackend.Domain.Entities;
using MiniETicaretBackend.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniETicaretBackend.Persistence.Repositories.RepositoryOfProduct
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(MiniETicaretDbContext context) : base(context)
        {
        }
    }
}
