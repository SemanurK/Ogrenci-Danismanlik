using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tek_Fakultesi.Models.Entity_Fremawork;

namespace Tek_Fakultesi.Controllers
{
    public class MENUController : Controller
    {
        FAKULTEEntities1 db = new FAKULTEEntities1();

        // GET: MENU
        public ActionResult Index()
        {
            var model = db.MENU.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult YeniMenu()
        {
          
            return View("YeniMenu");
        }
        [HttpPost]
        public ActionResult Kaydet(MENU menu)
        {
            if (menu.ID == 0)
            {
                db.MENU.Add(menu);
            }
            else
            {
                db.Entry(menu).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            var model = db.MENU.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("YeniMenu", model);
        }
        public ActionResult Sil(int id)
        {
            var silinecekmenu = db.MENU.Find(id);
            if (silinecekmenu == null)
            {
                return HttpNotFound();
            }
            db.MENU.Remove(silinecekmenu);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}