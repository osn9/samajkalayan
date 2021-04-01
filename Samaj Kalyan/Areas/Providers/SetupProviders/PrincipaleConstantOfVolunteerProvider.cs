using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samaj_Kalyan.Areas.Admin.Models.SetupViewModel;
using Samaj_Kalyan.SamajKalayan.Entities;
using System.Data.Entity;

namespace Samaj_Kalyan.Areas.Providers.SetupProviders
{
    public class PrincipaleConstantOfVolunteerProvider
    {
        SamajkalyanEntities ent = new SamajkalyanEntities();
        public bool InsertUpdate(PrincipaleConstantOfVolunteerViewModel model)
        {


            using (SamajkalyanEntities ent = new SamajkalyanEntities())
            {
                try
                {
                    var generalAgreementRow = ent.PrincipaleConstantOfVolunters.Where(x => x.VolunteerID == model.VolunteerID).FirstOrDefault();
                
                    if (generalAgreementRow == null)
                    {
                        generalAgreementRow = new PrincipaleConstantOfVolunter();
                    };
                    generalAgreementRow.GA_Id = model.GA_Id;
                    generalAgreementRow.PA_Id = model.PA_Id;
                    
                    generalAgreementRow.Council_sRagistrationNumber = model.Council_sRagistrationNumber;
                    generalAgreementRow.C_Council_sRagistrationDate = model.C_Council_sRagistrationDate;
                    generalAgreementRow.C_Council_sRagistrationDateNp = model.C_Council_sRagistrationDateNp;
                    generalAgreementRow.NameOfAppicant = model.NameOfAppicant;
                    generalAgreementRow.Country = model.Country;
                    generalAgreementRow.PassportNumber = model.PassportNumber;
                    generalAgreementRow.VisaDuration = model.VisaDuration;
                    generalAgreementRow.ApplicationDesingation = model.ApplicationDesingation;
                    generalAgreementRow.ApplicationSector = model.ApplicationSector;
                    generalAgreementRow.Agreement = model.Agreement;
                    generalAgreementRow.ServiceReciverNGOSName = model.ServiceReciverNGOSName;
                    generalAgreementRow.DecisionDate = model.DecisionDate;
                    generalAgreementRow.DecisionDateNp = model.DecisionDateNp;
                    generalAgreementRow.Remarks = model.Remarks;
                    generalAgreementRow.CreatedDate = model.CreatedDate;
                    generalAgreementRow.CreateedBy = model.CreateedBy;
                   
                    if (model.VolunteerID == 0)
                    {
                        // generalAgreementRow.Status = false;
                        ent.PrincipaleConstantOfVolunters.Add(generalAgreementRow);
                        ent.SaveChanges();
                    }
                    else
                    {
                        // deploymentRow.Status = dmodel.Status ?? false;
                        generalAgreementRow.UpdateDate = model.UpdateDate;
                        generalAgreementRow.UpdatedBy = model.UpdatedBy;
                        ent.PrincipaleConstantOfVolunters.Attach(generalAgreementRow);
                        ent.Entry(generalAgreementRow).State = EntityState.Modified;
                        ent.SaveChanges();

                    }
                  
                 



                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }


        public List<PrincipaleConstantOfVolunteerViewModel> GetPCAList()
        {
            List<PrincipaleConstantOfVolunteerViewModel> List = ent.PrincipaleConstantOfVolunters.Select(x => new PrincipaleConstantOfVolunteerViewModel()
            {
                VolunteerID=x.VolunteerID,
                GA_Id=x.GA_Id,
                PAName=x.ProjectAgreement.Name_Of_Project_Nepali,
                PA_Id=x.PA_Id,
                 Council_sRagistrationNumber = x.Council_sRagistrationNumber,
                    C_Council_sRagistrationDate = x.C_Council_sRagistrationDate,
                    C_Council_sRagistrationDateNp = x.C_Council_sRagistrationDateNp,
                    NameOfAppicant = x.NameOfAppicant,
                    Country = x.Country,
                    PassportNumber = x.PassportNumber,
                    VisaDuration = x.VisaDuration,
                    ApplicationDesingation = x.ApplicationDesingation,
                    ApplicationSector = x.ApplicationSector,
                    Agreement = x.Agreement,
                    ServiceReciverNGOSName = x.ServiceReciverNGOSName,
                    DecisionDate = x.DecisionDate,
                    DecisionDateNp = x.DecisionDateNp,
                    Remarks = x.Remarks,
                DeletedDate = x.DeletedDate,
               // Country = x.Country,
                DeletedBy = x.DeletedBy,
                UpdatedBy = x.UpdatedBy,
                UpdateDate = x.UpdateDate,

                CreatedDate = x.DecisionDate,
                CreateedBy=x.CreateedBy




            }).Where(x => x.DeletedDate == null).ToList();
            foreach (var item in List)
            {
                item.GAName=ent.GeneralAgreements.Where(x => x.GeneralAgreement_ID == item.GA_Id).FirstOrDefault().Name_of_Ingo_Nepali;
            }

     
            return List;
        }

        public PrincipaleConstantOfVolunteerViewModel GetPCVByID(int? id)
        {
            SamajkalyanEntities ent = new SamajkalyanEntities();
            PrincipaleConstantOfVolunteerViewModel entity = ent.PrincipaleConstantOfVolunters.Where(x => x.VolunteerID == id).Select(x => new PrincipaleConstantOfVolunteerViewModel()
            {
                VolunteerID = x.VolunteerID,
                GA_Id = x.GA_Id,
                PAName=x.ProjectAgreement.Name_Of_Project_Nepali,
                PA_Id = x.PA_Id,
                Council_sRagistrationNumber = x.Council_sRagistrationNumber,
                C_Council_sRagistrationDate = x.C_Council_sRagistrationDate,
                C_Council_sRagistrationDateNp = x.C_Council_sRagistrationDateNp,
                NameOfAppicant = x.NameOfAppicant,
                Country = x.Country,
                
                PassportNumber = x.PassportNumber,
                VisaDuration = x.VisaDuration,
                ApplicationDesingation = x.ApplicationDesingation,
                ApplicationSector = x.ApplicationSector,
                Agreement = x.Agreement,
                ServiceReciverNGOSName = x.ServiceReciverNGOSName,
                DecisionDate = x.DecisionDate,
                DecisionDateNp = x.DecisionDateNp,
                Remarks = x.Remarks,
                DeletedDate = x.DeletedDate,
                // Country = x.Country,
                DeletedBy = x.DeletedBy,
                UpdatedBy = x.UpdatedBy,
                UpdateDate = x.UpdateDate,

                CreatedDate = x.DecisionDate,
                CreateedBy = x.CreateedBy

            }).FirstOrDefault();

           
             
          
                entity.GAName = ent.GeneralAgreements.Where(x => x.GeneralAgreement_ID == entity.GA_Id).FirstOrDefault().Name_of_Ingo_Nepali;
           
            return entity;

        }
        public int Delete(int id)
        {
            try
            {
             
                var obj = ent.PrincipaleConstantOfVolunters.ToList().Where(x => x.VolunteerID == id).FirstOrDefault();
                obj.DeletedDate = DateTime.Now;
               
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
    }
}