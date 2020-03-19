using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tek_Fakultesi.Models
{
    public class CheckModel
    {
        public int id { get; set; }
        public string menuAdi { get; set; }
        public string contName{ get; set; }
        public string acName{ get; set; }
        public string aciklama{ get; set; }
        public bool check{ get; set; }
      
    }
    public class IzinModel
    {
       public int rolid { get; set; }
        public List<CheckModel> CheckIzin { get; set; }
    }
}