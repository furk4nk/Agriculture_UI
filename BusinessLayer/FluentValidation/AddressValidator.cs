using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            //Description 1 rules
            RuleFor(x => x.Description1).NotEmpty().WithMessage("Açıklama 1 boş geçilemez");
            RuleFor(x => x.Description1).MaximumLength(25).WithMessage("Açıklama 1 En fazla 25 karakter olmalıdır");
            RuleFor(x => x.Description1).MinimumLength(3).WithMessage("Açıklama 1 en az 3 karakter olmalıdır");

            //Description 2 rules
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama 2 boş geçilemez");
            RuleFor(x => x.Description2).MaximumLength(20).WithMessage("Açıklama 2 en fazla 20 karakter olmalıdır");
            RuleFor(x => x.Description2).MinimumLength(3).WithMessage("Açıklama 2 en az 3 karakter olmalıdır");


            //Description 3 rules
            RuleFor(x => x.Description3).NotEmpty().WithMessage("Açıklama 3 boş geçilemez");
            RuleFor(x => x.Description3).MaximumLength(20).WithMessage("Açıklama 3 en fazla 20 karakter olmalıdır");
            RuleFor(x => x.Description3).MinimumLength(3).WithMessage("Açıklama 3 en az 3 karakter olmalıdır");


            //phone and mapinfo rules
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş geçilemez");
            RuleFor(x => x.MapInfo).NotEmpty().WithMessage("Harita bilgisi boş geçilemez");
        }
    }
}
