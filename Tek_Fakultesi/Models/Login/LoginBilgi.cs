using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tek_Fakultesi.Models.Login
{
    public class LoginBilgi
    {
        private int BirimId;
        private int Id,rolid;
        private string Tcno, Unvan, Ad, Soyad,sifre;
        private string resim;

        public int Id1 { get => Id; set => Id = value; }
      
        public int Rolid { get => rolid; set => rolid = value; }
        public string Tcno1 { get => Tcno; set => Tcno = value; }
        public string Unvan1 { get => Unvan; set => Unvan = value; }
        public string Ad1 { get => Ad; set => Ad = value; }
        public string Soyad1 { get => Soyad; set => Soyad = value; }
        public string Sifre { get => sifre; set => sifre = value; }
        public int BirimId1 { get => BirimId; set => BirimId = value; }
        public string Resim { get => resim; set => resim = value; }
        public bool cinsiyet { get; set; }
    }
}