using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samaj_Kalyan.Areas.Admin.Models.SetupViewModel
{
    public class VehicleAuctionViewModel
    {
        
            public int VehicleAuctionId { get; set; }
            public Nullable<int> GA_ID { get; set; }
            public Nullable<int> PA_ID { get; set; }
            public string ApplicationRegistrationNumber { get; set; }
            public Nullable<System.DateTime> RegistrationDate { get; set; }
            public string RegistrationDatep { get; set; }
            public string VehicleType { get; set; }
            public string VehicleNumber { get; set; }
            public Nullable<System.DateTime> DecisionDate { get; set; }
            public string DecisionDateNp { get; set; }
            public string SummaryOfDecision { get; set; }
            public string Remarks { get; set; }
            public Nullable<System.DateTime> CreatedDate { get; set; }
            public Nullable<int> CreatedBy { get; set; }
            public Nullable<int> DeletedBy { get; set; }
            public Nullable<System.DateTime> DeletedDate { get; set; }
            public Nullable<System.DateTime> UpdateDate { get; set; }
            public Nullable<int> UpdatedBy { get; set; }
            public string Type { get; set; }
            public List<VehicleAuctionViewModel> VehicleAuctionViewModelList { get; set; }
        
    }
}