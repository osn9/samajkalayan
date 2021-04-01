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
    
    public partial class IngoRenewal
    {
        public IngoRenewal()
        {
            this.IngoRewnewalDocuments = new HashSet<IngoRewnewalDocument>();
        }
    
        public int RenewalId { get; set; }
        public int IngoId { get; set; }
        public Nullable<int> Period { get; set; }
        public Nullable<int> RenewCharge { get; set; }
        public string RenewalDateNP { get; set; }
        public Nullable<System.DateTime> RenewDate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<System.DateTime> DeletetDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public string FileLocation { get; set; }
    
        public virtual GeneralAgreement GeneralAgreement { get; set; }
        public virtual ICollection<IngoRewnewalDocument> IngoRewnewalDocuments { get; set; }
    }
}