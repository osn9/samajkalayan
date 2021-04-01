using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samaj_Kalyan.Areas.Admin.Models.SetupViewModel;
using Samaj_Kalyan.SamajKalayan.Entities;
using System.Data.Entity;

namespace Samaj_Kalyan.Areas.Providers.SetupProviders
{
    public class IngoRenewalprovider
    {
        public bool Insert(IngoRenewalViewModel model)
        {


            using (SamajkalyanEntities ent = new SamajkalyanEntities())
            {
                try
                {
                    var Row = ent.IngoRenewals.Where(x => x.RenewalId == model.RenewalId).FirstOrDefault();
                    //_context.Database.Connection.Open();
                    //_context.Database.Connection.BeginTransaction();
                    if (Row == null)
                    {
                        Row = new IngoRenewal();
                    };
                    Row.RenewDate = model.RenewDate;
                    Row.Period = model.Period;
                    Row.IngoId = model.IngoId;
                    Row.RenewCharge = model.RenewCharge;
                    Row.FileLocation = model.FileLocation;
                    Row.RenewalDateNP = model.RenewalDateNP;
                    

                    //deploymentRow.Status = true;
                    if (model.RenewalId == 0)
                    {
                        // generalAgreementRow.Status = false;
                        Row.CreatedDate = model.CreatedDate;
                        Row.CreatedBy = model.CreatedBy;
                        ent.IngoRenewals.Add(Row);


                        ent.SaveChanges();
                    }
                    else
                    {

                        // deploymentRow.Status = dmodel.Status ?? false;
                        Row.UpdatedBy = model.UpdatedBy;
                        Row.UpdatedDate = model.UpdatedDate;
                        ent.IngoRenewals.Attach(Row);
                        ent.Entry(Row).State = EntityState.Modified;
                        ent.SaveChanges();

                    }
                    //if (model.TerminationId <= 0)
                    //{
                    //    model.GeneralAgreement_ID = ent.Database.SqlQuery<GeneralAgreementViewModel>("select * from GeneralAgreement where GeneralAgreement_ID=(select max (GeneralAgreement_ID) from GeneralAgreement )").ToList().FirstOrDefault().GeneralAgreement_ID;
                    //    //employeeRow.EmpId=employeeRow.EmpId != 0 ? employeeRow.EmpId : empModel.EmpId;

                    //}
                    if (model.RenewalId==0)
                    {
                        model.RenewalId = ent.IngoRenewals.Max(x => x.RenewalId);
                    }
                   
                    #region document

                    using (var tempContext = new SamajkalyanEntities())
                    {
                        var deletelist = tempContext.IngoRewnewalDocuments.Where(x => x.RewnewalId == model.RenewalId).ToList();
                        if (deletelist.Count > 0)
                        {
                            foreach (var item in deletelist)
                            {
                                if (model.IngoRewnewalDocumentViewModelList == null)
                                {
                                    model.IngoRewnewalDocumentViewModelList = new List<IngoRewnewalDocumentViewModel>();
                                }
                                var isExists = model.IngoRewnewalDocumentViewModelList.Where(x => x.DocumentId == item.DocumentId).FirstOrDefault();
                                if (isExists == null)
                                {
                                    try
                                    {
                                        System.IO.File.Delete(HttpContext.Current.Server.MapPath(@"~" + item.DocumentLocation));
                                    }
                                    catch (Exception)
                                    {
                                        //throw;
                                    }
                                    tempContext.IngoRewnewalDocuments.Remove(item);
                                    tempContext.SaveChanges();
                                }
                            }

                        }
                    }

                    if (model.IngoRewnewalDocumentViewModelList != null)
                    {
                        foreach (var item in model.IngoRewnewalDocumentViewModelList)
                        {
                            IngoRewnewalDocument newRow = new IngoRewnewalDocument();
                            newRow.DocumentId = item.DocumentId;
                            newRow.RewnewalId = model.RenewalId;
                            newRow.DocumentLocation = item.DocumentLocation;
                            newRow.FileName = item.DocumentName;
                            if (item.DocumentId == 0)
                            {

                                ent.IngoRewnewalDocuments.Add(newRow);
                                ent.SaveChanges();
                            }
                            else
                            {
                                ent.IngoRewnewalDocuments.Attach(newRow);
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
        public List<IngoRenewalViewModel> GetIngoRenewalList()
        {
            SamajkalyanEntities ent = new SamajkalyanEntities();
            List<IngoRenewalViewModel> List = ent.IngoRenewals.Select(x => new IngoRenewalViewModel()
            {
                RenewDate = x.RenewDate,
                    Period = x.Period,
                    IngoId = x.IngoId,
                    RenewCharge = x.RenewCharge,
                RenewalId=x.RenewalId,
                RenewalDateNP=x.RenewalDateNP,
                Ingoname = x.GeneralAgreement.Name_of_Ingo_Nepali,
                DeletetDate = x.DeletetDate,
                DeletedBy = x.DeletedBy,

            }).Where(x => x.DeletetDate == null).ToList();

            //}).Where(x => x.DeletedDate == null).ToList();
            return List;
        }


        public IngoRenewalViewModel GetIIngoRenewalById(int id)
        {
            SamajkalyanEntities ent = new SamajkalyanEntities();
            IngoRenewalViewModel List = ent.IngoRenewals.Select(x => new IngoRenewalViewModel()
            {
                RenewDate = x.RenewDate,
                Period = x.Period,
                IngoId = x.IngoId,
                RenewCharge = x.RenewCharge,
                RenewalId = x.RenewalId,
                Ingoname = x.GeneralAgreement.Name_of_Ingo_Nepali,
                FileLocation=x.FileLocation,
                RenewalDateNP=x.RenewalDateNP,
                DeletetDate = x.DeletetDate,
                DeletedBy = x.DeletedBy,
            }).Where(x => x.RenewalId == id).FirstOrDefault();

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
                var obj = ent.IngoRenewals.ToList().Where(x => x.RenewalId == id).FirstOrDefault();
                obj.DeletetDate = DateTime.Now;
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
        public List<IngoRewnewalDocumentViewModel>getDocumentList(int id)
        {
            SamajkalyanEntities ent = new SamajkalyanEntities();
            var jpt = ent.IngoRewnewalDocuments.Where(x => x.RewnewalId == id).Select(x => new IngoRewnewalDocumentViewModel()
            {
                DocumentId = x.DocumentId,

                DocumentLocation = x.DocumentLocation,
                RewnewalId = x.RewnewalId,
                DocumentName=x.FileName


            }).ToList();
            return jpt;
        }
    }
}