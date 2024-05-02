using MiniETicaretBackend.Application.Repositories.RepositoryOfCustomer;
using MiniETicaretBackend.Domain.Entities;
using MiniETicaretBackend.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniETicaretBackend.Persistence.Repositories.RepositoryOfCustomer
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(MiniETicaretDbContext context) : base(context)
        {
        }
    }
}
