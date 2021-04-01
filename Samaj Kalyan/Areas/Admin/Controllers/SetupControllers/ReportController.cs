using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Samaj_Kalyan.Areas.Providers.SetupProviders;
using Samaj_Kalyan.Areas.Admin.Models;
using Samaj_Kalyan.SamajKalayan.Entities;
using System.IO;
using System.Text.RegularExpressions;

namespace Samaj_Kalyan.Areas.Admin.Controllers.SetupControllers
{
      [Authorize]
    public class ReportController : Controller
    {
        //
        // GET: /Admin/Report/
        ReportsProvider pro = new ReportsProvider();
        GeneralAgrementProvidercs gpro = new GeneralAgrementProvidercs();
        public ActionResult Index(int id)
        {
            GeneralAgreement model = new GeneralAgreement();
            model = pro.GetGAByID(id);
            return View(model);
        }
        public ActionResult GaReport()
        {
            GeneralAgreementViewModel model = new GeneralAgreementViewModel();
            model.GeneralAgreementViewModelList = gpro.GetGAList();

            return View(model);
        }
	}
}