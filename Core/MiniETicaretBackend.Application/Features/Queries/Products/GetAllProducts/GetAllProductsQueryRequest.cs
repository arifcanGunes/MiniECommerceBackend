﻿using MediatR;
using MiniETicaretBackend.Application.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniETicaretBackend.Application.Features.Queries.Products.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
    {
        //public Pagination Pagination{ get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
