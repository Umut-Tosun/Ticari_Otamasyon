using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.Where(x=>x.Durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }
            ).ToList();
            ViewBag.deger1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)

            {

                var extention = Path.GetExtension(Request.Files[0].FileName);

                var randomName = string.Format($"{DateTime.Now.Ticks}{extention}");

                //var randomName = string.Format($"{Guid.NewGuid().ToString().Replace("-", "")}{extention}");

                p.PersonelGorsel = "/Images/" + randomName;

                var path = "~/Images/" + randomName;

                Request.Files[0].SaveAs(Server.MapPath(path));

            }
            p.durum = true;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.Where(x=>x.Durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }
          ).ToList();
            ViewBag.deger1 = deger1;
            var degerler = c.Personels.Find(id);
            return View("PersonelGetir", degerler);
        }

        public ActionResult PersonelSil(int id)
        {
            var deger = c.Personels.Find(id);
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

        public ActionResult PersonelGuncelle(Personel p, HttpPostedFileBase PersonelFotograf)
        {

            if (Request.Files.Count > 0)

            {

                var extention = Path.GetExtension(Request.Files[0].FileName);

                var randomName = string.Format($"{DateTime.Now.Ticks}{extention}");

                //var randomName = string.Format($"{Guid.NewGuid().ToString().Replace("-", "")}{extention}");

                p.PersonelGorsel = "/Images/" + randomName;

                var path = "~/Images/" + randomName;

                Request.Files[0].SaveAs(Server.MapPath(path));

            }
            var deger = c.Personels.Find(p.PersonelID);
            deger.PersonelAd = p.PersonelAd;
            deger.PersonelSoyad = p.PersonelSoyad;
            deger.PersonelGorsel = p.PersonelGorsel;
            deger.durum = p.durum;
            deger.Departmanid = p.Departmanid;
            if (ModelState.IsValid)

            {
                if (PersonelFotograf != null)

                {

                    string dosyaadi = Path.GetFileName(PersonelFotograf.FileName);



                    string yol = "/Image/" + dosyaadi;

                    PersonelFotograf.SaveAs(Server.MapPath(yol));

                  deger.PersonelGorsel = yol;

                }

            }
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListesi()
        {
            var deger = c.Personels.ToList();
            
            return View(deger);
        }
    }
}