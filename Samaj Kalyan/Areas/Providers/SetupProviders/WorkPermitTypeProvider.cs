using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samaj_Kalyan.Areas.Admin.Models.SetupViewModel;
using Samaj_Kalyan.SamajKalayan.Entities;
using System.Data.Entity;

namespace Samaj_Kalyan.Areas.Providers.SetupProviders
{
    public class WorkPermitTypeProvider
    {
        SamajkalyanEntities ent = new SamajkalyanEntities();
        public bool InsertUpdateWorkPermitType(WorkPermitTypeViewModel model)
        {


            using (SamajkalyanEntities ent = new SamajkalyanEntities())
            {
                try
                {
                    var workPermitTypeRow = ent.WorKPermitTypes.Where(x => x.WorkPermitTypeId == model.WorkPermitTypeId).FirstOrDefault();
                    //_context.Database.Connection.Open();
                    //_context.Database.Connection.BeginTransaction();
                    if (workPermitTypeRow == null)
                    {
                        workPermitTypeRow = new WorKPermitType();
                    };
                    workPermitTypeRow.Name = model.Name;
                    workPermitTypeRow.CreatedBy = model.CreatedBy;
                    workPermitTypeRow.CreatedDate = model.CreatedDate;
                    //deploymentRow.Status = true;
                    if (model.WorkPermitTypeId == 0)
                    {
                        // generalAgreementRow.Status = false;
                        ent.WorKPermitTypes.Add(workPermitTypeRow);
                        ent.SaveChanges();
                    }
                    else
                    {
                        // deploymentRow.Status = dmodel.Status ?? false;
                        workPermitTypeRow.UpdatedBy = model.UpdatedBy;
                        workPermitTypeRow.UdatedDate = model.UdatedDate;
                        ent.WorKPermitTypes.Attach(workPermitTypeRow);
                        ent.Entry(workPermitTypeRow).State = EntityState.Modified;
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


        public List<WorkPermitTypeViewModel> GetList()
        {
            List<WorkPermitTypeViewModel> List = ent.WorKPermitTypes.Select(x => new WorkPermitTypeViewModel()
            {
              
                DeletedDate=x.DeletedDate,
                DeletedBy = x.DeletedBy,
                UdatedDate = x.UdatedDate,
                UpdatedBy = x.UpdatedBy,
                Name=x.Name,
                CreatedDate = DateTime.Now,

                WorkPermitTypeId=x.WorkPermitTypeId,



            }).Where(x => x.DeletedDate == null).ToList();


            return List;
        }
        public WorkPermitTypeViewModel GeWorkpermitById(int id)
        {
            WorkPermitTypeViewModel model = ent.WorKPermitTypes.Select(x => new WorkPermitTypeViewModel()
            {

                DeletedDate = x.DeletedDate,
                DeletedBy = x.DeletedBy,
                UdatedDate = x.UdatedDate,
                UpdatedBy = x.UpdatedBy,
                Name = x.Name,
                CreatedDate = DateTime.Now,
                WorkPermitTypeId=x.WorkPermitTypeId,




            }).Where(x => x.WorkPermitTypeId == id).FirstOrDefault();


            return model;
        }

    }
}