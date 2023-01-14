using Microsoft.AspNetCore.Identity;

namespace Agriculture_UI.Models
{
    public class CustomErrorDescriber :IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = "PasswordTooShort",
                Description = "Şifreniz en az 6 karakter olmalıdır"
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresUpper",
                Description = "şifrenizde en az 1 Büyük karakter olmalıdır"
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresLower",
                Description = "şifrenizde en az 1 Küçük karakter olmalıdır"
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "En az 1 özel karakter içermelidir"
            };
        }
        public override IdentityError PasswordMismatch()
        {
            return new IdentityError
            {
                Code= "PasswordMismatch",
                Description="Şifreniz Yanlış"
            };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = "DuplicateUserName",
                Description = "Kullanıcı Zaten sistemde Kayıtlı"
            };
        }
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = "InvalidUserName",
                Description = "Geçersiz Kullanıcı adı"
            };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = "DuplicateEmail",
                Description = "Email Zaten Sisteme Kayıtlı"
            };
        }
    }
}
