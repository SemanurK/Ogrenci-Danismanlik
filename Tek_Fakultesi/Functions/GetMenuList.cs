using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tek_Fakultesi.Models.Entity_Fremawork;

namespace Tek_Fakultesi.Functions
{
    public class GetMenuList
    {
        FAKULTEEntities1 db = new FAKULTEEntities1();

        //layouttaki sol menüyü getiren fonksiyon
        public List<MENU> GetMenulist(decimal? rolid)
        {
            var menulist = db.MENUROL.Where(t => t.ROLID == rolid && t.MENU.GORUNURLUK == 0).Select(t => t.MENU).OrderBy(t => t.SIRANO).ToList();
            
            return menulist;
        }

    }
}