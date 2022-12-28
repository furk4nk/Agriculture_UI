using System.ComponentModel.DataAnnotations;

namespace Agriculture_UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adınızı giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="lütfen Şifrenizi giriniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
