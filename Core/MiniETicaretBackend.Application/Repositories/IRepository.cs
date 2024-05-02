﻿using Microsoft.EntityFrameworkCore;
using MiniETicaretBackend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniETicaretBackend.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table {  get; }
    }
}
