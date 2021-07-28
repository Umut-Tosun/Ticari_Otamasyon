using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using MvcOnlineTicariOtamasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Index(string kod)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator koduret = new QRCodeGenerator();
                QRCodeGenerator.QRCode karkod = koduret.CreateQrCode(kod,QRCodeGenerator.ECCLevel.Q);
                using (Bitmap resim = karkod.GetGraphic(10))
                {
                    resim.Save(ms,ImageFormat.Png);
                    ViewBag.karekodimg = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }

            }
            return View();
        }
    }
}