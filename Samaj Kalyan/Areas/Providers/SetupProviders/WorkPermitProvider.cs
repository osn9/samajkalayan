using Samaj_Kalyan.SamajKalayan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samaj_Kalyan.Areas.Admin.Models.SetupViewModel;

using System.Data.Entity;

namespace Samaj_Kalyan.Areas.Providers.SetupProviders
{
    public class WorkPermitProvider
    {

        SamajkalyanEntities ent = new SamajkalyanEntities();
        public bool InsertUpdateWorkPermit(WorkPermitViewModel model)
        {


            using (SamajkalyanEntities ent = new SamajkalyanEntities())
            {
                try
                {
                    var workPermitRow = ent.WorkPermits.Where(x => x.WorkPermitId == model.WorkPermitId).FirstOrDefault();
                    //_context.Database.Connection.Open();
                    //_context.Database.Connection.BeginTransaction();
                    if (workPermitRow == null)
                    {
                        workPermitRow = new WorkPermit();
                    };
                   // workPermitRow.WorkPermitId = model.WorkPermitId;
                    workPermitRow.GA_Id = model.GA_Id;
                    workPermitRow.PA_Id = model.PA_Id;
                    workPermitRow.WorkPermitTypeId = model.WorkPermitTypeId;
                    workPermitRow.NameOfApplicant = model.NameOfApplicant;
                    workPermitRow.Council_sRegistrationNumber = model.Council_sRegistrationNumber;
                    workPermitRow.CouncilRegistrationDate = model.CouncilRegistrationDate;
                    workPermitRow.CouncilRegistrationDateNp = model.CouncilRegistrationDateNp;
                    workPermitRow.Country = model.Country;
                    workPermitRow.PassportNumber = model.PassportNumber;
                    workPermitRow.VisaDuration = model.VisaDuration;
                    workPermitRow.ApplicationDesingation = model.ApplicationDesingation;
                    workPermitRow.DecisionDate = model.DecisionDate;
                    workPermitRow.VisaType = model.VisaType;
                    workPermitRow.Remarks = model.Remarks;

                    workPermitRow.CreatedBy = model.CreatedBy;
                    workPermitRow.CreatedDate = model.CreatedDate;
                    //deploymentRow.Status = true;
                    if (model.WorkPermitId == 0)
                    {
                        // generalAgreementRow.Status = false;
                        ent.WorkPermits.Add(workPermitRow);
                        ent.SaveChanges();
                    }
                    else
                    {
                        // deploymentRow.Status = dmodel.Status ?? false;
                        workPermitRow.UpDatedBy = model.UpDatedBy;
                        workPermitRow.UpdatedDate = model.UpdatedDate;
                        ent.WorkPermits.Attach(workPermitRow);
                        ent.Entry(workPermitRow).State = EntityState.Modified;
                        ent.SaveChanges();
                    }
                    if (model.WorkPermitId <= 0)
                    {
                        model.WorkPermitId = ent.Database.SqlQuery<WorkPermitViewModel>("select * from WorkPermit where WorkPermitId=(select max (WorkPermitId) from WorkPermit )").ToList().FirstOrDefault().WorkPermitId;
                        //employeeRow.EmpId=employeeRow.EmpId != 0 ? employeeRow.EmpId : empModel.EmpId;

                    }

                    #region WP_FAmily

                    using (var tempContext = new SamajkalyanEntities())
                    {
                        var deletelist = tempContext.WpaFamilies.Where(x => x.WorkPermitId == model.WorkPermitId).ToList();
                        if (deletelist.Count > 0)
                        {
                            foreach (var item in deletelist)
                            {
                                if (model.WpaFamilyViewModelList == null)
                                {
                                    model.WpaFamilyViewModelList = new List<WpaFamilyViewModel>();
                                }
                                var isExists = model.WpaFamilyViewModelList.Where(x => x.WPAFamilyId == item.WPAFamilyId).FirstOrDefault();
                                if (isExists == null)
                                {
                                    tempContext.WpaFamilies.Remove(item);
                                    tempContext.SaveChanges();
                                }
                            }

                        }
                    }

                    if (model.WpaFamilyViewModelList != null)
                    {
                        foreach (var item in model.WpaFamilyViewModelList)
                        {
                            WpaFamily newRow = new WpaFamily();
                            newRow.WorkPermitId = model.WorkPermitId;
                            newRow.WPAFamilyId = item.WPAFamilyId;
                            newRow.Name = item.Name;
                            newRow.Country = item.Country;
                            newRow.PassportNO = item.PassportNO;
                            newRow.VisaDuration = item.VisaDuration;
                            newRow.VisaType = item.VisaType;
                            newRow.DicisionDate = item.DeletdDate;
                            newRow.DicisionDateNp = item.DicisionDateNp;
                            newRow.Relation = item.Relation;
                            newRow.remark = item.remark;
                            //newRow.NoOfDep = item.NoOfDep;

                            if (item.WPAFamilyId == 0)
                            {
                                ent.WpaFamilies.Add(newRow);
                                ent.SaveChanges();
                            }
                            else
                            {
                                ent.WpaFamilies.Attach(newRow);
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

        public List<WorkPermitViewModel> GetList()
        {
            List<WorkPermitViewModel> List = ent.WorkPermits.Select(x => new WorkPermitViewModel()
            {

                DeletedDate = x.DeletedDate,
                DeletedBy = x.DeletedBy,
                UpDatedBy = x.UpDatedBy,
                UpdatedDate =x.UpdatedDate,
                NameOfApplicant = x.NameOfApplicant,
                GA_Id=x.GA_Id,
                PA_Id=x.PA_Id,
                WorkPermitTypeId=x.WorkPermitTypeId,
                WorkPermitTypeIdName=x.WorKPermitType.Name,
                Council_sRegistrationNumber=x.Council_sRegistrationNumber,
                CouncilRegistrationDate=x.CouncilRegistrationDate,
                CouncilRegistrationDateNp=x.CouncilRegistrationDateNp,
                Country=x.Country,
                PassportNumber=x.PassportNumber,
                VisaDuration=x.VisaDuration,
                ApplicationDesingation=x.ApplicationDesingation,
                DecisionDate=x.DecisionDate,
                DecisionDateNp=x.DecisionDateNp,
                VisaType=x.VisaType,
                Remarks=x.Remarks,
                WorkPermitId=x.WorkPermitId,

                
                CreatedDate = DateTime.Now,
                CreatedBy=x.CreatedBy
                


            }).Where(x => x.DeletedDate == null).ToList();


            return List;
        }
        public WorkPermitViewModel GeWorkpermitById(int id)
        {
            WorkPermitViewModel model = ent.WorkPermits.Select(x => new WorkPermitViewModel()
            {

                DeletedDate = x.DeletedDate,
                DeletedBy = x.DeletedBy,
                UpdatedDate = x.UpdatedDate,
                UpDatedBy = x.UpDatedBy,
                NameOfApplicant = x.NameOfApplicant,
                GA_Id = x.GA_Id,
                PA_Id = x.PA_Id,
                WorkPermitTypeId = x.WorkPermitTypeId,
                Council_sRegistrationNumber = x.Council_sRegistrationNumber,
                CouncilRegistrationDate = x.CouncilRegistrationDate,
                CouncilRegistrationDateNp = x.CouncilRegistrationDateNp,
                Country = x.Country,
                PassportNumber = x.PassportNumber,
                VisaDuration = x.VisaDuration,
                ApplicationDesingation = x.ApplicationDesingation,
                DecisionDate = x.DecisionDate,
                DecisionDateNp = x.DecisionDateNp,
                VisaType = x.VisaType,
                Remarks = x.Remarks,
                WorkPermitId=x.WorkPermitId,
                

                CreatedDate = DateTime.Now,
                CreatedBy = x.CreatedBy





            }).Where(x => x.WorkPermitId == id).FirstOrDefault();

            model.WpaFamilyViewModelList = ent.WpaFamilies.Where(x => x.WorkPermitId == id).Select(x => new WpaFamilyViewModel()
            {
                WorkPermitId = x.WorkPermitId,
                WPAFamilyId = x.WPAFamilyId,
                Name = x.Name,
                Country=x.Country,
                PassportNO=x.PassportNO,
                VisaType=x.VisaType,
                VisaDuration=x.VisaDuration,
                DicisionDate=x.DicisionDate,
                Relation=x.Relation,
                remark = x.remark,
                DicisionDateNp = x.DicisionDateNp,

            }).ToList();

            return model;
        }

        public int Delete(int id)
        {
            try
            {
                //delete Deployment employee

                //delete Deplpoyment
                var obj = ent.WorkPermits.Where(x => x.WorkPermitId == id).FirstOrDefault();
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