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
        [Display(Name = "Core value recognized")]
        public CoreValue award { get; set; }
        [Display(Name = "Person giving the recognition")]
        public System.Guid recognizor { get; set; }
        [Display(Name = "Person receiving the recognition")]
        public System.Guid recognized { get; set; }
        [Display(Name = "Date recognition given")]
        public DateTime recognizationDate { get; set; }
        public enum CoreValue
        {
            
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Innovate = 4,
            Balance = 5
        }
    }
}
