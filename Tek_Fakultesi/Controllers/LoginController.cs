using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tek_Fakultesi.Models.Entity_Fremawork;
using Tek_Fakultesi.Models.Login;
using Tek_Fakultesi.ViewModels;

namespace Tek_Fakultesi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        FAKULTEEntities1 db = new FAKULTEEntities1();
        // GET: Login

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar kul)
        {
            string value = kul.ToString();
        
            var d = db.DANISMAN.FirstOrDefault(a => a.KUL_AD == kul.Kul_ad && a.SİFRE == kul.Sifre);
            var o = db.OGRENCİ.FirstOrDefault(a => a.KUL_AD == kul.Kul_ad && a.SİFRE == kul.Sifre);
            if (d != null && o == null)
            {
                try
                {
                      LoginBilgi loginBilgi = new LoginBilgi();
                      loginBilgi.Ad1 = d.AD;
                      loginBilgi.Soyad1 = d.SOYAD;
                      loginBilgi.Unvan1 = d.UNVAN;
                      loginBilgi.BirimId1 = (int)d.BIRIMID;
                      loginBilgi.Rolid = (int)d.ROLID;
                      loginBilgi.Resim = d.image;
                      loginBilgi.cinsiyet =(bool) d.cinsiyet;
                      // loginBilgi.Ad1 = per.AD;
                

                    string LogBil = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(loginBilgi);

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1,
                        d.AD,
                        DateTime.Now,
                        DateTime.Now.AddHours(2),
                        false,
                        LogBil,
                        FormsAuthentication.FormsCookiePath);
                    string encriptedTicked = FormsAuthentication.Encrypt(ticket);

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encriptedTicked);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (o != null && d == null)
            {
                try
                {
                    LoginBilgi loginBilgi = new LoginBilgi();
                    loginBilgi.Ad1 = o.OGR_AD;
                    loginBilgi.Soyad1 = o.OGR_SOYAD;
                    loginBilgi.Resim = o.image;
                    loginBilgi.BirimId1 = (int)o.OGR_BOLUM;
                    var ogr_rolid = db.ROL.FirstOrDefault(a => a.ROLADI.Equals("Öğrenci"));
                    loginBilgi.Rolid = ogr_rolid.ID;
                    loginBilgi.cinsiyet = (bool)o.Cinsiyet;

                    string LogBil = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(loginBilgi);

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1,
                        o.OGR_AD,
                        DateTime.Now,
                        DateTime.Now.AddHours(2),
                        false,
                        LogBil,
                        FormsAuthentication.FormsCookiePath);
                    string encriptedTicked = FormsAuthentication.Encrypt(ticket);

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encriptedTicked);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı adı veya şifre geçersizdir";
                return View();
            }
        }
       
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }        
    }
}