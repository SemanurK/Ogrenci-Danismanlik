using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using Tek_Fakultesi.Models.Entity_Fremawork;
using Tek_Fakultesi.Models.Login;

namespace Tek_Fakultesi.Functions
{
    public class Helper
    {
        FAKULTEEntities1 db = new FAKULTEEntities1();
        public LoginBilgi CookieGet()
        {
            var coki = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var loginbilgi = new LoginBilgi();
            if (coki != null)
            {
                JavaScriptSerializer serialize = new JavaScriptSerializer();
                FormsAuthenticationTicket bilet = FormsAuthentication.Decrypt(coki.Value);
                loginbilgi = JsonConvert.DeserializeObject<LoginBilgi>(bilet.UserData);
                return loginbilgi;
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Account/Index");
            }
            return loginbilgi;

        }
    }
}