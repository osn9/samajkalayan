using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Samaj_Kalyan.Areas.Admin.Models.SetupViewModel
{
    public class IngoTerminationViewModel
    {

        public int TerminationId { get; set; }
        [Required]
        [DisplayName("अन्तर्राष्ट्रिय गैर सरकारी संस्थाको नाम")]
        public Nullable<int> IngoId { get; set; }
        [Required]
        [DisplayName("अन्तर्राष्ट्रिय गैर सरकारी संस्थाको नाम")]
        public string IngoName { get; set; }
         [DataType(DataType.Date)]
         [DisplayName("समाप्ति मिति")]
        public string TerminationDateNp { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("समाप्ति मिति")]
        public Nullable<System.DateTime> TerminationDate { get; set; }
            [DisplayName("सम्पत्तिको नाम")]
        public string NameOfAssest { get; set; }
        public string EvaluationOfReportAttached { get; set; }
        
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> DeletdDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }

        public List<IngoTerminationViewModel> IngoTerminationViewModelList { get; set; }
        
    }
}