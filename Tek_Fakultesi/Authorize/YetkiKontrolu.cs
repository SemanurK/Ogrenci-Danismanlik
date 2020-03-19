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

namespace Tek_Fakultesi
{
    public class YetkiKontrolu:ActionFilterAttribute
    {
        FAKULTEEntities1 db = new FAKULTEEntities1();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string metotAdi = filterContext.ActionDescriptor.ActionName;
            var coki = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (coki != null)
            {
                JavaScriptSerializer serialize = new JavaScriptSerializer();
                FormsAuthenticationTicket bilet = FormsAuthentication.Decrypt(coki.Value);
                var loginbilgi = JsonConvert.DeserializeObject<LoginBilgi>(bilet.UserData);
                var metotYetki = db.MENUROL.Where(/*a => a.MENU.ACTIONNAME == metotAdi && */a=>a.ROLID == loginbilgi.Rolid).Any();
                if (metotYetki == false)
                {
                    filterContext.Result = new RedirectResult("/Home/Error");
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("Login/Login");
            }
        }
    }
}