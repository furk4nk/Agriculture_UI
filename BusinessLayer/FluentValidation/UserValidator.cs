using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            // UserName Rules
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı ismi boş geçilemez");
            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("Kullanıcı ismi  en az 5 karakter olmalıdır");
            RuleFor(x => x.UserName).MaximumLength(25).WithMessage("Kullanıcı ismi  En Fazla 25 Karakter olmalıdır");


            // Email Rule
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçersiz Email Adresi");



            // Adress Rules
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres Boş Geçilemez");
            RuleFor(x => x.Address).MinimumLength(10).WithMessage("Adres en az 10 karakter olmalıdır");



            //FullName Rule
            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim Boş Geçilemez");



            //BirtDay Rule
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Doğum Tarihi Boş Geçilemez");

            

            //GenderId rule
            RuleFor(x => x.GenderID).NotEmpty().WithMessage("Lütfen bir cinsiyet değeri seçiniz");

            //PhoneNumber rule
            //RuleFor(x => x.PhoneNumber).NotNull().Length(10, 19).WithMessage("lütfen geçerli bir numara giriniz");
        }
    }
}
