using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samaj_Kalyan.Areas.Admin.Models;
using Samaj_Kalyan.SamajKalayan.Entities;
using System.Data.Entity;

namespace Samaj_Kalyan.Areas.Providers.SetupProviders
{
    public class ProjectAgreementProvider
    {
        public bool InsertProjectAgreement(ProjectAgreementViewModel model)
        {


            using (SamajkalyanEntities ent = new SamajkalyanEntities())
            {
                try
                {
                    var projectAgreementRow = ent.ProjectAgreements.Where(x => x.ProjectAgreement_ID == model.ProjectAgreement_ID).FirstOrDefault();
                    //_context.Database.Connection.Open();
                    //_context.Database.Connection.BeginTransaction();
                    if (projectAgreementRow == null)
                    {
                        projectAgreementRow = new ProjectAgreement();
                    };
                    projectAgreementRow.GeneralAgreement_ID = model.GeneralAgreement_ID;
                    projectAgreementRow.Name_Of_Project = model.Name_Of_Project;
                    projectAgreementRow.Name_Of_Project_Nepali = model.Name_Of_Project_Nepali;
                    projectAgreementRow.Name_Of_Bank = model.Name_Of_Bank;
                    projectAgreementRow.PA_Sign_Date = model.PA_Sign_Date;
                    projectAgreementRow.Project_Period = model.Project_Period;
                    projectAgreementRow.Total_Budget = model.Total_Budget;
                    projectAgreementRow.Admin_Cost = model.Admin_Cost;
                    projectAgreementRow.Program_Cost = model.Program_Cost;
                    projectAgreementRow.Name_Of_Bank = model.Name_Of_Bank;
                    projectAgreementRow.Account_NO = model.Account_NO;
                    projectAgreementRow.Doner = model.Doner;
                    projectAgreementRow.No_Of_Expertriate = model.No_Of_Expertriate;
                    projectAgreementRow.CreatedBy = model.CreatedBy;
                    projectAgreementRow.CreatedDate = DateTime.Now;
                    projectAgreementRow.Pa_Sign_DateNepali = model.Pa_Sign_DateNepali;
                   

                    //deploymentRow.Status = true;
                    if (model.ProjectAgreement_ID == 0)
                    {
                        // generalAgreementRow.Status = false;
                        ent.ProjectAgreements.Add(projectAgreementRow);
                        ent.SaveChanges();
                    }
                    else
                    {
                        // deploymentRow.Status = dmodel.Status ?? false;
                        projectAgreementRow.UpDatedBy = model.UpDatedBy;
                        projectAgreementRow.UpDatedDaye = DateTime.Now;
                        ent.ProjectAgreements.Attach(projectAgreementRow);
                        ent.Entry(projectAgreementRow).State = EntityState.Modified;
                        ent.SaveChanges();

                    }
                    if (model.ProjectAgreement_ID <= 0)
                    {
                        model.ProjectAgreement_ID = ent.Database.SqlQuery<ProjectAgreementViewModel>("select * from ProjectAgreement where ProjectAgreement_ID=(select max (ProjectAgreement_ID) from ProjectAgreement )").ToList().FirstOrDefault().ProjectAgreement_ID;
                        //employeeRow.EmpId=employeeRow.EmpId != 0 ? employeeRow.EmpId : empModel.EmpId;

                    }
                    #region PA_PartnerNgo

                    using (var tempContext = new SamajkalyanEntities())
                    {
                        var deletelist = tempContext.PA_PartnerNgo.Where(x => x.ProjectAgreement_ID == model.ProjectAgreement_ID).ToList();
                        if (deletelist.Count > 0)
                        {
                            foreach (var item in deletelist)
                            {
                                if (model.PA_PartnerNgoViewModelList == null)
                                {
                                    model.PA_PartnerNgoViewModelList = new List<PA_PatnerNgoViewModel>();
                                }
                                var isExists = model.PA_PartnerNgoViewModelList.Where(x => x.PA_PatnerNGOs_ID == item.PA_PatnerNGOs_ID).FirstOrDefault();
                                if (isExists == null)
                                {
                                    tempContext.PA_PartnerNgo.Remove(item);
                                    tempContext.SaveChanges();
                                }
                            }

                        }
                    }

                    if (model.PA_PartnerNgoViewModelList != null)
                    {
                        foreach (var item in model.PA_PartnerNgoViewModelList)
                        {
                            PA_PartnerNgo newRow = new PA_PartnerNgo();
                            newRow.ProjectAgreement_ID = model.ProjectAgreement_ID;
                            newRow.Ngo_Name = item.Ngo_Name;
                            newRow.Ngo_Number = item.Ngo_Number;
                            newRow.PA_PatnerNGOs_ID = item.PA_PatnerNGOs_ID;
                            newRow.Amount = item.Amount;
                            //newRow.NoOfDep = item.NoOfDep;

                            if (item.PA_PatnerNGOs_ID == 0)
                            {
                                ent.PA_PartnerNgo.Add(newRow);
                                ent.SaveChanges();
                            }
                            else
                            {
                                ent.PA_PartnerNgo.Attach(newRow);
                                ent.Entry(newRow).State = EntityState.Modified;
                                ent.SaveChanges();
                            }
                        }
                    }
                    #endregion
                    #region district
                    using (var tempContext = new SamajkalyanEntities())
                    {
                        var deletelist = tempContext.ProjectAgreement_Districts.Where(x => x.ProjectAgreementID == model.ProjectAgreement_ID).ToList();
                        if (deletelist.Count > 0)
                        {
                            foreach (var item in deletelist)
                            {
                                if (model.ProjectAgreement_DistrictsViewModelList == null)
                                {
                                    model.ProjectAgreement_DistrictsViewModelList = new List<ProjectAgreement_DistrictsViewModel>();
                                }
                                var isExists = model.ProjectAgreement_DistrictsViewModelList.Where(x => x.ProjectAgreementBudgetBreakDown_ID == item.ProjectAgreementBudgetBreakDown_ID).FirstOrDefault();
                                if (isExists == null)
                                {
                                    tempContext.ProjectAgreement_Districts.Remove(item);
                                    tempContext.SaveChanges();
                                }
                            }

                        }
                    }

                    if (model.ProjectAgreement_DistrictsViewModelList != null)
                    {
                        foreach (var item in model.ProjectAgreement_DistrictsViewModelList)
                        {
                            ProjectAgreement_Districts newRow = new ProjectAgreement_Districts();
                            newRow.ProjectAgreementID = model.ProjectAgreement_ID;
                            newRow.Locallevel = item.Locallevel;
                            newRow.DistrictID = item.DistrictID;
                            newRow.ProvienceId = item.ProvienceId;
                            newRow.DistrictWiseAmmount = item.DistrictWiseAmmount;
                            newRow.ProjectAgreementBudgetBreakDown_ID = item.ProjectAgreementBudgetBreakDown_ID;
                            //newRow.NoOfDep = item.NoOfDep;

                            if (item.ProjectAgreementBudgetBreakDown_ID == 0)
                            {
                                ent.ProjectAgreement_Districts.Add(newRow);
                                ent.SaveChanges();
                            }
                            else
                            {
                                ent.ProjectAgreement_Districts.Attach(newRow);
                                ent.Entry(newRow).State = EntityState.Modified;
                                ent.SaveChanges();
                            }
                        }
                    }
          
                    #endregion
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }


        public ProjectAgreementViewModel GetPAByID(int? id)
        {
            
            SamajkalyanEntities ent = new SamajkalyanEntities();
            ProjectAgreementViewModel entity = ent.ProjectAgreements.Where(x => x.ProjectAgreement_ID == id).Select(x => new ProjectAgreementViewModel()
            {
                GeneralAgreement_ID = x.GeneralAgreement_ID,
                ProjectAgreement_ID = x.ProjectAgreement_ID,
                    Name_Of_Project = x.Name_Of_Project,
                    Name_Of_Project_Nepali = x.Name_Of_Project_Nepali,
                    Name_Of_Bank = x.Name_Of_Bank,
                    PA_Sign_Date = x.PA_Sign_Date,
                    Project_Period = x.Project_Period,
                    Total_Budget = x.Total_Budget,
                    Admin_Cost = x.Admin_Cost,
                    Program_Cost = x.Program_Cost,
                    Account_NO = x.Account_NO,
                    Doner = x.Doner,
                    No_Of_Expertriate = x.No_Of_Expertriate,
                IngoName = x.GeneralAgreement.Name_of_Ingo_Nepali,
                Pa_Sign_DateNepali=x.Pa_Sign_DateNepali,
                DeletedBy = x.DeletedBy,
                UpDatedBy = x.UpDatedBy,
                UpDatedDaye = x.UpDatedDaye,

                CreatedDate = DateTime.Now,

            }).FirstOrDefault();


            entity.PA_PartnerNgoViewModelList=ent.PA_PartnerNgo.Where(x=>x.ProjectAgreement_ID==id).Select(x=> new PA_PatnerNgoViewModel()
            {
            ProjectAgreement_ID=x.ProjectAgreement_ID,
            Ngo_Number=x.Ngo_Number,
            Amount=x.Amount,
            PA_PatnerNGOs_ID=x.PA_PatnerNGOs_ID,
            Ngo_Name=x.Ngo_Name,
            
            }).ToList();
        
            entity.ProjectAgreement_DistrictsViewModelList = ent.ProjectAgreement_Districts.Where(x => x.ProjectAgreementID == id).Select(x => new ProjectAgreement_DistrictsViewModel()
            {
                ProjectAgreementBudgetBreakDown_ID = x.ProjectAgreementBudgetBreakDown_ID,
                DistrictID = x.DistrictID,
                Locallevel = x.Locallevel,
                ProvienceId = x.ProvienceId,
                DistrictWiseAmmount = x.DistrictWiseAmmount,
                ProjectAgreementID=x.ProjectAgreementID,
                

            }).ToList();
            if (entity.ProjectAgreement_DistrictsViewModelList.Count()>0)
	{
                    foreach (var item in entity.ProjectAgreement_DistrictsViewModelList)
            {
                item.ProvienceName = ent.provincesSetups.Where(x => x.provincesId == item.ProvienceId).FirstOrDefault().provincesName;
                item.DistrictName = ent.ProvincesDistrictSetups.Where(x => x.ProvincesDistrictId == item.DistrictID).FirstOrDefault().DistrictName;
                item.locallevelName = ent.provincesVDCDetails.Where(x => x.ProvincesVDCDetailsID == item.Locallevel).FirstOrDefault().VDCName;

            }
		 
	}
        
            return entity;

        }
        public List<ProjectAgreementViewModel> GetPAList()
        {
            SamajkalyanEntities ent = new SamajkalyanEntities();
            List<ProjectAgreementViewModel> GaList = ent.ProjectAgreements.Select(x => new ProjectAgreementViewModel()
            {
                GeneralAgreement_ID = x.GeneralAgreement_ID,
                ProjectAgreement_ID = x.ProjectAgreement_ID,
                IngoName=x.GeneralAgreement.Name_of_Ingo_Nepali,
                Name_Of_Project = x.Name_Of_Project,
                Name_Of_Project_Nepali = x.Name_Of_Project_Nepali,
                Name_Of_Bank = x.Name_Of_Bank,
                PA_Sign_Date = x.PA_Sign_Date,
                Project_Period = x.Project_Period,
                Total_Budget = x.Total_Budget,
                Admin_Cost = x.Admin_Cost,
                Program_Cost = x.Program_Cost,
                Account_NO = x.Account_NO,
                Doner = x.Doner,
                No_Of_Expertriate = x.No_Of_Expertriate,
                Pa_Sign_DateNepali=x.Pa_Sign_DateNepali,

                DeletedBy = x.DeletedBy,
                UpDatedBy = x.UpDatedBy,
                UpDatedDaye = x.UpDatedDaye,
                DeletedDate=x.DeletedDate,

                CreatedDate = DateTime.Now,
            }).Where(x => x.DeletedDate == null).ToList();
            return GaList;
        }



        public int Delete(int id)
        {
            SamajkalyanEntities ent = new SamajkalyanEntities();
            try
            {
                //delete Deployment employee
                
                //delete Deplpoyment
                var obj = ent.ProjectAgreements.ToList().Where(x => x.ProjectAgreement_ID == id).FirstOrDefault();
                obj.DeletedDate = DateTime.Now;
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
    }
}