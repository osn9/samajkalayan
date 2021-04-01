using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samaj_Kalyan.Areas.Admin.Models.SetupViewModel
{
    public class WorkPermitViewModel
    {
        public WorkPermitViewModel()
        {
            WpaFamilyViewModelList = new List<WpaFamilyViewModel>();
            objWpaFamilyViewModel = new WpaFamilyViewModel();
            }


        public int WorkPermitId { get; set; }
        public string WorkPermitTypeIdName { get; set; }
        public Nullable<int> WorkPermitTypeId { get; set; }
        public Nullable<int> PA_Id { get; set; }
        public Nullable<int> GA_Id { get; set; }
        public Nullable<int> Council_sRegistrationNumber { get; set; }
        public Nullable<System.DateTime> CouncilRegistrationDate { get; set; }
        public string CouncilRegistrationDateNp { get; set; }
        public string NameOfApplicant { get; set; }
        public string Country { get; set; }
        public string PassportNumber { get; set; }
        public Nullable<decimal> VisaDuration { get; set; }
        public string ApplicationDesingation { get; set; }
        public Nullable<System.DateTime> DecisionDate { get; set; }
        public string DecisionDateNp { get; set; }
        public string VisaType { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<int> UpDatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public List<WorkPermitViewModel>WorkPermitViewModelList { get; set; }
        public WpaFamilyViewModel objWpaFamilyViewModel { get; set; }
        public List<WpaFamilyViewModel> WpaFamilyViewModelList { get; set; }
        
    }
}