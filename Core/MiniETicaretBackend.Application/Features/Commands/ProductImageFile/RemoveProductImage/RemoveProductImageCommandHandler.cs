using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniETicaretBackend.Application.Repositories.RepositoryOfFile;
using MiniETicaretBackend.Application.Repositories.RepositoryOfProduct;
using MiniETicaretBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MiniETicaretBackend.Application.Features.Commands.ProductImageFile.RemoveProductImage
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponse>
    {
        IProductReadRepository _productReadRepository;
        IProductWriteRepository _productWriteRepository;
        IFileWriteRepository _fileWriteRepository;

        public RemoveProductImageCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IFileWriteRepository fileWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _fileWriteRepository = fileWriteRepository;
        }

        public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));
            if (product != null)
            {
                MiniETicaretBackend.Domain.Entities.ProductImageFile? productImageFile = product.ProductImageFiles.FirstOrDefault(i => i.Id == Guid.Parse(request.ImageId));
                if (productImageFile != null)
                {
                    product.ProductImageFiles.Remove(productImageFile);
                    _fileWriteRepository.Remove(productImageFile);
                    await _productWriteRepository.SaveAsync();
                }
            }
            return new();
        }
    }
}
