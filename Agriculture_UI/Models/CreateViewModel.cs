using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Agriculture_UI.Models
{
    public class CreateViewModel
    {
        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public int GenderID { get; set; }


        [DataType(DataType.DateTime,ErrorMessage ="lütfen geçerli bir tarih giriniz")]
        public DateTime BirthDay { get; set; }


        [Required(ErrorMessage ="Lütfen Parola Belirleyiniz")]
        public string Password { get; set; }

        [Required(ErrorMessage ="lütfen Şifrenizi Tekrar Giriniz")]
        [Compare("Password",ErrorMessage ="Lütfen Şifrelerin eşleştiğinden emin olunuz")]
        public string ConfirmPassword { get; set; }

    }
}
