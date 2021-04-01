using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samaj_Kalyan.Areas.Admin.Models.SetupViewModel;
using Samaj_Kalyan.SamajKalayan.Entities;
using System.Data.Entity;


namespace Samaj_Kalyan.Areas.Providers.SetupProviders
{
    public class IngoTerminationProvider
    {
        public bool Insert(IngoTerminationViewModel model)
        {


            using (SamajkalyanEntities ent = new SamajkalyanEntities())
            {
                try
                {
                    var Row = ent.IngoTerminations.Where(x => x.TerminationId == model.TerminationId).FirstOrDefault();
                    //_context.Database.Connection.Open();
                    //_context.Database.Connection.BeginTransaction();
                    if (Row == null)
                    {
                        Row = new IngoTermination();
                    };
                    Row.NameOfAssest = model.NameOfAssest;
                    Row.TerminationDate = model.TerminationDate;
                    Row.TerminationDateNp = model.TerminationDateNp;
                   Row.IngoId = model.IngoId;
                    Row.EvaluationOfReportAttached = model.EvaluationOfReportAttached;
                   

                    //deploymentRow.Status = true;
                    if (model.TerminationId == 0)
                    {
                        // generalAgreementRow.Status = false;
                        Row.CreatedDate = model.DeletdDate;
                        Row.CreatedBy = model.CreatedBy;
                        ent.IngoTerminations.Add(Row);
                     

                        ent.SaveChanges();
                    }
                    else
                    {

                        // deploymentRow.Status = dmodel.Status ?? false;
                        Row.UpdateBy = model.UpdateBy;
                        Row.UpdateDate = model.UpdateDate;
                        ent.IngoTerminations.Attach(Row);
                        ent.Entry(Row).State = EntityState.Modified;
                        ent.SaveChanges();

                    }
                    //if (model.TerminationId <= 0)
                    //{
                    //    model.GeneralAgreement_ID = ent.Database.SqlQuery<GeneralAgreementViewModel>("select * from GeneralAgreement where GeneralAgreement_ID=(select max (GeneralAgreement_ID) from GeneralAgreement )").ToList().FirstOrDefault().GeneralAgreement_ID;
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



        public List<IngoTerminationViewModel> GetIngoTerminationList()
        {
            SamajkalyanEntities ent = new SamajkalyanEntities();
            List<IngoTerminationViewModel> List = ent.IngoTerminations.Select(x => new IngoTerminationViewModel()
            {
               NameOfAssest= x.NameOfAssest,
               IngoId=x.IngoId,
               TerminationId=x.TerminationId,
               TerminationDate=x.TerminationDate,
               TerminationDateNp=x.TerminationDateNp,
               EvaluationOfReportAttached=x.EvaluationOfReportAttached,
               IngoName=x.GeneralAgreement.Name_of_Ingo_Nepali,
               DeletdDate=x.DeletdDate,
               DeletedBy=x.DeletedBy,
               
            }).Where(x=>x.DeletdDate==null).ToList();
               
            //}).Where(x => x.DeletedDate == null).ToList();
            return List;
        }
        public IngoTerminationViewModel GetIngoTerminationById(int id)
        {
            SamajkalyanEntities ent = new SamajkalyanEntities();
            IngoTerminationViewModel List = ent.IngoTerminations.Select(x => new IngoTerminationViewModel()
            {
                NameOfAssest = x.NameOfAssest,
                IngoId = x.IngoId,
                TerminationId = x.TerminationId,
                TerminationDate = x.TerminationDate,
                TerminationDateNp=x.TerminationDateNp,
                EvaluationOfReportAttached = x.EvaluationOfReportAttached,
                IngoName = x.GeneralAgreement.Name_Of_Ingo,
                DeletdDate=x.UpdateDate,
                DeletedBy=x.DeletedBy,
            }).Where(x=>x.TerminationId==id).FirstOrDefault();

            //}).Where(x => x.DeletedDate == null).ToList();
            return List;
        }


        public int Delete(int id)
        {
            SamajkalyanEntities ent = new SamajkalyanEntities();
            try
            {
                //delete Deployment employee

                //delete Deplpoyment
                var obj = ent.IngoTerminations.ToList().Where(x => x.TerminationId == id).FirstOrDefault();
                obj.DeletdDate = DateTime.Now;
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