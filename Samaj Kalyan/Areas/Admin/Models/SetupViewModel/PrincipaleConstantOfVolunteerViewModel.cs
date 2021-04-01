using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samaj_Kalyan.Areas.Admin.Models.SetupViewModel
{
    public class PrincipaleConstantOfVolunteerViewModel
    {

        public int VolunteerID { get; set; }
        public Nullable<int> GA_Id { get; set; }
        public string GAName { get; set; }
        public Nullable<int> PA_Id { get; set; }
        public string  PAName { get; set; }
        public string Council_sRagistrationNumber { get; set; }
        public Nullable<System.DateTime> C_Council_sRagistrationDate { get; set; }
        public string C_Council_sRagistrationDateNp { get; set; }
        public string NameOfAppicant { get; set; }
        public string Country { get; set; }
        public string PassportNumber { get; set; }
        public Nullable<decimal> VisaDuration { get; set; }
        public string ApplicationDesingation { get; set; }
        public string ApplicationSector { get; set; }
        public string Agreement { get; set; }
        public string ServiceReciverNGOSName { get; set; }
        public Nullable<System.DateTime> DecisionDate { get; set; }
        public string DecisionDateNp { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreateedBy { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }

        public List<PrincipaleConstantOfVolunteerViewModel> PrincipaleConstantOfVolunteerViewModelList { get; set; }
    }
}