using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Samaj_Kalyan.Areas.Admin.Models
{
    public class ProjectAgreementViewModel
    {

        public ProjectAgreementViewModel()
        {


            PA_PartnerNgoViewModelList = new List<PA_PatnerNgoViewModel>();
            objPA_PatnerNgoViewModel = new PA_PatnerNgoViewModel();

            PA_SectorViewModelList = new List<PA_SectorViewModel>();
            objPA_SectorViewModel = new PA_SectorViewModel();


            PA_YearsViewModelList = new List<PA_YearsViewModel>();
            objPA_PA_YearsViewModel = new PA_YearsViewModel();

            ProjectAgreement_DistrictsViewModelList = new List<ProjectAgreement_DistrictsViewModel>();
            objProjectAgreement_DistrictsViewModel = new ProjectAgreement_DistrictsViewModel();
            

            }
        public int ProjectAgreement_ID { get; set; }
        [Required(ErrorMessage = "परियोजनाको नाम राख्नुहोस्")]
        [DisplayName("परियोजनाको नाम")]

        public string Name_Of_Project { get; set; }
        [DisplayName("परियोजनाको को नाम अंग्रेजी")]
        public string Name_Of_Project_Nepali { get; set; }
        [DisplayName("परियोजनाको साइन मिति")]

     
        public Nullable<System.DateTime> PA_Sign_Date { get; set; }
        public string Pa_Sign_DateNepali { get; set; }

         [DisplayName("डोनर ")]
        public string Doner { get; set; }
        
       [Required(ErrorMessage = "अन्तर्राष्ट्रिय गैर सरकारी संगठन नाम राख्नुहोस्")]
           [DisplayName("अन्तर्राष्ट्रिय गैर सरकारी संगठन ")]
        public Nullable<int> GeneralAgreement_ID { get; set; }
        [DisplayName("अन्तर्राष्ट्रिय गैर सरकारी संगठन ")]
       public string IngoName { get; set; }
        public Nullable<int> District_ID { get; set; }
        public Nullable<int> Local_Level_ID { get; set; }
        public Nullable<int> Provience_ID { get; set; }
        public Nullable<bool> Banking_Status { get; set; }
         [DisplayName("बैंकको नाम")]
        public string Name_Of_Bank { get; set; }
        [DisplayName("बैंकको खाता नम्बर")]
       

        public string Account_NO { get; set; }
         [DisplayName("कुल बजेट")]
        public Nullable<decimal> Total_Budget { get; set; }
         [DisplayName("प्रशासनको लागत")]
        public Nullable<decimal> Admin_Cost { get; set; }
         [DisplayName("कार्यक्रमको लागत")]
        public Nullable<decimal> Program_Cost { get; set; }
         [DisplayName("परियोजनाको अवधि")]
        public Nullable<decimal> Project_Period { get; set; }
         [DisplayName("विशेषज्ञको संख्या")]
        public Nullable<decimal> No_Of_Expertriate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<int> UpDatedBy { get; set; }
        public Nullable<System.DateTime> UpDatedDaye { get; set; }
        public List<ProjectAgreementViewModel> ProjectAgreementViewModelList { get; set; }
        public PA_PatnerNgoViewModel objPA_PatnerNgoViewModel { get; set; } 
        public List<PA_PatnerNgoViewModel> PA_PartnerNgoViewModelList { get; set; }
        public PA_SectorViewModel objPA_SectorViewModel { get; set; }
        public List<PA_SectorViewModel> PA_SectorViewModelList { get; set; }
        public PA_YearsViewModel objPA_PA_YearsViewModel { get; set; }
        public List<PA_YearsViewModel> PA_YearsViewModelList { get; set; }

        public ProjectAgreement_DistrictsViewModel objProjectAgreement_DistrictsViewModel { get; set; }
        public List<ProjectAgreement_DistrictsViewModel> ProjectAgreement_DistrictsViewModelList { get; set; }
    }
    public class PA_PatnerNgoViewModel
    {
        public int PA_PatnerNGOs_ID { get; set; }
          [DisplayName("गैर सरकारी संगठन")]
        public Nullable<int> Ngo_Number { get; set; }
          [DisplayName("गैर सरकारी संस्थाको नाम")]
        public string Ngo_Name { get; set; }
          [DisplayName("विशेषज्ञको संख्या")]
        public Nullable<int> ProjectAgreement_ID { get; set; }
          [DisplayName("राशि")]
        public Nullable<decimal> Amount { get; set; }


    }
    public  class PA_SectorViewModel
    {
        public int ProjectAgreementSector_ID { get; set; }
        public string Sector { get; set; }
        public Nullable<int> ProjectAgreement_ID { get; set; }
        public Nullable<decimal> Amount { get; set; }

        
    }
    public  class PA_YearsViewModel
    {
        public int ProjectAgreement_Year_Id { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> Project_Agreement_Id { get; set; }

        
    }
    public  class ProjectAgreement_DistrictsViewModel
    {
        public int ProjectAgreementBudgetBreakDown_ID { get; set; }
        [DisplayName("जिल्ला")]
        public Nullable<int> DistrictID { get; set; }
        [DisplayName("जिल्लाको राशि")]
        public Nullable<decimal> DistrictWiseAmmount { get; set; }
        [DisplayName("गैर सरकारी संगठन")]
        public Nullable<int> ProjectAgreementID { get; set; }
        [DisplayName("स्थानीय लेवल")]
        public Nullable<int> Locallevel { get; set; }
        [DisplayName("प्रदेश")]
        public Nullable<int> ProvienceId { get; set; }

        public string ProvienceName { get; set; }

        public string DistrictName { get; set; }
        public string locallevelName { get; set; }
        
    }
    }
    