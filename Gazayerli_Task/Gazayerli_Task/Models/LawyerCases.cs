using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gazayerli_Task.Models
{
    public class LawyerCases
    {

        [Key]
        [Column(Order = 1)]
        public int CaseID { get; set; }

        [Key]
        [Column(Order = 2)]
        public string LawyerID { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/mm/dd}")]
        public DateTime AssignDate
        {
            get; set;
        }
        public int TotalHours { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/mm/dd}")]

        public DateTime ExpiredDate
        {
            get; set;
        }

        public virtual Cases Case { get; set; }
        public virtual Lawyer Lawyer { get; set; }


    }
}