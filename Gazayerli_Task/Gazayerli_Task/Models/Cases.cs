using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gazayerli_Task.Models
{
    public class Cases
    {

        public Cases()
        {
            LawyerCases = new List<LawyerCases>();
        }

        [Key]
        public int CaseID { get; set; }
        public string CaseName { get; set; }



        public virtual ApplicationUser ApplicationUser { get; set; }


        public virtual List<LawyerCases> LawyerCases { get; set; }

    }
}