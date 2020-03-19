using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tek_Fakultesi.Functions;
using Tek_Fakultesi.Models.Entity_Fremawork;
using Tek_Fakultesi.ViewModels;

namespace Tek_Fakultesi.Controllers
{
    public class OGRENCIController : Controller
    {
        FAKULTEEntities1 db = new FAKULTEEntities1();
        // GET: OGRENCI
        Helper helper = new Helper();
        public ActionResult Index()
        {
            //bütün öğrenciler ve bilgiler
            var model = db.OGRENCİ.OrderBy(m=>m.OGR_BOLUM).ToList();
            return View(model);
        }
        public ActionResult Danisman()
        {
            //giriş yapan danışmana göre kendi danısmanlığında bulunan öğrenciler 

            var loginbilgi = helper.CookieGet();
            ViewBag.rolid = loginbilgi.Rolid;           
            var danisman_ogr = db.OGR_DANISMAN.Where(m => m.DANISMAN_ID == loginbilgi.Rolid).Select(m=>m.OGRENCİ).ToList();
            return View("Index",danisman_ogr);
        }
        public ActionResult Danisman_Form()
        {
            var model = new OgrenciViewModel()
            {
                Danismans = db.DANISMAN.ToList(),
                birims = db.BIRIMLER.ToList()

            };
          
            return View("Danisman_Form",model);
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            var model = new OgrenciViewModel()
            {
                Danismans = db.DANISMAN.ToList(),
                birims = db.BIRIMLER.ToList()

            };
            return View("Yeni",model);
        }
        [HttpPost]
        public ActionResult Kaydet(OgrenciViewModel ogr)
        {
            OGRENCİ ogr1 = ogr.ogrenci;
           
            if (ogr1.ID == 0)
            {
                db.OGRENCİ.Add(ogr1);
            }           
            else
            {
                db.Entry(ogr1).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            var varmi = db.OGRENCİ.Where(m => m.KUL_AD == ogr1.KUL_AD).SingleOrDefault();
            OGR_DANISMAN ogr_dan=new OGR_DANISMAN();
           if(varmi!=null)
            {
                ogr_dan.DANISMAN_ID = ogr1.OGR_DAN;
                ogr_dan.OGR_ID = varmi.ID;
                db.OGR_DANISMAN.Add(ogr_dan);
            }
           else
            {
                ViewBag.Mesaj = " Öğrenci Bulunamadı !";
            }
            db.SaveChanges();

            return View("Index",ogr1);
        }
        public ActionResult Kaydet1(OgrenciViewModel ogr)
        {
            OGRENCİ ogr1 = ogr.ogrenci;
            var x = db.OGRENCİ.Where(m => m.KUL_AD == ogr1.KUL_AD).FirstOrDefault();
            if (x != null)
            {
                ogr1.ID = x.ID;
            }
            else
            {
                ogr1.ID = 0;
            }

                if (ogr1.ID == 0)
                {
                    db.OGRENCİ.Add(ogr1);
                }
                else
                {
                    db.Entry(ogr1).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                var varmi = db.OGRENCİ.Where(m => m.KUL_AD == ogr1.KUL_AD).FirstOrDefault();
                var dan_kontrol = db.OGR_DANISMAN.Where(m => m.DANISMAN_ID == ogr1.OGR_DAN && m.OGR_ID == varmi.ID).Any();
                OGR_DANISMAN ogr_dan = new OGR_DANISMAN();
                if (varmi != null)
                {
                    if (dan_kontrol == null)
                    {
                        ogr_dan.DANISMAN_ID = ogr1.OGR_DAN;
                        ogr_dan.OGR_ID = varmi.ID;
                        db.OGR_DANISMAN.Add(ogr_dan);
                    }
                }
                else
                {
                    ViewBag.Mesaj = " Öğrenci Bulunamadı !";
                }
                db.SaveChanges();
         

            return RedirectToAction("Index",ogr1);
        }
        public ActionResult Goruntule(int id)
        {
            var model = new OgrenciViewModel()
            {
               
                birims = db.BIRIMLER.ToList(),
                ogrenci = db.OGRENCİ.Find(id),
                Danismans=db.DANISMAN.ToList()
            };
            return View("Danisman_Form", model);
        }

    }
}