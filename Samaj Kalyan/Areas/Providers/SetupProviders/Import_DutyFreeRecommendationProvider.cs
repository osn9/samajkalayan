using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samaj_Kalyan.Areas.Admin.Models.SetupViewModel;
using Samaj_Kalyan.SamajKalayan.Entities;
using System.Data.Entity;

namespace Samaj_Kalyan.Areas.Providers.SetupProviders
{
    public class Import_DutyFreeRecommendationProvider
    {
        SamajkalyanEntities ent = new SamajkalyanEntities();
        public bool InsertImport_DutyFreeRecommendation(Import_DutyFreeRecommendationViewModel model)
        {


            using (SamajkalyanEntities ent = new SamajkalyanEntities())
            {
                try
                {
                    var workPermitRow = ent.Import_DutyFreeRecommendation.Where(x => x.ImportId == model.ImportId).FirstOrDefault();
                    //_context.Database.Connection.Open();
                    //_context.Database.Connection.BeginTransaction();
                    if (workPermitRow == null)
                    {
                        workPermitRow = new Import_DutyFreeRecommendation();
                    };
                    // workPermitRow.WorkPermitId = model.WorkPermitId;
                    workPermitRow.GA_Id = model.GA_Id;
                    workPermitRow.PA_Id = model.PA_Id;
                    workPermitRow.Council_RegistrtionNumber = model.Council_RegistrtionNumber;
                    
                    workPermitRow.CouncilRegistrationDate = model.CouncilRegistrationDate;
                    workPermitRow.CouncilRegistrationDateNp = model.CouncilRegistrationDateNp;
                    workPermitRow.DonnerName = model.DonnerName;
                    workPermitRow.DonnerAddress = model.DonnerAddress;
                    workPermitRow.DiscriptionOfGoods = model.DiscriptionOfGoods;
                    workPermitRow.InvoiceDateNp = model.InvoiceDateNp;
                    workPermitRow.DecisionDate = model.DecisionDate;
                    workPermitRow.InvoiceNumber = model.InvoiceNumber;
                    workPermitRow.TotalAmountForieignCurrency = model.TotalAmountForieignCurrency;
                    workPermitRow.TotalAmountNepaliCurrency = model.TotalAmountNepaliCurrency;

                    workPermitRow.Remarks = model.Remarks;

                    workPermitRow.CreatedBy = model.CreatedBy;
                    workPermitRow.CreatedDate = model.CreatedDate;
                    //deploymentRow.Status = true;
                    if (model.ImportId == 0)
                    {
                        // generalAgreementRow.Status = false;
                        ent.Import_DutyFreeRecommendation.Add(workPermitRow);
                        ent.SaveChanges();
                    }
                    else
                    {
                        // deploymentRow.Status = dmodel.Status ?? false;
                        workPermitRow.UpDatedBy = model.UpDatedBy;
                        workPermitRow.UpdateDate = model.UpdateDate;
                        ent.Import_DutyFreeRecommendation.Attach(workPermitRow);
                        ent.Entry(workPermitRow).State = EntityState.Modified;
                        ent.SaveChanges();
                    }
                    //if (model.ImportId <= 0)
                    //{
                    //    model.ImportId = ent.Database.SqlQuery<WorkPermitViewModel>("select * from WorkPermit where WorkPermitId=(select max (WorkPermitId) from WorkPermit )").ToList().FirstOrDefault().WorkPermitId;
                    //    //employeeRow.EmpId=employeeRow.EmpId != 0 ? employeeRow.EmpId : empModel.EmpId;

                    //}

         
                }



                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }

        public List<Import_DutyFreeRecommendationViewModel> GetList()
        {
            List<Import_DutyFreeRecommendationViewModel> List = ent.Import_DutyFreeRecommendation.Select(x => new Import_DutyFreeRecommendationViewModel()
            {
                ImportId=x.ImportId,
                DeletedDate = x.DeletedDate,
                DeletedBy = x.DeletedBy,
                UpDatedBy = x.UpDatedBy,
                UpdateDate = x.UpdateDate,
                GA_Id = x.GA_Id,
                PA_Id = x.PA_Id,
                DonnerName = x.DonnerName,
                DonnerAddress = x.DonnerAddress,
                Council_RegistrtionNumber = x.Council_RegistrtionNumber,
                CouncilRegistrationDate = x.CouncilRegistrationDate,
                CouncilRegistrationDateNp = x.CouncilRegistrationDateNp,
                DiscriptionOfGoods = x.DiscriptionOfGoods,
                InvoiceNumber = x.InvoiceNumber,
                InvoiceDate = x.InvoiceDate,
                InvoiceDateNp = x.InvoiceDateNp,
                DecisionDate = x.DecisionDate,
                DecisionDateNp = x.DecisionDateNp,
                TotalAmountForieignCurrency = x.TotalAmountForieignCurrency,
                TotalAmountNepaliCurrency = x.TotalAmountNepaliCurrency,
                Remarks = x.Remarks,
                CreatedDate = DateTime.Now,
                CreatedBy = x.CreatedBy
            }).Where(x => x.DeletedDate == null).ToList();
            return List;
        }
        public Import_DutyFreeRecommendationViewModel GeById(int id)
        {
            Import_DutyFreeRecommendationViewModel model = ent.Import_DutyFreeRecommendation.Select(x => new Import_DutyFreeRecommendationViewModel()
            {
                ImportId = x.ImportId,
                DeletedDate = x.DeletedDate,
                DeletedBy = x.DeletedBy,
                UpDatedBy = x.UpDatedBy,
                UpdateDate = x.UpdateDate,
                GA_Id = x.GA_Id,
                PA_Id = x.PA_Id,
                DonnerName = x.DonnerName,
                DonnerAddress = x.DonnerAddress,
                Council_RegistrtionNumber = x.Council_RegistrtionNumber,
                CouncilRegistrationDate = x.CouncilRegistrationDate,
                CouncilRegistrationDateNp = x.CouncilRegistrationDateNp,
                DiscriptionOfGoods = x.DiscriptionOfGoods,
                InvoiceNumber = x.InvoiceNumber,
                InvoiceDate = x.InvoiceDate,
                InvoiceDateNp = x.InvoiceDateNp,
                DecisionDate = x.DecisionDate,
                DecisionDateNp = x.DecisionDateNp,
                TotalAmountForieignCurrency = x.TotalAmountForieignCurrency,
                TotalAmountNepaliCurrency = x.TotalAmountNepaliCurrency,
                Remarks = x.Remarks,
                CreatedDate = DateTime.Now,
                CreatedBy = x.CreatedBy
            }).Where(x => x.ImportId == id).FirstOrDefault();
            return model;
        }

        public int Delete(int id)
        {
            try
            {
               
                var obj = ent.Import_DutyFreeRecommendation.Where(x => x.ImportId == id).FirstOrDefault();
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