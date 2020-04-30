using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Centric_Consulting_MIS_4200_Project.Models
{
    public class NominationPage
    {
        [Key]
        public int PID { get; set; }

        [Display(Name = "Core Value Recognized")]
        public CoreValue award { get; set; }

        [Display(Name = "Nominated By")]
        public System.Guid recognizor { get; set; }
        [ForeignKey("recognizor")]
        public virtual Profile nominator { get; set; }
        [Display(Name = "Nominee")]
        public System.Guid recognized { get; set; }
        [ForeignKey("recognized")]
        public virtual Profile nominatee { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Recognition Given")]
        public DateTime recognizationDate { get; set; }
        
        public enum CoreValue
        {
            [Display(Name = "Commit to Delivery Excellence")]
            Excellence = 1,
            [Display(Name = "Embrace Integrity and Openness")]
            Integrity = 2,
            [Display(Name = "Practice Responsible Stewardship")]
            Stewardship = 3,
            [Display(Name = "Invest in an Exceptional Culture")]
            Culture = 4,
            [Display(Name = "Ignite Passion for the Greater Good")]
            Balance = 5,
            [Display(Name = "Strive to Innovate")]
            Innovation = 6, 
            [Display(Name = "Live a Balanced Life")]
            Lifestyle = 7
        }
    }
}
