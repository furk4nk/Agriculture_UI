using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        [Required]
        [Display(Name ="Ad Soyad")]
        public string FullName { get; set; }

        [Display(Name ="Normalize ad soyad")]
        [Required]
        public string NormalizedFullName { get; set; }

        [Display(Name ="Adres")]
        [Required]
        public string Address { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime createDate { get; set; }

        [Required]
        public int GenderID { get; set; }
        public Gender gender { get; set; }

    }
}
