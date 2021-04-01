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
    public class HandOver_TakeOverController : Controller
    {
        //
        // GET: /Admin/HandOver_TakeOver/
        HandOver_TakeOverProvider pro = new HandOver_TakeOverProvider();
        public ActionResult Index()
        {
            HandOver_TakeOverViewModel model = new HandOver_TakeOverViewModel();
            model.HandOver_TakeOverViewModelList = pro.GetList();
            return View(model);
        }


        public ActionResult InsertUpdate(int? id)
        {
            HandOver_TakeOverViewModel model = new HandOver_TakeOverViewModel();
            if (id > 0)
            {
                model = pro.GeById(id ?? 0);
            }


            return View(model);
        }
        [HttpPost]
        public ActionResult InsertUpdate(HandOver_TakeOverViewModel model)
        {
            try
            {
                var result = pro.InsertUpdate(model);
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
            HandOver_TakeOverViewModel abc = pro.GeById(id);
            return PartialView(abc);

        }



	}
}