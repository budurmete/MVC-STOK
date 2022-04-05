using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entitiy; /*Yüklediğmiz modele ulaşmak için yazıyoruz*/

namespace WebApplication1.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MVCDbEntities db = new MVCDbEntities(); /*Enititi oluştururken MVCDbEntities Diye isim verdim ondan bir nesne türettim*/

        public ActionResult Index()
        {
            var degeler = db.TBLKATEGORILER.ToList();
            return View(degeler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            //eğer ben herhangi bir İşlem yapmazsam Döndür
            return View();
        }
            [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER m1)
        {
            if (!ModelState.IsValid)//doğrulama İşlemi Yapılmadıysa
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORILER.Add(m1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil (int id )
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir (int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);//id den gelicek olan degeri bul 
            return View("KategoriGetir",ktgr);
        }

        public ActionResult Guncelle(TBLKATEGORILER k1)
        {
            var ktgr = db.TBLKATEGORILER.Find(k1);
            ktgr.KATEGORIAD = k1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}