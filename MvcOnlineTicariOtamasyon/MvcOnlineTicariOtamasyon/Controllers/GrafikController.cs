using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context C = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);

            grafikciz.AddTitle("Kategori - Ürün Stok sayısı").AddLegend("Stok").AddSeries("Değerler",

                xValue: new[] { "Mobilya", "Beyaz Eşya", "Bilgisayar" },

                yValues: new[] { 80, 60, 90 }).Write();



            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var sonuclar = C.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xValue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(x => yValue.Add(x.Stok));

            var grafikciz = new Chart(1400, 1400).
                AddTitle("Stoklar").
                AddSeries(chartType: "Pie", name: "Stok", xValue: xValue, yValues: yValue);

            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");

        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
        public ActionResult VisualizerUrunResult()
        {
            return Json(Urunlistesi(), JsonRequestBehavior.AllowGet);
        }
        public List<sinif1> Urunlistesi()
        {
            List<sinif1> snf = new List<sinif1>();
            snf.Add(new sinif1()
            {
                urunad="Bilgisayar",
                stok=20
            });
            snf.Add(new sinif1()
            {
                urunad = "Televizyon",
                stok = 40
            });
            snf.Add(new sinif1()
            {
                urunad = "Ütü",
                stok = 12
            });
            return snf;
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(Urunlistesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<sinif2> Urunlistesi2()
        {
            List<sinif2> snf = new List<sinif2>();
            using (var c =new Context())
            {
                snf = c.Uruns.Select(x => new sinif2
                {
                    urn = x.UrunAd,
                    stk=x.Stok
                }).ToList();
            }
            return snf;
        }
    }
}