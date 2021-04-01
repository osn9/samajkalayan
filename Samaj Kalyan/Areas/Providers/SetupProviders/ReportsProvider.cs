using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samaj_Kalyan.Areas.Admin.Models;
using Samaj_Kalyan.SamajKalayan.Entities;
using System.Data.Entity;
namespace Samaj_Kalyan.Areas.Providers.SetupProviders
{
    public class ReportsProvider
    {

        public GeneralAgreement GetGAByID(int? id)
        {
            SamajkalyanEntities ent = new SamajkalyanEntities();
            GeneralAgreement entity = ent.GeneralAgreements.Where(x => x.GeneralAgreement_ID == id).FirstOrDefault();
            return entity;

        }

    }
}