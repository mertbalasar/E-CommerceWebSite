using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace class_OEM_1
{
    public class YönetimDb : DbContext
    {
        public DbSet<Kategoriler> Kategoriler { get; set; }
        public DbSet<Ürünler> Ürünler { get; set; }
        public DbSet<Sepet> Sepet { get; set; }
    }
}