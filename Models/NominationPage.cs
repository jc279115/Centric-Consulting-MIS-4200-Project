using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


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

        [Display(Name = "Nominee")]
        public System.Guid recognized { get; set; }
        [Display(Name = "Date Recognition Given")]
        public DateTime recognizationDate { get; set; }
        public enum CoreValue
        {
            [Display(Name = "Commit to Delivery Excellence")]
            Excellence = 1,
            [Display(Name = "Embrace Integrity and Openness")]
            Integrity = 1,
            [Display(Name = "Practice Responsible Stewardship")]
            Stewardship = 1,
            [Display(Name = "Invest in an Exceptional Culture")]
            Innovate = 1,
            [Display(Name = "Ignite Passion for the Greater Good")]
            Balance = 1,
            [Display(Name = "Strive to Innovate")]
            Innovation = 1, 
            [Display(Name = "Live a Balanced Life")]
            Lifestyle = 1
        }
    }
}
