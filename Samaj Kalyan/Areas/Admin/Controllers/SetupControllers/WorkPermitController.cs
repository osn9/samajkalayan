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
    public class WorkPermitController : Controller
    {
        //
        // GET: /Admin/WorkPermit/
        WorkPermitProvider pro = new WorkPermitProvider();
        public ActionResult Index()
        {
            WorkPermitViewModel model = new WorkPermitViewModel();
            model.WorkPermitViewModelList = pro.GetList();

            return View(model);
        }

        public ActionResult InsertUpdateWorkPermit(int? id)
        {
            WorkPermitViewModel model = new WorkPermitViewModel();
            if (id > 0)
            {
                model = pro.GeWorkpermitById(id ?? 0);
            }


            return View(model);
        }
        [HttpPost]
        public ActionResult InsertUpdateWorkPermit(WorkPermitViewModel model)
        {
            try
            {
                var result = pro.InsertUpdateWorkPermit(model);
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

        public JsonResult GetPaByGaId(int id)
        {
            var alist = Utility.CommonUtility.GetPAbyGA(id);
            
            return Json(new SelectList(alist, "Value", "Text"),JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddWPFamilyMember()
        {
            return PartialView("_wpaFamily",new WpaFamilyViewModel());
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
            WorkPermitViewModel abc = pro.GeWorkpermitById(id);
            return PartialView(abc);


        }
	}
}