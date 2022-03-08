using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje.Models;

namespace proje.Controllers
{
    public class KitapController : Controller
    {
        Kutuphane1Entities1 entities = new Kutuphane1Entities1();

        [HttpPost]
        public JsonResult ListeleJson()
        {
            return Json(from kitaplar in entities.kitaplar select kitaplar);
        }
        public ActionResult Index(string kitapisim)
        {
            
            return View(from kitaplar in entities.kitaplar.Take(20) select kitaplar);
        }
        
        [HttpPost]
        public ActionResult Create(kitaplar model)
        {
        
            entities.kitaplar.Add(model);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {

            List<SelectListItem> yayintipi = new List<SelectListItem>();
            foreach (var item in entities.yayinTipi.ToList())
            {
                yayintipi.Add(new SelectListItem { Text = item.yayinTipiAdi, Value = item.yayinTipi_id.ToString() });

            }
            ViewBag.yayinTipi_id = yayintipi;

            List<SelectListItem> kategoriler = new List<SelectListItem>();
            foreach (var item in entities.kitapKategori.ToList())
            {
                kategoriler.Add(new SelectListItem { Text = item.kategoriAdi, Value = item.kategori_id.ToString() });

            }
            ViewBag.kategori_id = kategoriler;

            List<SelectListItem> yayinevi = new List<SelectListItem>();
            foreach (var item in entities.yayinEvi.ToList())
            {
               yayinevi.Add(new SelectListItem { Text = item.yayinEviAdi, Value = item.yayinEvi_id.ToString() });

            }
            ViewBag.yayinEvi_id = yayinevi;

            List<SelectListItem> raf = new List<SelectListItem>();
            foreach (var item in entities.raf.ToList())
            {
                raf.Add(new SelectListItem { Text = item.rafNo, Value = item.raf_id.ToString() });

            }
            ViewBag.raf_id = raf;
            List<SelectListItem> ust = new List<SelectListItem>();
            foreach (var item in entities.ustBaslik.ToList())
            {
                ust.Add(new SelectListItem { Text = item.ustAd, Value = item.ust_id.ToString() });

            }
            ViewBag.ust_id = ust;
            return View();

        }
        
        [HttpPost]
        public ActionResult Edit(kitaplar model)
        {
            if (ModelState.IsValid)
            {
                entities.Entry(model).State = EntityState.Modified;
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {


            List<SelectListItem> yayintipi = new List<SelectListItem>();
            foreach (var item in entities.yayinTipi.ToList())
            {
                yayintipi.Add(new SelectListItem { Text = item.yayinTipiAdi, Value = item.yayinTipi_id.ToString() });

            }
            ViewBag.yayinTipi_id = yayintipi;

            List<SelectListItem> kategoriler = new List<SelectListItem>();
            foreach (var item in entities.kitapKategori.ToList())
            {
                kategoriler.Add(new SelectListItem { Text = item.kategoriAdi, Value = item.kategori_id.ToString() });

            }
            ViewBag.kategori_id = kategoriler;

            List<SelectListItem> yayinevi = new List<SelectListItem>();
            foreach (var item in entities.yayinEvi.ToList())
            {
                yayinevi.Add(new SelectListItem { Text = item.yayinEviAdi, Value = item.yayinEvi_id.ToString() });

            }
            ViewBag.yayinEvi_id = yayinevi;

            List<SelectListItem> raf = new List<SelectListItem>();
            foreach (var item in entities.raf.ToList())
            {
                raf.Add(new SelectListItem { Text = item.rafNo, Value = item.raf_id.ToString() });

            }
            ViewBag.raf_id = raf;

            List<SelectListItem> ust = new List<SelectListItem>();
            foreach (var item in entities.ustBaslik.ToList())
            {
                ust.Add(new SelectListItem { Text = item.ustAd, Value = item.ust_id.ToString() });

            }
            ViewBag.ust_id = ust;

            kitaplar model = entities.kitaplar.Find(id);
            return View(model);


        }
        public ActionResult Delete(int id)
        {
       
            kitaplar model = entities.kitaplar.Find(id);
            return View(model);

        }

        [HttpPost]
        public ActionResult Delete(int id,kitaplar kitap)
        {
            kitaplar model = new kitaplar();
            if (ModelState.IsValid)
            {
                model = entities.kitaplar.Find(id);
                entities.kitaplar.Remove(model);

                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }
        public ActionResult Details(int id)
        {
            kitaplar model = entities.kitaplar.Find(id);
            return View(model);
        }
    }
}