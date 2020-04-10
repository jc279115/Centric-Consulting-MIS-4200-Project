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
        public Guid PID { get; set; }
        

        [ForeignKey(name: "PID")]
        public virtual Profile Profile { get; set; }

        [Required]

        [Display(Name = "Date")]

        public DateTime Date { get; set; }

        [Required]

        [Display(Name = "Core Value")]

        public CoreValue award { get; set; }

        public enum CoreValue
        {
            Excellence = 1,
            Integrity = 1,
            Stewardship = 1,
            Culture = 1,
            Passion = 1,
            Innovative = 1,
            Balanced = 1
        }
    }
}