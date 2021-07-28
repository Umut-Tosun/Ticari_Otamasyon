using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MvcOnlineTicariOtamasyon.Models.Sınıflar
{
    public class Context : DbContext
    {
        public DbSet<Admin>Admins  {get;set;}
        public DbSet<Cariler>Carilers  {get;set;}
        public DbSet<Departman>Departmans  {get;set;}
        public DbSet<FaturaKalem>FaturaKalems  {get;set;}
        public DbSet<Faturalar>Faturalars  {get;set;}
        public DbSet<Gider>Giders  {get;set;}
        public DbSet<Kategori> Kategoris {get;set;}
        public DbSet<Personel>Personels  {get;set;}
        public DbSet<SatisHareket>SatisHarekets  {get;set;}
        public DbSet<Urun>Uruns  {get;set;}
        public DbSet<Detay>Detays { get; set; }
        public DbSet<Yapilicaklar>yapilicaklars { get; set; }
        public DbSet<KargoDetay>kargoDetays { get; set; }
        public DbSet<KargoTakip>kargoTakips { get; set; }
    }
}