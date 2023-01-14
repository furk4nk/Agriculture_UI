using System.ComponentModel.DataAnnotations;
using System;

namespace Agriculture_UI.Models
{
    public class UserEditViewModel
    {
        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public int GenderID { get; set; }


        [DataType(DataType.DateTime, ErrorMessage = "lütfen geçerli bir tarih giriniz")]
        public DateTime BirthDay { get; set; }
    }
}
