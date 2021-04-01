using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samaj_Kalyan.Areas.Admin.Models;
using Samaj_Kalyan.SamajKalayan.Entities;
using System.Data.Entity;

namespace Samaj_Kalyan.Areas.Providers.SetupProviders
{
    public class GeneralAgrementProvidercs
    {
        SamajkalyanEntities ent = new SamajkalyanEntities();
        public bool InsertGeneralAgreement(GeneralAgreementViewModel model)
        {
            using (SamajkalyanEntities ent = new SamajkalyanEntities())
            {
                var GAEntity = new GeneralAgreement()
                {
                    // Ethnic_ID = model.Ethnic_ID,
                   Name_Of_Ingo=model.Name_Of_Ingo,
                   Name_of_Ingo_Nepali=model.Name_of_Ingo_Nepali,
                   Ga_Date=model.Ga_Date,
                   Ga_Date_Nepali=model.Ga_Date_Nepali,
                   Period=model.Period,
                   Pre_Annum_Commitment_Amount=model.Pre_Annum_Commitment_Amount,
                   Ga_Service_Charge=model.Ga_Service_Charge,
                   Sector=model.Sector,
                   Hq_Address=model.Hq_Address,
                   Contact_Person=model.Contact_Person,
                   Country_Official_Nepal_Address=model.Country_Official_Nepal_Address,
                   Contact_Number=model.Contact_Number,
                   Email=model.Email,
                   GA_TerminationDate=model.GA_TerminationDate,
                    Ga_TerminationDate_Nepali=model.Ga_TerminationDate_Nepali,
                    PA_Attachment_Location=model.PA_Attachment_Location,
                    Scan_GA_Location=model.Scan_GA_Location,
               

                    CreatedBy = model.CreatedBy,
                    DeletedBy = model.DeletedBy,
                    UpdatedBy = model.UpdatedBy,
                    UpdatedDate = model.UpdatedDate,

                    CreatedDate = DateTime.Now,
                };
                ent.GeneralAgreements.Add(GAEntity);
                int i = ent.SaveChanges();












                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool InsertGeneralAgreement2(GeneralAgreementViewModel model)
        {


            using (SamajkalyanEntities ent = new SamajkalyanEntities())
            {
                try
                {
                    var generalAgreementRow = ent.GeneralAgreements.Where(x => x.GeneralAgreement_ID == model.GeneralAgreement_ID).FirstOrDefault();
                    //_context.Database.Connection.Open();
                    //_context.Database.Connection.BeginTransaction();
                    if (generalAgreementRow == null)
                    {
                        generalAgreementRow = new  GeneralAgreement ();
                    };
                       generalAgreementRow.Name_Of_Ingo=model.Name_Of_Ingo;
                   generalAgreementRow.Name_of_Ingo_Nepali=model.Name_of_Ingo_Nepali;
                   generalAgreementRow.Ga_Date=model.Ga_Date;
                   generalAgreementRow.Ga_Date_Nepali=model.Ga_Date_Nepali;
                   generalAgreementRow.Period=model.Period;
                   generalAgreementRow.Pre_Annum_Commitment_Amount=model.Pre_Annum_Commitment_Amount;
                   generalAgreementRow.Ga_Service_Charge=model.Ga_Service_Charge;
                   generalAgreementRow.Sector=model.Sector;
                   generalAgreementRow.Hq_Address=model.Hq_Address;
                   generalAgreementRow.Contact_Person=model.Contact_Person;
                   generalAgreementRow.Country_Official_Nepal_Address=model.Country_Official_Nepal_Address;
                   generalAgreementRow.Contact_Number=model.Contact_Number;
                   generalAgreementRow.Email=model.Email;
                   generalAgreementRow.GA_TerminationDate=model.GA_TerminationDate;
                    generalAgreementRow.Ga_TerminationDate_Nepali=model.Ga_TerminationDate_Nepali;
                    generalAgreementRow.Scan_GA_Location = model.Scan_GA_Location;
                    generalAgreementRow.PA_Attachment_Location = model.PA_Attachment_Location;
                    generalAgreementRow.Country = model.Country;
               
                    //deploymentRow.Status = true;
                    if (model.GeneralAgreement_ID == 0)
                    {
                       // generalAgreementRow.Status = false;
                        ent.GeneralAgreements.Add(generalAgreementRow);
                        ent.SaveChanges();
                    }
                    else
                    {
                       // deploymentRow.Status = dmodel.Status ?? false;
                        ent.GeneralAgreements.Attach(generalAgreementRow);
                        ent.Entry(generalAgreementRow).State = EntityState.Modified;
                        ent.SaveChanges();

                    }
                    if (model.GeneralAgreement_ID <= 0)
                    {
                        model.GeneralAgreement_ID = ent.Database.SqlQuery<GeneralAgreementViewModel>("select * from GeneralAgreement where GeneralAgreement_ID=(select max (GeneralAgreement_ID) from GeneralAgreement )").ToList().FirstOrDefault().GeneralAgreement_ID;
                        //employeeRow.EmpId=employeeRow.EmpId != 0 ? employeeRow.EmpId : empModel.EmpId;

                    }
        //            #region files 
                    
        //            using (var tempContext = new SamajkalyanEntities())
        //            {
        //                var deletelist = tempContext.GA_Attachment.Where(x => x.GeneralAgreement_ID == model.GeneralAgreement_ID).ToList();
        //                if (deletelist.Count > 0)
        //                {
        //                    foreach (var item in deletelist)
        //                    {
        //                        if (model.GaAttachmentViewModelList == null)
        //                        {
        //                            model.GaAttachmentViewModelList = new List<GaAttachmentViewModel>();
        //                        }
        //                        var isExists = model.GaAttachmentViewModelList.Where(x => x.GA_Attachment_ID == item.GeneralAgreement_ID).FirstOrDefault();
        //                        if (isExists == null)
        //                        {
        //                            tempContext.GA_Attachment.Remove(item);
        //                            tempContext.SaveChanges();
        //                        }
        //                    }

        //                }
        //            }

        //            if (model.GaAttachmentViewModelList != null)
        //            {
        //                foreach (var item in model.GaAttachmentViewModelList)
        //                {
        //                    GA_Attachment newRow = new GA_Attachment();
        //                    newRow.GeneralAgreement_ID = model.GeneralAgreement_ID;
        //                    newRow.GA_Attachment_ID = item.GA_Attachment_ID;
        //                    newRow.PA_Attachment_Location = item.PA_Attachment_Location;
        //                    newRow.Scan_GA_Location = item.Scan_GA_Location;
        //                    //newRow.NoOfDep = item.NoOfDep;

        //                    if (item.GA_Attachment_ID == 0)
        //                    {
        //                        ent.GA_Attachment.Add(newRow);
        //                        ent.SaveChanges();
        //                    }
        //                    else
        //                    {
        //                        ent.GA_Attachment.Attach(newRow);
        //                        ent.Entry(newRow).State = EntityState.Modified;
        //                        ent.SaveChanges();
        //                    }
        //                }
        //            }

                

                }
                catch (Exception ex)
                {
                   return false;
                }
            }

            return true;
        }
                    
    

        public GeneralAgreementViewModel GetGAByID(int? id) 
        { 
            SamajkalyanEntities ent =new SamajkalyanEntities();
            GeneralAgreementViewModel entity = ent.GeneralAgreements.Where(x => x.GeneralAgreement_ID == id).Select(x => new GeneralAgreementViewModel()
            {
                GeneralAgreement_ID =x.GeneralAgreement_ID,
                Name_Of_Ingo = x.Name_Of_Ingo,
                Name_of_Ingo_Nepali = x.Name_of_Ingo_Nepali,
                Ga_Date = x.Ga_Date,
                Ga_Date_Nepali = x.Ga_Date_Nepali,
                Period = x.Period,
                Pre_Annum_Commitment_Amount = x.Pre_Annum_Commitment_Amount,
                Ga_Service_Charge = x.Ga_Service_Charge,
                Sector = x.Sector,
                Hq_Address = x.Hq_Address,
                Contact_Person = x.Contact_Person,
                Country_Official_Nepal_Address = x.Country_Official_Nepal_Address,
                Contact_Number = x.Contact_Number,
                Email = x.Email,
                GA_TerminationDate = x.GA_TerminationDate,
                Ga_TerminationDate_Nepali = x.Ga_TerminationDate_Nepali,

                PA_Attachment_Location=x.PA_Attachment_Location,
                Scan_GA_Location=x.Scan_GA_Location,
                Country=x.Country,

                DeletedBy = x.DeletedBy,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,

                CreatedDate = DateTime.Now,

            }).FirstOrDefault();
            return entity;
        
        }
        public List<GeneralAgreementViewModel>GetGAList() 
        {
            List<GeneralAgreementViewModel> GaList = ent.GeneralAgreements.Select(x => new GeneralAgreementViewModel()
            {
                GeneralAgreement_ID=x.GeneralAgreement_ID,
                 Name_Of_Ingo = x.Name_Of_Ingo,
                Name_of_Ingo_Nepali = x.Name_of_Ingo_Nepali,
                Ga_Date = x.Ga_Date,
                Ga_Date_Nepali = x.Ga_Date_Nepali,
                Period = x.Period,
                Pre_Annum_Commitment_Amount = x.Pre_Annum_Commitment_Amount,
                Ga_Service_Charge = x.Ga_Service_Charge,
                Sector = x.Sector,
                Hq_Address = x.Hq_Address,
                Contact_Person = x.Contact_Person,
                Country_Official_Nepal_Address = x.Country_Official_Nepal_Address,
                Contact_Number = x.Contact_Number,
                Email = x.Email,
                GA_TerminationDate = x.GA_TerminationDate,
                Ga_TerminationDate_Nepali = x.Ga_TerminationDate_Nepali,

                PA_Attachment_Location=x.PA_Attachment_Location,
                Scan_GA_Location=x.Scan_GA_Location,
                DeletdedDate=x.DeletdedDate,
                Country=x.Country,
                DeletedBy = x.DeletedBy,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,

                CreatedDate = DateTime.Now,


                


            }).Where(x=>x.DeletdedDate==null).ToList();

            foreach (var item in GaList)
            {
                DateTime date1 = item.GA_TerminationDate.Value;
               int oldMonth = item.GA_TerminationDate.Value.Month;
               DateTime date2= DateTime.Now;

               var daysss = (date1 - date2).Days;
               var d = Convert.ToDouble(daysss);

               item.NoOfDays = Convert.ToInt32(d);
               var year =   Math.Truncate(d / 365);
               if (daysss<365)
               {
                   item.TimeRemaining = (daysss.ToString() +" " + "days(s) Left");
               }
               else
               {
                  // item.TimeRemaining = year.ToString();
                   item.TimeRemaining = ( year.ToString() + " year(s)");
               }
               if (daysss < 0)
               {
                   item.TimeRemaining = ((daysss * - 1).ToString() + " " + "days(s) Exceded");
               }
                        

            }
            return GaList;
        }
        public int Delete(int id)
        {
            try
            {
                //delete Deployment employee
                
                //delete Deplpoyment
                var obj = ent.GeneralAgreements.ToList().Where(x => x.GeneralAgreement_ID == id).FirstOrDefault();
                obj.DeletdedDate = DateTime.Now;
                //_context.DeploymentTbls.Remove(obj);
                int i = ent.SaveChanges();
                if (i > 0)
                    return 1;
            }

            catch (Exception ex)
            {
                return 0;
            }

            return 0;
        }

        public int getnoexpga()
        {
            try 
	{	        
		List<GeneralAgreementViewModel>List=GetGAList();
        List = List.Where(x => x.NoOfDays < 182).ToList();
        int listCount = List.Count;
        return listCount;
	}
	catch (Exception e)
	{
        return 0;
		
	}
        }
    }
    }
