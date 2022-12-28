using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator() 
        {
            // Görsel başlığı - adı 
            RuleFor(x => x.title).NotEmpty().WithMessage("Görsel başlığı boş geçilemez");
            RuleFor(x => x.title).MaximumLength(20).WithMessage("Görsel başlığı en fazla 20 karakter içerebilir");
            RuleFor(x => x.title).MinimumLength(3).WithMessage("Görsel başlığı en az 3 karakter olmalıdır");


            
            // Görsel Açıklaması
            RuleFor(x => x.Description).NotEmpty().WithMessage("Görsel Açıklaması boş geçilemez");
            RuleFor(x => x.Description).MaximumLength(50).WithMessage("Görsel açıklaması en fazla 50 karakter olmalıdır");
            RuleFor(x => x.Description).MinimumLength(3).WithMessage("Görsel açıklaması en az 3 karakter olmalıdır");



            //Görsel yolu 
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel yolu boş geçilemez");
        }
    }
}
