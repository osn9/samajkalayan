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
    public class PrincipaleConstantOfVolunteerController : Controller
    {
        //
        // GET: /Admin/PrincipaleConstantOfVolunteer/
        PrincipaleConstantOfVolunteerProvider pro = new PrincipaleConstantOfVolunteerProvider();
        public ActionResult Index()
        {
            PrincipaleConstantOfVolunteerViewModel model = new PrincipaleConstantOfVolunteerViewModel();
            model.PrincipaleConstantOfVolunteerViewModelList = pro.GetPCAList();
            return View(model);
        }

        public ActionResult InsertUpdatePCV(int? id)
        {
            PrincipaleConstantOfVolunteerViewModel model = new PrincipaleConstantOfVolunteerViewModel();
            if (id > 0)
            {
                if (id != null)
                {
                    model = pro.GetPCVByID(id);
                    return View(model);
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult InsertUpdatePCV(PrincipaleConstantOfVolunteerViewModel model)
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


            catch (Exception ex)
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
            PrincipaleConstantOfVolunteerViewModel abc = pro.GetPCVByID(id);
            return PartialView(abc);

        }

	}
}