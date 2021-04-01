using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samaj_Kalyan.Areas.Admin.Models.SetupViewModel
{
    public class Import_DutyFreeRecommendationViewModel
    {
    
        public int ImportId { get; set; }
        public Nullable<int> GA_Id { get; set; }
        public string GA_Name { get; set; }
        public Nullable<int> PA_Id { get; set; }
  
        public Nullable<int> Council_RegistrtionNumber { get; set; }
        public Nullable<System.DateTime> CouncilRegistrationDate { get; set; }
        public string CouncilRegistrationDateNp { get; set; }
        public string DonnerName { get; set; }
        public string DonnerAddress { get; set; }
        public string DiscriptionOfGoods { get; set; }
        public Nullable<int> InvoiceNumber { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public string InvoiceDateNp { get; set; }
        public Nullable<decimal> TotalAmountForieignCurrency { get; set; }
        public Nullable<decimal> TotalAmountNepaliCurrency { get; set; }
        public Nullable<System.DateTime> DecisionDate { get; set; }
        public string DecisionDateNp { get; set; }
        public string Remarks { get; set; }
        public string Import_DutyType { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<int> UpDatedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }


        public List<Import_DutyFreeRecommendationViewModel> Import_DutyFreeRecommendationViewModelList { get; set; }
    }
}