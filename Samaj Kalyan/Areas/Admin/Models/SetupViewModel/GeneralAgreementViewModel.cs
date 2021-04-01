using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Samaj_Kalyan.Areas.Admin.Models
{
    public class GeneralAgreementViewModel
    {

        public GeneralAgreementViewModel()
        {
            GaAttachmentViewModelList = new List<GaAttachmentViewModel>();
            objGaAttachmentViewModel = new GaAttachmentViewModel();
    
            ProjectAgreementViewModelList =new List<ProjectAgreementViewModel>();
            objProjectAgreementViewModel = new ProjectAgreementViewModel();
            }
        public int GeneralAgreement_ID { get; set; }
        [Required]
        [DisplayName("अन्तर्राष्ट्रिय गैर सरकारी संस्थाको नाम")]
        public string Name_Of_Ingo { get; set; }
         [DisplayName("अन्तर्राष्ट्रिय गैर सरकारी संस्थाको नाम अंग्रेजी")]
        public string Name_of_Ingo_Nepali { get; set; }
          [DisplayName("देश")]
        public string Country { get; set; }
          [DisplayName("मिति")]
        public string Ga_Date_Nepali { get; set; }
          [DisplayName("मिति")]
        public Nullable<System.DateTime> Ga_Date { get; set; }
          [DisplayName("अवधि")]
        public string Period { get; set; }
          [DisplayName("पूर्व अन्न प्रतिबद्धता रकम")]
        public Nullable<decimal> Pre_Annum_Commitment_Amount { get; set; }
          [DisplayName("सेवा शुल्क")]
        public Nullable<decimal> Ga_Service_Charge { get; set; }
          [DisplayName("सेक्टर")]
        public string Sector { get; set; }
          [DisplayName("ठेगाना")]
        public string Hq_Address { get; set; }
          [DisplayName("सम्पर्क व्यक्ति")]
        public string Contact_Person { get; set; }
          [DisplayName("देश आधिकारिक")]
        public string Country_Official_Nepal_Address { get; set; }
          [DisplayName("सम्पर्क नम्बर")]
        public Nullable<int> Contact_Number { get; set; }
          [DisplayName("इमेल")]
        public string Email { get; set; }
          [DisplayName("समाप्तिको मिति")]
        public Nullable<System.DateTime> GA_TerminationDate { get; set; }
        public string Ga_TerminationDate_Nepali { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletdedDate { get; set; }

        [DisplayName("स्क्यान फाइल")]
        public string Scan_GA_Location { get; set; }
        public bool Scan_GA_Change { get; set; }
        public string Scan_GA_Name { get; set; }

        public string PA_Attachment_Location { get; set; }
        public bool PA_Attachment_Change { get; set; }
        public string PA_Attachment_Name { get; set; }

        public string TimeRemaining { get; set; }
        public int  NoOfDays { get; set; }
        public List<GeneralAgreementViewModel> GeneralAgreementViewModelList { get; set; }


        public List<GaAttachmentViewModel> GaAttachmentViewModelList { get; set; }
        public GaAttachmentViewModel objGaAttachmentViewModel { get; set; }

        public List<ProjectAgreementViewModel> ProjectAgreementViewModelList { get; set; }
        public ProjectAgreementViewModel objProjectAgreementViewModel { get; set; }


    }
    public class GaAttachmentViewModel
    {
        public int GA_Attachment_ID { get; set; }
        public string Scan_GA_Location { get; set; }
        public string PA_Attachment_Location { get; set; }
        public Nullable<int> GeneralAgreement_ID { get; set; }
    }


}