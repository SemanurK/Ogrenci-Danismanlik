using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tek_Fakultesi.Models.Entity_Fremawork;

namespace Tek_Fakultesi.ViewModels
{
    public class OgrenciViewModel
    {
        public IEnumerable<BIRIMLER> birims { get; set; }
        public IEnumerable<DANISMAN> Danismans { get; set; }
        public OGRENCİ ogrenci { get; set; }
    }
}