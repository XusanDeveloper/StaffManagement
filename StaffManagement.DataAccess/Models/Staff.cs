using System.ComponentModel.DataAnnotations;

namespace StaffManagement.Models
{
    public class Staff
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [MaxLength(30)]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z", ErrorMessage =("Email is not valid!"))]
        public string Email { get; set; }

        [Required]
        public Departments Department { get; set; }
    }
}
