using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Centric_Consulting_MIS_4200_Project.Models
{
    public class Leaderboard
    {
        

        [Display(Name ="Last Name")]
        public string lastName { get; set; }

        [Key]
        public System.Guid PID { get; set; }
        

        [ForeignKey(name: "PID")]
        public virtual Profile Profile { get; set; }

        [Required]

        [Display(Name = "Date")]

        public DateTime Date { get; set; }
  
        }
    }
