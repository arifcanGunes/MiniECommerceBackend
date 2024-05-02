using FluentValidation;
using MiniETicaretBackend.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniETicaretBackend.Application.Validators.FluentValidation.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Lütfen ürün adını boş geçmeyiniz")
                .MaximumLength(100).MinimumLength(2).WithMessage("Lütfen ürün adını 2 ile 100 karakter arasında belirleyiniz.");

            RuleFor(p => p.Stock).NotEmpty().WithMessage("Lütfen stok bilgisini boş geçmeyiniz")
                .Must(s => s>=0).WithMessage("Lütfen stok bilgisini 0 veya üzerinde bir sayı giriniz.");

            RuleFor(p => p.Price).NotEmpty().WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz")
                .Must(p=> p>=0).WithMessage("Fiyat bilgisini 0 veya üzerinde bir sayı giriniz.");
                
        }
    }
}
