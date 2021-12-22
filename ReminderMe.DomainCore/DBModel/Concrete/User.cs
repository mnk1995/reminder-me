using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderMe.DomainCore.DBModel.Concrete
{
    public class User:Base
    {
        [Required]
        [Column("UserName")]
        public string UserName { get; set; } 
        
        [Required]
        [Column("Adi")]
        public string Adi { get; set; }

        [Required]
        [Column("Soyadi")]
        public string Soyadi { get; set; }

        [Required]
        [Column("Email")]
        public string Email { get; set; }

        [Required]
        [Column("Password")]
        public string Password { get; set; }

        [Column("ActivationCode")]
        public string ActivationCode { get; set; }

        [Column("ForgetCode")]
        public string ForgetCode { get; set; }

        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [Column("isAdmin")]
        public bool isAdmin { get; set; }
    }
}
