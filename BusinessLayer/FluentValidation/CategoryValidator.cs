using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            // category name rules for
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Lütfen Kategori ismini boş geçmeyiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen kategori ismini en az 3 karakter olacak şekilde giriniz");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("lütfen kategori ismini en fazla 50 karakter olacak şekilde giriniz");

        }
    }
}
