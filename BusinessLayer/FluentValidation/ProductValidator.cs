using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Lütfen Ürün ismini boş geçmeyiniz");
            RuleFor(x => x.ProductName).MinimumLength(3).WithMessage("Lütfen Ürün ismini en 3 karakter olacak şekilde giriniz");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("Lütfen Ürün ismini en fazla 50 karakter olacak şekilde giriniz");

            RuleFor(x => x.Stok).NotEmpty().WithMessage("Lütfen Stok değeri giriniz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Lütfen Fiyat giriniz");
            
        }
    }
}
