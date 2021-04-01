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
    public class VehicleAuctionController : Controller
    {
        //
        // GET: /Admin/VehicleAuction/
        VehicleAuctionProvider pro = new VehicleAuctionProvider();

        public ActionResult Index()
        {
            VehicleAuctionViewModel model = new VehicleAuctionViewModel();
            model.VehicleAuctionViewModelList = pro.GetList();

            return View(model);
     
        }

          public ActionResult InsertUpdate(int? id)
        {
            VehicleAuctionViewModel model = new VehicleAuctionViewModel();
            if (id > 0)
            {
                model = pro.GeById(id ?? 0);
            }


            return View(model);
        }
        [HttpPost]
          public ActionResult InsertUpdate(VehicleAuctionViewModel model)
        {
            try
            {
                var result = pro.InsertVehicleAuction(model);
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
            VehicleAuctionViewModel abc = pro.GeById(id);
            return PartialView(abc);

        }






	}
}