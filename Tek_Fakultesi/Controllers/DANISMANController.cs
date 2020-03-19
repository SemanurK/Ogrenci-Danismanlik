using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Tek_Fakultesi.Models.Entity_Fremawork;
using Tek_Fakultesi.Models.Login;
using Tek_Fakultesi.ViewModels;

namespace Tek_Fakultesi.Controllers
{
    [YetkiKontrolu]

    public class DANISMANController : Controller
    {
        FAKULTEEntities1 db = new FAKULTEEntities1();
        // GET: PERSONEL
        public ActionResult Index()
        { 
            var model = db.DANISMAN.ToList();
            return View(model);
        }   
      
        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel()
            {
                Rols = db.ROL.ToList(),
                birims=db.BIRIMLER.ToList()
            };           
            return View(model);
        }
        public ActionResult Kaydet(DANISMAN personel)
        {
            if(personel.ID==0)
            {
                db.DANISMAN.Add(personel);
            }
            else//güncelleme
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                Rols = db.ROL.ToList(),
                birims = db.BIRIMLER.ToList(),
                personel = db.DANISMAN.Find(id)
            };
            return View("Yeni", model);
        }
        public ActionResult Sil(int id)
        {
            var silinecek = db.DANISMAN.Find(id);
            if(silinecek==null)
            {
                return HttpNotFound();
            }
            db.DANISMAN.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
      
    }
}