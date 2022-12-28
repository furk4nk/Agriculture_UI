using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ServiceValidator :AbstractValidator<Service>
    {
        public ServiceValidator() 
        {
            // service title rules
            RuleFor(x => x.Title).NotEmpty().WithMessage("Hizmet adı boş geçilemez");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("En az 3 karakter veri girişi yapılabilir");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("En fazla 50 karakter veri girişi yapılabilir");


            // service Description
            RuleFor(x => x.Description).NotEmpty().WithMessage("Hizmet Açıklaması boş geçilemez");


            // service Image
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("hizmet Görsel yolu boş geçilemez");


        }

    }
}
