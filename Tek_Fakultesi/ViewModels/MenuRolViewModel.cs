using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tek_Fakultesi.Models.Entity_Fremawork;

namespace Tek_Fakultesi.ViewModels
{
    public class MenuRolViewModel
    {
        public IEnumerable<MENU> menu { get; set; }
        public IEnumerable<ROL> rols { get; set; }
       // public IEnumerable<MENUROL> menurol { get; set; }
        public MENUROL menurol { get; set; }
        public ROL rol { get; set; }
    }
}