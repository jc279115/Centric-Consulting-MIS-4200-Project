﻿using System;
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
        [Display (Name ="First Name")]
        [Required(ErrorMessage ="Your first name is required.")]
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
        public string phoneNumber { get; set; }
        public string department { get; set; }
        public string primaryOfficeLocation { get; set; }
        public string jobTitle { get; set; }
    }
}