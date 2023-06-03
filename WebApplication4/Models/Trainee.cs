using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace WebApplication4.Models
{
    [Guid("9ED54F84-A89D-4fcd-A854-44251E925F09")]
    public class Trainee
    {

       
        public int traineeid { get; set; }

        [Required(ErrorMessage ="name should be enter")]
        [StringLength(12,MinimumLength =3,ErrorMessage ="length should be inbetween 3 and 12")]
        [Display(Name ="Full Name")]
        public string name { get; set; }

        [Required]
        [Column(TypeName ="decimal(18,2)")]
        public int salary { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime joiningdate { get; set; }

        [Required]
        [DataType(DataType.CreditCard)]
        public long creditcard { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
       public string password
        {get; set;
        }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }

    }
}
