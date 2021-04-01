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
    public class RenewalController : Controller
    {
        IngoRenewalprovider pro = new IngoRenewalprovider();
        //
        // GET: /Admin/Renewal/
     
        public ActionResult Index()
        {
            IngoRenewalViewModel model = new IngoRenewalViewModel();
            model.IngoRenewalViewModelList = pro.GetIngoRenewalList();
            return View(model);
        }
        public ActionResult InsertUpdateRenewal(int? id)
        {
            IngoRenewalViewModel model = new IngoRenewalViewModel();

            if (id > 0)
            {


                if (id == null)
                {
                    string[] stringarray = new string[] { };

                }
                if (id != null)
                {
                    string[] stringarray = new string[] { };
                   // model = pro.GetGAByID(id);
                    model = pro.GetIIngoRenewalById(id ?? 0);
                    if (model.FileLocation != null)
                    {
                        stringarray = model.FileLocation.Split('_');
                        model.File_Name = stringarray[1].ToString();
                    }
                    model.IngoRewnewalDocumentViewModelList = pro.getDocumentList(id??0);
                    return View(model);
                }
               // model = pro.GetIIngoRenewalById(id??0);
                

                return View(model);
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult InsertUpdateRenewal(IngoRenewalViewModel model)
        {
            try
            {
                HttpPostedFileBase Scan_File;
                HttpPostedFileBase PA_Attachment;
                HttpPostedFileBase D_File;
                string fileScanGA = "";
                string filePA_Attachment = "";
                string DocumentName = "";
                int permittedSizeInBytes = 5 * 1024 * 1024;
                var filenamelen = 50;
                string filename;
                List<String> filenameList = new List<string>();



                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    //region image
                    #region Ga Scan


                    if (model.File_Change != null && Request.Files["Scan_GA"] != null)
                    {
                        Scan_File = Request.Files["Scan_GA"];

                        if (Scan_File.ContentLength > permittedSizeInBytes)
                        {
                            //model.Msg = "Images sizes exced 5mb";
                            //model.Success = false;
                            //return Json(rModel, JsonRequestBehavior.AllowGet);
                            return null;
                        }
                        else
                        {
                            filename = Path.GetFileName(Scan_File.FileName);
                            if (filename.Length > filenamelen)
                            {
                                filename = filename.Substring(filename.Length - filenamelen, filenamelen);
                            }
                            string nonReplaceStringFile = Guid.NewGuid().ToString() + "_" + filename;
                            fileScanGA = Regex.Replace(nonReplaceStringFile, @"-", "");
                            string imagepath = @"~/Content/Attachment/" + fileScanGA;
                            try
                            {
                                System.IO.File.Delete(Server.MapPath(@"~" + model.FileLocation));
                            }
                            catch (Exception ex)
                            {
                                //throw;
                            }
                            Scan_File.SaveAs(Server.MapPath(imagepath));

                            model.FileLocation = @"/Content/Attachment/" + fileScanGA;
                        }
                    }
                }
                    #endregion

                #region Documentfile

                int mincount = 0;
                for (int i = 0; i < model.IngoRewnewalDocumentViewModelList.Count; i++)
                {
                    if (model.IngoRewnewalDocumentViewModelList[i].DocumentId == 0)
                    {
                        mincount = i; break;
                    }
                }

                if (Request.Files["postedFile"] != null)
                {
                    var files = Request.Files;
                    for (int i = 0, count = 0; i < files.Count; i++)
                    {
                        if (Request.Files.GetKey(i) == "postedFile")
                        {

                            D_File = Request.Files[i];
                            if (D_File.ContentLength > 0)
                            {
                                if (D_File.ContentLength > permittedSizeInBytes)
                                {
                               
                                    return null;
                                }
                                else
                                {
                                    filename = Path.GetFileName(D_File.FileName);
                                    if (filename.Length > filenamelen)
                                    {
                                        filename = filename.Substring(filename.Length - filenamelen, filename.Length);
                                    }
                                    string nonReplaceStringFile = Guid.NewGuid().ToString() + "_" + filename;
                                    DocumentName = Regex.Replace(nonReplaceStringFile, @"-", "");
                                    string empfilePath = @"~/Content/Attachment/" + i + DocumentName;
                                    try
                                    {
                                        System.IO.File.Delete(Server.MapPath(@"~" + model.objIngoRewnewalDocumentViewModel.DocumentLocation));
                                    }
                                    catch (Exception)
                                    {
                                        //throw;
                                    }
                                    D_File.SaveAs(Server.MapPath(empfilePath));
                                    filenameList.Add(DocumentName);
                                    model.IngoRewnewalDocumentViewModelList[mincount + count].DocumentLocation = @"/Content/Attachment/" + i + DocumentName;
                                }
                            }
                            count++;
                        }
                    }


                }

                // }



                #endregion

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

        public ActionResult AddMoreDocument(int counter)
        {
            IngoRewnewalDocumentViewModel mo = new IngoRewnewalDocumentViewModel();

            ViewBag.Counter = counter;
            return PartialView("_RenewalDocument", mo);
        }

	}
}