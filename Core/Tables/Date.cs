using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Tables
{
    [Table("Date")]
    public class Date
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DateId { get; set; }

        [DisplayName("Start Date"), Required(ErrorMessage = "Please do not leave this field blank.")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date"), Required(ErrorMessage = "Please do not leave this field blank.")]
        public DateTime EndDate { get; set; }

        [DisplayName("Result"), Required(ErrorMessage = "Please do not leave this field blank.")]
        public int Result { get; set; }

        [DisplayName("Request Date"), Required(ErrorMessage = "Please do not leave this field blank.")]
        public DateTime RequestDate { get; set; }
    }
}
