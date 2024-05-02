using MiniETicaretBackend.Application.Repositories.RepositoryOfOrder;
using MiniETicaretBackend.Domain.Entities;
using MiniETicaretBackend.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniETicaretBackend.Persistence.Repositories.RepositoryOfOrder
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(MiniETicaretDbContext context) : base(context)
        {
        }
    }
}
