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
using System.Globalization;


namespace Samaj_Kalyan.Areas.Admin.Controllers.SetupControllers
{
    [Authorize]
    public class ProjectAgreementController : Controller
    {
        //
        // GET: /Admin/ProjectAgreement/
        ProjectAgreementProvider pro = new ProjectAgreementProvider();
        public ActionResult Index()
        {
            ProjectAgreementViewModel model = new ProjectAgreementViewModel();
            model.ProjectAgreementViewModelList = pro.GetPAList();

            return View(model);
        }

        public ActionResult InsertUpdateProjectAgreement(int? id)
        {
            ProjectAgreementViewModel model = new ProjectAgreementViewModel();
        
            if (id > 0)
            {
                 model = pro.GetPAByID(id  );

          
                    return View(model);
                }


            
            
            return View(model);
           
        }
        [HttpPost]
        public ActionResult InsertUpdateProjectAgreement(ProjectAgreementViewModel model)
        {
            try
            {
                var gid = model.GeneralAgreement_ID;
                var gadate = Samaj_Kalyan.Utility.CommonUtility.GetGeneralAgremenetDate(gid ?? 0);
                var gdate = DateTime.Parse(gadate, new CultureInfo("en-US", true));
                var count = Samaj_Kalyan.Utility.CommonUtility.GetGeneralAgremenetPaCount(gid ?? 0,model.ProjectAgreement_ID);
                // var jpt = (model.PA_Sign_Date-model.ge)
                var signdat = model.PA_Sign_Date ?? DateTime.Now;
                var datediif = (gdate - signdat).Days;
                if (count>0)
                {


                    if (datediif <= 0)
                    {
                        var result = pro.InsertProjectAgreement(model);

                        if (result == true)
                        {
                            TempData["SuccessMsg"] = "सफल भयो";
                            return RedirectToAction("Index");
                        }

                    }
                    else
                    {
                        TempData["DMsg"] = "असफल भयो ";
                        return View();
                    }

                }
                else
                {
                    var result = pro.InsertProjectAgreement(model);

                    if (result == true)
                    {
                        TempData["SuccessMsg"] = "सफल भयो";
                        return RedirectToAction("Index");
                    }
                }
            }


            catch (Exception e)
            {
                TempData["Msg"] = "असफल भयो ";
                return View();
            }
            return View();

        }
        public ActionResult AddMoreNgos(int counter)
        {
            PA_PatnerNgoViewModel ga_amodel = new PA_PatnerNgoViewModel();
            ViewBag.Counter = counter;
            return PartialView("_ngoPartners", ga_amodel);
        }
        public ActionResult AddMoreDistricts(int counter)
        {
            ProjectAgreement_DistrictsViewModel ga_amodel = new ProjectAgreement_DistrictsViewModel();
            ViewBag.Counter = counter;
            return PartialView("_districtBudget", ga_amodel);
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
        public JsonResult GetDistrictListByProvinceId(int provinceId)
        {
            var districtsList = Utility.CommonUtility.GetDistrictListByProvinceId(provinceId);
            return Json(new SelectList(districtsList, "ProvincesDistrictId", "DistrictName"));
        }
        public JsonResult GetMunListByDistrictId(int districtId)
        {
            var districtsList = Utility.CommonUtility.GetVdcListByDistrictId(districtId);
            return Json(new SelectList(districtsList, "ProvincesVDCDetailsID", "VDCName"));
        }
        public ActionResult Details(int id)
        {
            ProjectAgreementViewModel abc = pro.GetPAByID(id);
            return PartialView(abc);

        }
	}
}