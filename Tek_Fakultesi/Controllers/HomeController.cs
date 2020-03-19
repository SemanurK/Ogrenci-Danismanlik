using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tek_Fakultesi.Controllers
{
    [YetkiKontrolu]

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    
    }
}