using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samaj_Kalyan.Areas.Admin.Models.SetupViewModel;
using Samaj_Kalyan.SamajKalayan.Entities;
using System.Data.Entity;

namespace Samaj_Kalyan.Areas.Providers.SetupProviders
{
    public class VehicleAuctionProvider
    {
        SamajkalyanEntities ent = new SamajkalyanEntities();
        public bool InsertVehicleAuction(VehicleAuctionViewModel model)
        {


            using (SamajkalyanEntities ent = new SamajkalyanEntities())
            {
                try
                {
                    var workPermitRow = ent.VehicleAuctions.Where(x => x.VehicleAuctionId == model.VehicleAuctionId).FirstOrDefault();
                    
                    if (workPermitRow == null)
                    {
                        workPermitRow = new VehicleAuction();
                    };
                    
                    workPermitRow.GA_ID = model.GA_ID;
                    workPermitRow.PA_ID = model.PA_ID;
                    workPermitRow.ApplicationRegistrationNumber = model.ApplicationRegistrationNumber;

                    workPermitRow.VehicleNumber = model.VehicleNumber;
                    workPermitRow.Type = model.Type;
                    workPermitRow.VehicleNumber = model.VehicleNumber;
                    workPermitRow.SummaryOfDecision = model.SummaryOfDecision;

                    workPermitRow.RegistrationDate = model.RegistrationDate;
                    workPermitRow.RegistrationDatep = model.RegistrationDatep;
                    workPermitRow.VehicleType = model.VehicleType;
                    
                    workPermitRow.Remarks = model.Remarks;

                    workPermitRow.CreatedBy = model.CreatedBy;
                    workPermitRow.CreatedDate = model.CreatedDate;
              
                    if (model.VehicleAuctionId == 0)
                    {
                       
                        ent.VehicleAuctions.Add(workPermitRow);
                        ent.SaveChanges();
                    }
                    else
                    {
                    
                        workPermitRow.UpdatedBy = model.UpdatedBy;
                        workPermitRow.UpdateDate = model.UpdateDate;
                        ent.VehicleAuctions.Attach(workPermitRow);
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

        public List<VehicleAuctionViewModel> GetList()
        {
            List<VehicleAuctionViewModel> List = ent.VehicleAuctions.Select(x => new VehicleAuctionViewModel()
            {
                VehicleAuctionId = x.VehicleAuctionId,
                DeletedDate = x.DeletedDate,
                DeletedBy = x.DeletedBy,
                UpdatedBy = x.UpdatedBy,
                UpdateDate = x.UpdateDate,
                GA_ID = x.GA_ID,
                PA_ID = x.PA_ID,
                VehicleType = x.VehicleType,
                Type = x.Type,
                ApplicationRegistrationNumber = x.ApplicationRegistrationNumber,
                RegistrationDate = x.RegistrationDate,
                RegistrationDatep = x.RegistrationDatep,
                DecisionDate = x.DecisionDate,
                DecisionDateNp = x.DecisionDateNp,
                VehicleNumber = x.VehicleNumber,
                SummaryOfDecision = x.SummaryOfDecision,
                Remarks = x.Remarks,
                CreatedDate = DateTime.Now,
                CreatedBy = x.CreatedBy
            }).Where(x => x.DeletedDate == null).ToList();
            return List;
        }
        public VehicleAuctionViewModel GeById(int id)
        {
            VehicleAuctionViewModel model = ent.VehicleAuctions.Select(x => new VehicleAuctionViewModel()
            {
                VehicleAuctionId = x.VehicleAuctionId,
                DeletedDate = x.DeletedDate,
                DeletedBy = x.DeletedBy,
                UpdatedBy = x.UpdatedBy,
                UpdateDate = x.UpdateDate,
                GA_ID = x.GA_ID,
                PA_ID = x.PA_ID,
                VehicleType = x.VehicleType,
                Type = x.Type,
                ApplicationRegistrationNumber = x.ApplicationRegistrationNumber,
                RegistrationDate = x.RegistrationDate,
                RegistrationDatep = x.RegistrationDatep,
                DecisionDate = x.DecisionDate,
                DecisionDateNp = x.DecisionDateNp,
                VehicleNumber = x.VehicleNumber,
                SummaryOfDecision = x.SummaryOfDecision,
                Remarks = x.Remarks,
                CreatedDate = DateTime.Now,
                CreatedBy = x.CreatedBy
            }).Where(x => x.VehicleAuctionId == id).FirstOrDefault();
            return model;
        }

        public int Delete(int id)
        {
            try
            {
               
                var obj = ent.VehicleAuctions.Where(x => x.VehicleAuctionId == id).FirstOrDefault();
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