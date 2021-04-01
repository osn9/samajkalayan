using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Samaj_Kalyan.Areas.Providers.SetupProviders;
using Samaj_Kalyan.Areas.Admin.Models.SetupViewModel;
using Samaj_Kalyan.SamajKalayan.Entities;
using System.IO;
using System.Text.RegularExpressions;

namespace Samaj_Kalyan.Areas.Admin.Controllers.SetupControllers
{
    public class WorKPermitTypeController : Controller
    {
        //
        // GET: /Admin/WorKPermitType/
        WorkPermitTypeProvider pro = new WorkPermitTypeProvider();
        public ActionResult Index()
        {
            WorkPermitTypeViewModel model = new WorkPermitTypeViewModel();
            model.WorkPermitTypeViewModelList = pro.GetList();

            return View(model);
        }

        public ActionResult InsertUpdateWorkPermitType(int? id)
        {
            WorkPermitTypeViewModel model = new WorkPermitTypeViewModel();
            if (id > 0)
            {
                model = pro.GeWorkpermitById(id ?? 0);
            }


            return View(model);
        }
        [HttpPost]
        public ActionResult InsertUpdateWorkPermitType(WorkPermitTypeViewModel model)
        {
            try
            {
                var result = pro.InsertUpdateWorkPermitType(model);
                if (result == true)
                {
                    TempData["SuccessMsg"] = "सफल भयो";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["Msg"] = "असफल भयो ";
                return View();
            }
            return View();


        }

	}
}