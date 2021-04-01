using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samaj_Kalyan.Areas.Admin.Models;
using Samaj_Kalyan.SamajKalayan.Entities;
using System.Data.Entity;
using System.Web.Mvc;

namespace Samaj_Kalyan.Utility
{
    public class CommonUtility
    {
        public static IEnumerable<SelectListItem> GetIngoName()
        {
            using (var _ct = new SamajkalyanEntities())
            {
                return new SelectList(_ct.GeneralAgreements.Where(x=>x.DeletdedDate==null).ToList(), "GeneralAgreement_ID", "Name_of_Ingo_Nepali");
            }

        }
        public static IEnumerable<SelectListItem> GetProvience()
        {
            using (var _ct = new SamajkalyanEntities())
            {
                
                    return new SelectList(_ct.provincesSetups.Where(x => x.Status == 1).ToList(), "provincesId", "provincesName");
                }
              
            

        }
        public static IEnumerable<SelectListItem> GetDistrict(int? id)
        {
            using (var _ct = new SamajkalyanEntities())
            {
                if (id==null)
                {
                    return new SelectList(_ct.ProvincesDistrictSetups.ToList(), "ProvincesDistrictId", "DistrictName");
                }
                else
                {
                    return new SelectList(_ct.ProvincesDistrictSetups.Where(x=>x.ProvincesId==id).ToList(), "ProvincesDistrictId", "DistrictName");
                }
               
            }

        }
        public static IEnumerable<SelectListItem> GetMunVdc(int? id)
        {
            using (var _ct = new SamajkalyanEntities())
            {
                if (id==null)
                {
                    return new SelectList(_ct.provincesVDCDetails.ToList(), "ProvincesVDCDetailsID", "VDCName");
                    
                }
                else
                {
                    return new SelectList(_ct.provincesVDCDetails.Where(x=>x.ProvincesDistrictId==id).ToList(), "ProvincesVDCDetailsID", "VDCName");

                }
            }

        }
        public static List<ProvincesDistrictSetup> GetDistrictListByProvinceId(int provinceId)
        {
            using (var _context = new SamajkalyanEntities())
            {
                return _context.ProvincesDistrictSetups.Where(x => x.ProvincesId == provinceId).ToList();
            }
        }
        public static List<provincesVDCDetail> GetVdcListByDistrictId(int districtId)
        {
            using (var _context = new SamajkalyanEntities())
            {
                return _context.provincesVDCDetails.Where(x => x.ProvincesDistrictId == districtId).ToList();
            }
        }
        public static string proviencceName(int id)
        {
            using (var _context = new SamajkalyanEntities())
            {
                var jpt = _context.provincesSetups.Where(x => x.provincesId == id).FirstOrDefault().provincesName;
                return jpt;
            }
        }
        public static string districtName(int id)
        {
            using (var _context = new SamajkalyanEntities())
            {
                var jpt = _context.ProvincesDistrictSetups.Where(x => x.ProvincesDistrictId == id).FirstOrDefault().DistrictName;
                return jpt;
            }
        }
        public static string localName(int id)
        {
            using (var _context = new SamajkalyanEntities())
            {
                var jpt = _context.provincesVDCDetails.Where(x => x.ProvincesVDCDetailsID == id).FirstOrDefault().VDCName;
                return jpt;
            }
        }
        public static string GetGeneralAgremenetDate(int id)
        {
            using (var _context = new SamajkalyanEntities())
            {
                DateTime? jpt = _context.GeneralAgreements.Where(x => x.GeneralAgreement_ID == id).FirstOrDefault().Ga_Date;
               string a = jpt.HasValue ? jpt.Value.ToString("yyyy-MM-dd") : "[N/A]";
                return a;
            }
        }
        public static int GetGeneralAgremenetPaCount(int id,int? pid)
        {
            using (var _context = new SamajkalyanEntities())
            {
                int jpt = _context.ProjectAgreements.Where(x => x.GeneralAgreement_ID == id && x.ProjectAgreement_ID!=pid).Count();
                //int jpt2 = _context.ProjectAgreements.Where(x => x.ProjectAgreement_ID == pid).Count();
               // int dif = jpt - jpt2;
                return jpt;
            }
        }
        public static IEnumerable<SelectListItem> GetPAbyGA(int? id)
        {
            using (var _ct = new SamajkalyanEntities())
            {
                if (id == null)
                {
                    return new SelectList(_ct.ProjectAgreements.Where(x=>x.DeletedDate==null).ToList(), "ProjectAgreement_ID", "Name_Of_Project_Nepali");

                }
                else
                {
                    return new SelectList(_ct.ProjectAgreements.Where(x => x.GeneralAgreement_ID == id && x.DeletedDate==null ).ToList(), "ProjectAgreement_ID", "Name_Of_Project_Nepali");

                }
            }

        }
        public static IEnumerable<SelectListItem> Getpalist(int? id )
        {
            using (var _ct = new SamajkalyanEntities())
            {
                if (id==null)
                {
                    return new SelectList(_ct.ProjectAgreements.Where(x => x.DeletedDate == null).ToList(), "ProjectAgreement_ID", "Name_Of_Project_Nepali");
                    
                }
                else
                {
                    return new SelectList(_ct.ProjectAgreements.Where(x => x.DeletedDate == null && x.GeneralAgreement_ID==id).ToList(), "ProjectAgreement_ID", "Name_Of_Project_Nepali");

                }
            }

        }
        public static IEnumerable<SelectListItem> GetWorkPermitTypelist()
        {
            using (var _ct = new SamajkalyanEntities())
            {
                return new SelectList(_ct.WorKPermitTypes.Where(x => x.DeletedDate == null).ToList(), "WorkPermitTypeId", "Name");
            }

        }
    }
}