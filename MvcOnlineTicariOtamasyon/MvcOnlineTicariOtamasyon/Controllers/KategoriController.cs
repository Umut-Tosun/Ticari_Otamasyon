using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;
namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa,5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori p)
        {
            c.Kategoris.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var aranan = c.Kategoris.Find(id);
            c.Kategoris.Remove(aranan);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir (int id)
        {
            var aranan = c.Kategoris.Find(id);
            return View("KategoriGetir",aranan);
        }
        public ActionResult KategoriGuncelle(Kategori p)
        {
            var ktgr = c.Kategoris.Find(p.KategoriID);
            ktgr.KategoriAd = p.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}