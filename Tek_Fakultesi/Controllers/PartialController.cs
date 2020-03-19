using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tek_Fakultesi.Functions;

namespace Tek_Fakultesi.Controllers
{
    public class PartialController : Controller
    {
        Helper helper = new Helper();
        // GET: Partial
        public ActionResult DynamicMenu()
        {
            var loginbilgi = helper.CookieGet();
            ViewBag.rolid = loginbilgi.Rolid;
            ViewBag.resim = loginbilgi.Resim;
            ViewBag.cinsiyet = loginbilgi.cinsiyet;
            ViewBag.Adsoyad = loginbilgi.Ad1 +" "+ loginbilgi.Soyad1;
            return View();
        }
        public ActionResult DynamicTopBar()
        {
            var loginbilgi = helper.CookieGet();
            ViewBag.rolid = loginbilgi.Rolid;
            ViewBag.resim = loginbilgi.Resim;
            ViewBag.cinsiyet = loginbilgi.cinsiyet;
            ViewBag.Adsoyad = loginbilgi.Ad1 +" "+ loginbilgi.Soyad1;
            return View();
        }
    }
}