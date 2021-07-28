using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.Sınıflar;
using QRCoder;

namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string P)
        {
            var k = from x in c.kargoDetays select x;
            if (!string.IsNullOrEmpty(P))
            {
                k = k.Where(m => m.TakipKodu.Contains(P));
            }
            
            return View(k.ToList());
        }
        [HttpGet]
        public ActionResult KargoEkle()
        {
            Random rnd = new Random();

            string[] takipkodu = { "A", "B", "C", "D" ,"E","F","Z","M","N","L","T","O","U","V","J","S","Q","R"};
            int k1, k2, k3;

            k1 = rnd.Next(0, takipkodu.Length);
            k2 = rnd.Next(0, takipkodu.Length);
            k3 = rnd.Next(0, takipkodu.Length);

            int s1, s2, s3;

            s1 = rnd.Next(100,1000);
            s2 = rnd.Next(10,99);
            s3 = rnd.Next(10,99);

            string kod = s1.ToString() + takipkodu[k1] + s2.ToString() + takipkodu[k2] + s3 + takipkodu[k3].ToString();
            ViewBag.takipno = kod;


            return View();
        }
        [HttpPost]
        public ActionResult KargoEkle(KargoDetay p)
        {
            c.kargoDetays.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoDetay(string id)
        {
            var degerler = c.kargoTakips.Where(x => x.TakipKodu == id).ToList();
          
            return View(degerler);
        }
        public ActionResult Index2(int id)
        {
            var deger2 = c.kargoDetays.Find(id);
            ViewBag.dgr2 = deger2.TakipKodu;
            return View();
        }
        [HttpPost]
        public ActionResult Index2(string kod)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator koduret = new QRCodeGenerator();
                QRCodeGenerator.QRCode karkod = koduret.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap resim = karkod.GetGraphic(10))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.karekodimg = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }

            }
            return View();
        }

    }
}