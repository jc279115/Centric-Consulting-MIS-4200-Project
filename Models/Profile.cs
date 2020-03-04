using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Centric_Consulting_MIS_4200_Project.Models
{
    public class Profile
    {
        [Key]
        public System.Guid PID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Your first name is required.")]
        [StringLength(20)]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Your last name is required.")]
        [StringLength(20)]
        public string lastName { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Your email is required.")]
        [StringLength(20)]
        public string email { get; set; }
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\(\d{3}\) |/d{3}-\d{3}-\d{4}$",
            ErrorMessage = "Phone number must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        public string phoneNumber { get; set; }
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Your department name is required.")]
        [StringLength(40)]
        public string department { get; set; }
        [Display(Name = "Office Location")]
        [Required(ErrorMessage = "Your office location is required.")]
        [StringLength(20)]
        public string primaryOfficeLocation { get; set; }
        [Display(Name = "Job Title")]
        [Required(ErrorMessage = "Your job title is required.")]
        [StringLength(40)]
        public string jobTitle { get; set; }
    }
}