using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samaj_Kalyan.Areas.Admin.Models.SetupViewModel
{
    public class HandOver_TakeOverViewModel
    {
      
            public int HandOver_TakeOverId { get; set; }
            public Nullable<int> GA_Id { get; set; }
            public Nullable<int> PA_Id { get; set; }
            public string ApplicationRegistrationNumber { get; set; }
            public string RegistrationDateNp { get; set; }
            public Nullable<System.DateTime> RegistrationDate { get; set; }
            public string AssestReciverName { get; set; }
            public string DetailsOfAssest { get; set; }
            public string TotalValueOfAssest { get; set; }
            public Nullable<System.DateTime> DecisionDate { get; set; }
            public string DecisionDateNp { get; set; }
            public string SummaryOfDecision { get; set; }
            public string Remarks { get; set; }
            public Nullable<System.DateTime> CreatedDate { get; set; }
            public Nullable<int> CreatedBy { get; set; }
            public Nullable<System.DateTime> DeletedDate { get; set; }
            public Nullable<int> DeletedBy { get; set; }
            public Nullable<int> UpdatedBy { get; set; }
            public Nullable<System.DateTime> UpdateDate { get; set; }
            public List<HandOver_TakeOverViewModel> HandOver_TakeOverViewModelList { get; set; }

       
    }
}