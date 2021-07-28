using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.Sınıflar;
using PagedList;

namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        // GET: Urun
        public ActionResult Index(int? sayfa, string p)
        {
            var degerler = c.Uruns.Where(c => c.UrunAd.StartsWith(p) || p == null).ToList().ToPagedList(sayfa ?? 1, 4);

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }
            ).ToList();
            ViewBag.deger1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            p.durum = true;
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            if (deger.durum == true)
            {
                deger.durum = false;
            }
            else
            {
                deger.durum = true;
            }
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }
           ).ToList();
            ViewBag.deger1 = deger1;
            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir",urundeger);
        }
        [HttpGet]
        public ActionResult UrunGuncelle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urun p)
        {
            var deger = c.Uruns.Find(p.UrunID);
            deger.AlisFiyat = p.SatisFiyat;
            deger.SatisFiyat = p.SatisFiyat;
            deger.Marka = p.Marka;
            deger.Stok = p.Stok;
            deger.UrunGorsel = p.UrunGorsel;
            deger.durum = p.durum;
            deger.Kategoriid = p.Kategoriid;
            deger.UrunAd = p.UrunAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Personels.Where(x => x.Departman.DepartmanAd == "Satış Temsilcisi").ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()

                                           }).ToList();
            ViewBag.deger1 = deger1;
            var deger2 = c.Uruns.Find(id);
            ViewBag.deger2 = deger2.UrunID;
            ViewBag.deger3 = deger2.SatisFiyat;
            return View();
        }      
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}