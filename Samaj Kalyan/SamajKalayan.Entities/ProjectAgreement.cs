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
    
    public partial class ProjectAgreement
    {
        public ProjectAgreement()
        {
            this.PA_PartnerNgo = new HashSet<PA_PartnerNgo>();
            this.PA_Sector = new HashSet<PA_Sector>();
            this.PA_Years = new HashSet<PA_Years>();
            this.ProjectAgreement_Districts = new HashSet<ProjectAgreement_Districts>();
            this.WorkPermits = new HashSet<WorkPermit>();
            this.PrincipaleConstantOfVolunters = new HashSet<PrincipaleConstantOfVolunter>();
            this.HandOver_TakeOver = new HashSet<HandOver_TakeOver>();
            this.Import_DutyFreeRecommendation = new HashSet<Import_DutyFreeRecommendation>();
            this.VehicleAuctions = new HashSet<VehicleAuction>();
        }
    
        public int ProjectAgreement_ID { get; set; }
        public string Name_Of_Project { get; set; }
        public string Name_Of_Project_Nepali { get; set; }
        public string Pa_Sign_DateNepali { get; set; }
        public Nullable<System.DateTime> PA_Sign_Date { get; set; }
        public string Doner { get; set; }
        public Nullable<int> GeneralAgreement_ID { get; set; }
        public Nullable<int> District_ID { get; set; }
        public Nullable<int> Local_Level_ID { get; set; }
        public Nullable<int> Provience_ID { get; set; }
        public Nullable<bool> Banking_Status { get; set; }
        public string Name_Of_Bank { get; set; }
        public string Account_NO { get; set; }
        public Nullable<decimal> Total_Budget { get; set; }
        public Nullable<decimal> Admin_Cost { get; set; }
        public Nullable<decimal> Program_Cost { get; set; }
        public Nullable<decimal> Project_Period { get; set; }
        public Nullable<decimal> No_Of_Expertriate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<int> UpDatedBy { get; set; }
        public Nullable<System.DateTime> UpDatedDaye { get; set; }
    
        public virtual GeneralAgreement GeneralAgreement { get; set; }
        public virtual ICollection<PA_PartnerNgo> PA_PartnerNgo { get; set; }
        public virtual ICollection<PA_Sector> PA_Sector { get; set; }
        public virtual ICollection<PA_Years> PA_Years { get; set; }
        public virtual ICollection<ProjectAgreement_Districts> ProjectAgreement_Districts { get; set; }
        public virtual ICollection<WorkPermit> WorkPermits { get; set; }
        public virtual ICollection<PrincipaleConstantOfVolunter> PrincipaleConstantOfVolunters { get; set; }
        public virtual ICollection<HandOver_TakeOver> HandOver_TakeOver { get; set; }
        public virtual ICollection<Import_DutyFreeRecommendation> Import_DutyFreeRecommendation { get; set; }
        public virtual ICollection<VehicleAuction> VehicleAuctions { get; set; }
    }
}
