using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tek_Fakultesi.Models.Entity_Fremawork;

namespace Tek_Fakultesi.Controllers
{


    public class BIRIMController : Controller
    {
        FAKULTEEntities1 db = new FAKULTEEntities1();
        // GET: BIRIM
        public ActionResult Index()
        {
            var model = db.BIRIMLER.ToList();
            
            return View(model);
        }
        [HttpGet]
        public ActionResult YeniBirim( )
        {          
            return View("BirimForm");
        }
        [HttpPost]
        public ActionResult Kaydet(BIRIMLER birim)
        {
            if(birim.BIRIMID==0)
            {
                db.BIRIMLER.Add(birim);
            }
            else
            {
                var guncellebirim = db.BIRIMLER.Find(birim.BIRIMID);
                if(guncellebirim==null)
                {
                    return HttpNotFound();
                }
                guncellebirim.BIRIMAD = birim.BIRIMAD;
            }            
            db.SaveChanges();
            return RedirectToAction("Index","BIRIM");
            
             
        }
        public ActionResult Guncelle(int id)
        {
            var model = db.BIRIMLER.Find(id);
            if(model==null)
            {
                return HttpNotFound();
            }
             return View("BirimForm",model);
        }
        public ActionResult Sil(int id)
        {
            var silinecekbirim = db.BIRIMLER.Find(id);
            if(silinecekbirim==null)
            {
                return HttpNotFound();
            }
            db.BIRIMLER.Remove(silinecekbirim);
            db.SaveChanges();
            return RedirectToAction("Index", "BIRIM");
            
        }
    }
}