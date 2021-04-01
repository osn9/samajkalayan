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
    public class GeneralAgrementController : Controller
    {
        //
        // GET: /Admin/GeneralAgrement/
        GeneralAgrementProvidercs pro = new GeneralAgrementProvidercs();
        public ActionResult Index()
        {
            GeneralAgreementViewModel model = new GeneralAgreementViewModel();
            model.GeneralAgreementViewModelList = pro.GetGAList();

            return View(model);
        }
        public ActionResult InsertUpdateGeneralAgreement(int? id)
        {
            GeneralAgreementViewModel model = new GeneralAgreementViewModel();
            if (id > 0)
            {
               // GeneralAgreementViewModel model = pro.InsertGeneralAgreement(id ?? 0);
            
                if (id==null)
                {
                    string[] stringarray = new string[] { };
                   
                }
                if (id!=null)
                {
                    string[] stringarray = new string[] { };
                    model = pro.GetGAByID(id);
                    if (model.Scan_GA_Location!=null)
                    {
                        stringarray = model.Scan_GA_Location.Split('_');
                        model.Scan_GA_Name = stringarray[1].ToString();
                    }
                    return View(model);
                }

                
            }
          //  return View(new DeploymentModel());
            return View(model);
            //return View(model);
        }
        [HttpPost]
        public ActionResult InsertUpdateGeneralAgreement(GeneralAgreementViewModel model)
        {
            try
            {
                //var result = depl.InsertUpdateEmployee(empModel);
                HttpPostedFileBase Scan_GA;
                HttpPostedFileBase PA_Attachment;
                string fileScanGA = "";
                string filePA_Attachment = "";
                int permittedSizeInBytes = 5 * 1024 * 1024;
                var filenamelen = 50;
                string filename;

                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    //region image
                    #region Ga Scan

                    //var a = model.Scan_GA_Change;
                    //if (a != null && Request.Files["Scan_GA"] != null)
                    //{
                        
                    //}
                    //if (a  && Request.Files["Scan_GA"] != null)
                    //{

                    //}

                    //if (Request.Files["Scan_GA"] !=null)
                    //{
                        
                    //}
                    if (model.Scan_GA_Change != null && Request.Files["Scan_GA"] != null)
                    {
                        Scan_GA = Request.Files["Scan_GA"];

                        if (Scan_GA.ContentLength > permittedSizeInBytes)
                        {
                            //model.Msg = "Images sizes exced 5mb";
                            //model.Success = false;
                            //return Json(rModel, JsonRequestBehavior.AllowGet);
                            return null;
                        }
                        else
                        {
                            filename = Path.GetFileName(Scan_GA.FileName);
                            if (filename.Length > filenamelen)
                            {
                                filename = filename.Substring(filename.Length - filenamelen, filenamelen);
                            }
                            string nonReplaceStringFile = Guid.NewGuid().ToString() + "_" + filename;
                            fileScanGA = Regex.Replace(nonReplaceStringFile, @"-", "");
                            string imagepath = @"~/Content/Attachment/" + fileScanGA;
                            try
                            {
                                System.IO.File.Delete(Server.MapPath(@"~" + model.Scan_GA_Name));
                            }
                            catch (Exception ex)
                            {
                                //throw;
                            }
                            Scan_GA.SaveAs(Server.MapPath(imagepath));

                            model.Scan_GA_Location = @"/Content/Attachment/" + fileScanGA;
                        }
                    }
                }
#endregion
               
                    var result = pro.InsertGeneralAgreement2(model);

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
        public ActionResult AddMoreAttachment(int counter) 
        {
            GaAttachmentViewModel ga_amodel = new GaAttachmentViewModel();
            ViewBag.Counter = counter;
            return PartialView("_attachment", ga_amodel);
        }
        public FileResult Download(string fileLocation)
        
        
        {

            string[] extension = fileLocation.Split('.');
            string filename = extension[1].ToString();
            string contentType = filename;
           // string[] extension2 = filename.Split('.');
            //string a = extension[0].ToString();
            //string[] a1 = a.Split('/');
            //string a2 = a1[0].ToString();
            //string a3 = a1[1].ToString();
            //string a4 = a1[2].ToString();
            //string a5 =a1[3].ToString();
            //string[] b = a5.Split('_');
            //string a6 = b[1].ToString();
            //string adasda = "/" + a3 + "/" + a4+"_"+a6+"."+filename;
            
            //if (contentType.Contains("pdf"))
            //{
            //    return new FilePathResult(fileLocation, "GeneralAgrement/" + contentType);
            //}
            return File(fileLocation, "GeneralAgrement/" + contentType, fileLocation);
        }

        public JsonResult delete(int id)
        {
            var a = Request.IsAjaxRequest();
            var result = 0;
            if (id != null)
            {
                result = pro.Delete(id);
            }
            if (result == 1)
            {
                if (a==true)
                {
              // return Json(result, JsonRequestBehavior.AllowGet);
               return Json("chamara", JsonRequestBehavior.AllowGet);
                   // return RedirectToAction("Index", "GeneralAgrement", new { area = "Area" });
                }
               return Json(result, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            else
            {
                return Json(result, JsonRequestBehavior.AllowGet);
               // return RedirectToAction("Index");
            }
        
        }




        public ActionResult Details(int id)
        {
            GeneralAgreementViewModel abc = pro.GetGAByID(id);
            return PartialView(abc);

     
        }
        public JsonResult ShowNoOfExpGa()
        {
            var jpt = pro.getnoexpga();
            
            return Json(jpt, JsonRequestBehavior.AllowGet);
        }
	}
}