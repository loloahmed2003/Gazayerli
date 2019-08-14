using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gazayerli_Task.Models
{
    public class Lawyer
    {
        public Lawyer()
        {
            LawyerCases = new List<LawyerCases>();
        }
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }


        public int CostPerHour { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual List<LawyerCases> LawyerCases { get; set; }
    }
}