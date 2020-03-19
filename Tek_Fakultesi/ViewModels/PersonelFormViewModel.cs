using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tek_Fakultesi.Models.Entity_Fremawork;

namespace Tek_Fakultesi.ViewModels
{
    public class PersonelFormViewModel
    {
        public IEnumerable<BIRIMLER> birims { get; set; }
        public IEnumerable<ROL> Rols { get; set; }
        public DANISMAN personel { get; set; }


    }
}