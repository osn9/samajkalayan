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
       [Authorize]
    public class IngoTerminationController : Controller
    {
        //
        // GET: /Admin/IngoTermination/
        IngoTerminationProvider pro = new IngoTerminationProvider();
        public ActionResult Index()
        {
            IngoTerminationViewModel model = new IngoTerminationViewModel();
            model.IngoTerminationViewModelList = pro.GetIngoTerminationList();
            return View(model);
        }
        public ActionResult InsertUpdateTermination(int? id )
        {
            IngoTerminationViewModel model = new IngoTerminationViewModel();
            if (id>0)
            {
                model = pro.GetIngoTerminationById(id??0);
            }

            
            return View(model);
        }
        [HttpPost]
        public ActionResult InsertUpdateTermination(IngoTerminationViewModel model)
        {
            try
            {
                var result = pro.Insert(model);
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
	}
}