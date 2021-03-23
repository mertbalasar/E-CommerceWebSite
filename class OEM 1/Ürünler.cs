using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace class_OEM_1
{
    public class Ürünler
    {
        public int ID { get; set; }
        public int KategoriID { get; set; }
        public string Marka { get; set; }
        public string Özellikler { get; set; }
        public byte[] Fotoğraf { get; set; }
        public int Fiyat { get; set; }
    }
}