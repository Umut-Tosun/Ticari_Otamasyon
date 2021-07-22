using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        // GET: Urun
        public ActionResult Index()
        {
            var urunler = c.Uruns.ToList();
            return View(urunler);
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
    }
}