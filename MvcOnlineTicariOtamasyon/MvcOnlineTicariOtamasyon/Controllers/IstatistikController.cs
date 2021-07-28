using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var toplamcari = c.Carilers.Count().ToString();
            var toplamurun = c.Uruns.Count().ToString();
            var toplampersonel = c.Uruns.Where(x => x.durum == true).Count().ToString();
            var toplamkategori = c.Kategoris.Count().ToString();

            var toplamstok = c.Uruns.Sum(x => x.Stok).ToString();
            var toplammarka = c.Uruns.Select(x => x.Marka).Distinct().Count();
            var kritikseviye = c.Uruns.Count(x => x.Stok < 20).ToString();
            var enpahaliurun = c.Uruns.Select(x => x.SatisFiyat).Max();

            var enucuzurun = c.Uruns.Select(x => x.SatisFiyat).Min();
            var enfazlaolanmarka = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            var buzdolabisayisi = c.Uruns.Where(x => x.UrunAd == "Buzdolabı").Count().ToString();
            var laptopsayisi = c.Uruns.Where(x => x.UrunAd == "Laptop").Count().ToString();

            var encokstanurun = from SatisHareket in c.SatisHarekets

                                             join Urun in c.Uruns on SatisHareket.Urunid equals Urun.UrunID

                                             group SatisHareket by SatisHareket.Urun.UrunAd into grup

                                             select new

                                             {

                                                 UrunAd = grup.Key,

                                                 Adet = grup.Sum(x => x.Adet)

                                             };

           
            var kasadakitutar = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            DateTime bugun = DateTime.Today;
            var bugunkisatis = c.SatisHarekets.Count(x => x.Tarih ==bugun).ToString();

            ViewBag.d1 = toplamcari;
            ViewBag.d2 = toplamurun;
            ViewBag.d3 = toplampersonel;
            ViewBag.d4 = toplamkategori;

            ViewBag.d5 = toplamstok;
            ViewBag.d6 = toplammarka;
            ViewBag.d7 = kritikseviye;
            ViewBag.d8 = enpahaliurun;

            ViewBag.d9 = enucuzurun;
            ViewBag.d10 = enfazlaolanmarka;
            ViewBag.d11 = buzdolabisayisi;
            ViewBag.d12 = laptopsayisi;

            ViewBag.d13 = encokstanurun.OrderByDescending(x => x.Adet).ToList().FirstOrDefault().UrunAd;
            ViewBag.d14 = kasadakitutar;
            ViewBag.d15 = bugunkisatis;
            if (Convert.ToInt32(bugunkisatis) != 0)
            {
                var deger16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => y.ToplamTutar).ToString();
                ViewBag.d16 = deger16;
            }
            else { ViewBag.d16 = bugunkisatis; }
           

            return View();
        }
        public ActionResult BasitTablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new SınıfGrup
                        {
                            sehir = g.Key,
                            sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new SınıfGrup2
                         {
                             Departman = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu = c.Carilers.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu3 = from x in c.Uruns
                         group x by x.Marka into g
                         select new Class2
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu3.ToList());
        }
    }
}