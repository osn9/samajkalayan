using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Samaj_Kalyan.Areas.Admin.Models.SetupViewModel
{
    public class IngoRenewalViewModel
    {
        public IngoRenewalViewModel()
        {
            objIngoRewnewalDocumentViewModel = new IngoRewnewalDocumentViewModel();
            IngoRewnewalDocumentViewModelList = new List<IngoRewnewalDocumentViewModel>();
        }



        public int RenewalId { get; set; }


        [Required]
        [DisplayName("अन्तर्राष्ट्रिय गैर सरकारी संस्थाको नाम")]
        public int IngoId { get; set; }
        [Required]
        [DisplayName("अन्तर्राष्ट्रिय गैर सरकारी संस्थाको नाम")]
        public string Ingoname { get; set; }
            [DisplayName("अवधि")]
        public Nullable<int> Period { get; set; }
       [DisplayName("नविकरण शुल्क")]
        public Nullable<int> RenewCharge { get; set; }
         [DisplayName("नविकरण मिति")]
       public string RenewalDateNP { get; set; }
        [DisplayName("नविकरण मिति")]
        public Nullable<System.DateTime> RenewDate { get; set; }
         public string FileLocation { get; set; } 
        public bool File_Change { get; set; }
         public string File_Name { get; set; }

        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<System.DateTime> DeletetDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public List<IngoRenewalViewModel> IngoRenewalViewModelList { get; set; }

        public List<IngoRewnewalDocumentViewModel> IngoRewnewalDocumentViewModelList { get; set; }

        public IngoRewnewalDocumentViewModel objIngoRewnewalDocumentViewModel { get; set; }
    }
    public  class IngoRewnewalDocumentViewModel
    {
        public int DocumentId { get; set; }
        public string DocumentLocation { get; set; }
        public Nullable<int> RewnewalId { get; set; }
        public bool FileChange { get; set; }
        public string DocumentName { get; set; }

       
    }
}