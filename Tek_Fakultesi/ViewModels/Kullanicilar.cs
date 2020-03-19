using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tek_Fakultesi.Models.Entity_Fremawork;

namespace Tek_Fakultesi.ViewModels
{
    public class Kullanicilar
    {
       
       public IEnumerable<DANISMAN> danismanlar { get; set; }
        public IEnumerable<OGRENCİ> ogrenciler { get; set; }
        public string Kul_ad { get; set; }
        public string Sifre { get; set; }
    }
}