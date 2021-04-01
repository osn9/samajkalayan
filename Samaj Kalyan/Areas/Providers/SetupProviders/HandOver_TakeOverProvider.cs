using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samaj_Kalyan.Areas.Admin.Models.SetupViewModel;
using Samaj_Kalyan.SamajKalayan.Entities;
using System.Data.Entity;


namespace Samaj_Kalyan.Areas.Providers.SetupProviders
{
    public class HandOver_TakeOverProvider
    {
        SamajkalyanEntities ent = new SamajkalyanEntities();
        public bool InsertUpdate(HandOver_TakeOverViewModel model)
        {


            using (SamajkalyanEntities ent = new SamajkalyanEntities())
            {
                try
                {
                    var workPermitRow = ent.HandOver_TakeOver.Where(x => x.HandOver_TakeOverId == model.HandOver_TakeOverId).FirstOrDefault();

                    if (workPermitRow == null)
                    {
                        workPermitRow = new HandOver_TakeOver();
                    };

                    workPermitRow.GA_Id = model.GA_Id;
                    workPermitRow.PA_Id = model.PA_Id;
                    workPermitRow.ApplicationRegistrationNumber = model.ApplicationRegistrationNumber;

                    workPermitRow.RegistrationDate = model.RegistrationDate;
                    workPermitRow.AssestReciverName = model.AssestReciverName;
                    workPermitRow.DetailsOfAssest = model.DetailsOfAssest;
                    workPermitRow.SummaryOfDecision = model.SummaryOfDecision;

                    workPermitRow.RegistrationDateNp = model.RegistrationDateNp;
                    workPermitRow.TotalValueOfAssest = model.TotalValueOfAssest;
                    workPermitRow.DecisionDate = model.DecisionDate;
                    workPermitRow.DecisionDateNp = model.DecisionDateNp;
                    workPermitRow.Remarks = model.Remarks;

                    workPermitRow.CreatedBy = model.CreatedBy;
                    workPermitRow.CreatedDate = model.CreatedDate;

                    if (model.HandOver_TakeOverId == 0)
                    {

                        ent.HandOver_TakeOver.Add(workPermitRow);
                        ent.SaveChanges();
                    }
                    else
                    {

                        workPermitRow.UpdatedBy = model.UpdatedBy;
                        workPermitRow.UpdateDate = model.UpdateDate;
                        ent.HandOver_TakeOver.Attach(workPermitRow);
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

        public List<HandOver_TakeOverViewModel> GetList()
        {
            List<HandOver_TakeOverViewModel> List = ent.HandOver_TakeOver.Select(x => new HandOver_TakeOverViewModel()
            {
                    HandOver_TakeOverId=x.HandOver_TakeOverId,
                    GA_Id = x.GA_Id,
                    PA_Id = x.PA_Id,
                    ApplicationRegistrationNumber = x.ApplicationRegistrationNumber,

                    RegistrationDate = x.RegistrationDate,
                    AssestReciverName = x.AssestReciverName,
                    DetailsOfAssest = x.DetailsOfAssest,
                    SummaryOfDecision = x.SummaryOfDecision,

                    //RegistrationDateNp = x.RegistrationDateNp,
                    RegistrationDateNp = x.RegistrationDateNp,
                    TotalValueOfAssest = x.TotalValueOfAssest,
                    DecisionDate = x.DecisionDate,
                    DecisionDateNp = x.DecisionDateNp,
                   
                    Remarks = x.Remarks,
                    DeletedDate=x.DeletedDate,

                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
            }).Where(x => x.DeletedDate == null).ToList();
            return List;
        }
        public HandOver_TakeOverViewModel GeById(int id)
        {
            HandOver_TakeOverViewModel model = ent.HandOver_TakeOver.Select(x => new HandOver_TakeOverViewModel()
            {

                HandOver_TakeOverId = x.HandOver_TakeOverId,
                GA_Id = x.GA_Id,
                PA_Id = x.PA_Id,
                ApplicationRegistrationNumber = x.ApplicationRegistrationNumber,

                RegistrationDate = x.RegistrationDate,
                AssestReciverName = x.AssestReciverName,
                DetailsOfAssest = x.DetailsOfAssest,
                SummaryOfDecision = x.SummaryOfDecision,

                //RegistrationDateNp = x.RegistrationDateNp,
                RegistrationDateNp = x.RegistrationDateNp,
                TotalValueOfAssest = x.TotalValueOfAssest,
                DecisionDate = x.DecisionDate,
                DecisionDateNp = x.DecisionDateNp,
                DeletedDate = x.DecisionDate,
                Remarks = x.Remarks,

                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
            }).Where(x => x.HandOver_TakeOverId == id).FirstOrDefault();
            return model;
        }

        public int Delete(int id)
        {
            try
            {

                var obj = ent.HandOver_TakeOver.Where(x => x.HandOver_TakeOverId == id).FirstOrDefault();
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