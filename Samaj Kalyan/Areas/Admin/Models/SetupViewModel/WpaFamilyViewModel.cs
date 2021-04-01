using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samaj_Kalyan.Areas.Admin.Models.SetupViewModel
{
    public class WpaFamilyViewModel
    {
        public int WPAFamilyId { get; set; }
        public Nullable<int> WorkPermitId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string PassportNO { get; set; }
        public Nullable<decimal> VisaDuration { get; set; }
        public string VisaType { get; set; }
        public Nullable<System.DateTime> DicisionDate { get; set; }
        public string DicisionDateNp { get; set; }
        public string Relation { get; set; }
        public string remark { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletdDate { get; set; }

        public List<WpaFamilyViewModel> WpaFamilyList { get; set; }
    }
}