using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace WebApplication4.Models
{
    [Guid("9ED54F84-A89D-4fcd-A854-44251E925F09")]
    public class Employee
    {
       
     
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="name should be there")]
        [Display(Name = "Actual Name")]
        [StringLength(10,MinimumLength =3,ErrorMessage ="name should be a inbetwwn 3 and 10")]
       
        public string Name { get; set; }
      
        public string Gender { get; set; }
        [DataType(DataType.Text)]
        public string City { get; set; }

  
    }

}
