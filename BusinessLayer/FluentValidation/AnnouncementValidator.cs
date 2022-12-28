using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class AnnouncementValidator : AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            // Image Title
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görsel Başlığı Boş geçilemez");
            RuleFor(x => x.Title).MaximumLength(60).WithMessage("Görsel Başlığı En fazla 60 karakter olmalıdır");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Görsel başlığı en az 5 karakter olmalıdır");



            //Image Description
            RuleFor(x => x.Description).NotEmpty().WithMessage("Görsel Açıklaması boş geçilemez");
            RuleFor(x => x.Description).MaximumLength(170).WithMessage("Görsel Açıklaması en fazla 170 karakter olmalıdır");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Görsel Açıklaması en az 5 karakter olmalıdır");


            //Image URL
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel yolu boş geçilemez");
        }
    }
}
