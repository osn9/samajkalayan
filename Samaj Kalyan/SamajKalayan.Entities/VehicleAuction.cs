//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Samaj_Kalyan.SamajKalayan.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleAuction
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
    
        public virtual ProjectAgreement ProjectAgreement { get; set; }
    }
}
