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
    public class Import_DutyFreeRecommendationController : Controller
    {
        //
        // GET: /Admin/Import_DutyFreeRecommendation/
        Import_DutyFreeRecommendationProvider pro = new Import_DutyFreeRecommendationProvider();
        public ActionResult Index()
        {
            Import_DutyFreeRecommendationViewModel model = new Import_DutyFreeRecommendationViewModel();
            model.Import_DutyFreeRecommendationViewModelList = pro.GetList();
            return View(model);
        }

        public ActionResult InsertUpdate(int? id)
        {
            Import_DutyFreeRecommendationViewModel model = new Import_DutyFreeRecommendationViewModel();
            if (id > 0)
            {
                model = pro.GeById(id ?? 0);
            }


            return View(model);
        }
        [HttpPost]
        public ActionResult InsertUpdate(Import_DutyFreeRecommendationViewModel model)
        {
            try
            {
                var result = pro.InsertImport_DutyFreeRecommendation(model);
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

        public JsonResult delete(int id)
        {
            var a = Request.IsAjaxRequest();
            var result = 0;
            if (id != null)
            {
                result = pro.Delete(id);
                return Json("chamara", JsonRequestBehavior.AllowGet);
            }
            if (result == 1)
            {
                return Json("chamara", JsonRequestBehavior.AllowGet);
                // return RedirectToAction("Index");
                // return View();
            }
            else
            {
                return Json("chamara", JsonRequestBehavior.AllowGet);
                //return View();

            }

        }
        public ActionResult Details(int id)
        {
            Import_DutyFreeRecommendationViewModel abc = pro.GeById(id);
            return PartialView(abc);

        }
	}
}