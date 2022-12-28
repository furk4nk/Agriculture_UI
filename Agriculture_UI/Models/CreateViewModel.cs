using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Agriculture_UI.Models
{
    public class CreateViewModel
    {
        [Required(ErrorMessage ="Lütfen ad soyad bilgisi giriniz")]
        [Display(Name ="Ad Soyad")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Lütfen kullanıcı adı giriniz")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Lütfen Telefon Numarası Giriniz")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Lütfen Adres bilgisi giriniz")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Lütfen Doğum Tarihi Giriniz")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage ="Lütfen Parola Belirleyiniz")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Lütfen Şifrelerin eşleştiğinden emin olunuz")]
        public string ConfirmPassword { get; set; }

    }
}
