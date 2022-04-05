using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entitiy; /*Yüklediğmiz modele ulaşmak için yazıyoruz*/

namespace WebApplication1.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MVCDbEntities db = new MVCDbEntities(); /*Enititi oluştururken MVCDbEntities Diye isim verdim ondan bir nesne türettim*/

        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILER.ToList();
            return View(degerler);
            return View();
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();

        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER m1)
        {
            db.TBLMUSTERILER.Add(m1);
            db.SaveChanges();
            return View();

        }
        public ActionResult Sil (int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);//id den gelicek olan degeri bul 
            return View("MusteriGetir", musteri);
        }

        public ActionResult Guncelle(TBLMUSTERILER k1)
        {
            var musteri = db.TBLMUSTERILER.Find(k1.MUSTERID);
            musteri.MUSTERIAD = k1.MUSTERIAD;
            musteri.MUSTERISOYAD = k1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}