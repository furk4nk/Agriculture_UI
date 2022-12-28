using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            // team name rules
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.PersonName).MaximumLength(50).WithMessage("En fazla 50 karakter veri girişi yapılabilir");
            RuleFor(x => x.PersonName).MinimumLength(5).WithMessage("En az 5 karakter veri girişi yapılabilir");


            // team title rules
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görev boş geçilemez");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("En fazla 50 karakter veri girişi yapılabilir");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("En az 5 karakter veri girişi yapılabilir");


            // team image rules
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Yolu Boş Geçilemez");



            // team Email address
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen Geçerli Bir Eposta Adresi Giriniz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez");
        }
    }
}
