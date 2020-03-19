using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tek_Fakultesi.Models;
using Tek_Fakultesi.Models.Entity_Fremawork;
using Tek_Fakultesi.ViewModels;

namespace Tek_Fakultesi.Controllers
{
    public class ROLController : Controller
    {
        FAKULTEEntities1 db = new FAKULTEEntities1();
        // GET: ROL
        public ActionResult Index()
        {
            var model = db.ROL.ToList();

            return View(model);
        }
        public ActionResult RolKontrol(int id)
        {
            IzinModel ızinModel = new IzinModel();
            ızinModel.rolid = id;
            var menulist = db.MENU.ToList();
            List<CheckModel> checkModels = new List<CheckModel>();
            foreach(var a in menulist)
            {
                var izin = db.MENUROL.Where(x => x.ROLID == id && x.MENUID == a.ID).Any();
                checkModels.Add(new CheckModel { id = a.ID, menuAdi = a.MENU_ADI, contName = a.CONTOLLERNAME, acName = a.ACTIONNAME, aciklama = a.ACIKLAMA, check = izin });

            }
            ızinModel.CheckIzin = checkModels;
         
            return View(ızinModel);
        }

        //public ActionResult Guncelle(int id)
        //{
        //    var model = new MenuRolViewModel()
        //    {
        //        rol = db.ROL.Find(id),
        //        menu = db.MENU.ToList(),
        //        rols = db.ROL.ToList()

        //    };

        //    return View("RolKontrol", model);
        //}
        public ActionResult Guncelle(int id)
        {

            List<int> deneme = new List<int>();
            var model = db.MENUROL.ToList();
            foreach(var item in model)
                if(item.ROLID==id)
                {
                    deneme.Add((int)item.MENUID);
                }
            else
                {

                }

            return View();
        }
        [HttpGet]
        public ActionResult YeniRol()
        {
            return View("YeniRol");
        }
        [HttpPost]
        public ActionResult Kaydet(ROL rol)
        {
            if (rol.ID == 0)
            {
                db.ROL.Add(rol);
            }
            else
            {
                var guncellerol = db.ROL.Find(rol.ID);
                if (guncellerol == null)
                {
                    return HttpNotFound();
                }
                guncellerol.ROLADI = rol.ROLADI;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "ROL");
        }
        public ActionResult Guncelle1(int id)
        {
            var model = db.ROL.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("YeniRol", model);
        }
        public ActionResult Sil(int id)
        {
            var silinecekrol = db.ROL.Find(id);
            if (silinecekrol == null)
            {
                return HttpNotFound();
            }
            db.ROL.Remove(silinecekrol);
            db.SaveChanges();
            return RedirectToAction("Index", "ROL");

        }
    }
}