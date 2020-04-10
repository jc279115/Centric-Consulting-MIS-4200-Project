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
            // Change these to Centric Core Values
            /*
            Commit to Delivery Excellence = 1,
            Embrace Integrity and Openness = 1,
            Practice Responsible Stewardship = 1,
            Invest in an Exceptional Culture = 1,
            Ignite Passion for the Greater Good = 1,
            Strive to Innovate = 1,
            Live a Balanced Life = 1
            */
        }
    }
}