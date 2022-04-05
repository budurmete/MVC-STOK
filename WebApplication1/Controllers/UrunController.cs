using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entitiy; /*Yüklediğmiz modele ulaşmak için yazıyoruz*/

namespace WebApplication1.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MVCDbEntities db = new MVCDbEntities(); /*Enititi oluştururken MVCDbEntities Diye isim verdim ondan bir nesne türettim*/
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degeler = (from i in db.TBLKATEGORILER.ToList() select new SelectListItem { Text = 
                                            i.KATEGORIAD, Value = i.KATEGORIID.ToString() }).ToList();
            ViewBag.dgr = degeler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER m1)
        {
            var ktg = db.TBLKATEGORILER.Where(m=>m.KATEGORIID==m1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            m1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(m1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var Urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(Urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}