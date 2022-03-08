using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje.Models;

namespace proje.Controllers
{
    public class UyeController : Controller
    {
        Kutuphane1Entities1 entities = new Kutuphane1Entities1();
       
       
        public ActionResult Index()
        {


            return View(from uyeler in entities.uyeler.Take(20) select uyeler);
        }
        [HttpPost]
        public ActionResult Create(uyeler model)
        {
            entities.uyeler.Add(model);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {

            List<SelectListItem> kategoriler = new List<SelectListItem>();
            foreach (var item in entities.uyeTip.ToList())
            {
                kategoriler.Add(new SelectListItem { Text = item.uyeTipAdi, Value = item.uyeTip_id.ToString() });

            }
            ViewBag.uyeTip_id = kategoriler;
            return View();

        }
        public ActionResult Edit(int id)
        {


            List<SelectListItem> kategoriler = new List<SelectListItem>();
            foreach (var item in entities.uyeTip.ToList())
            {
                kategoriler.Add(new SelectListItem { Text = item.uyeTipAdi, Value = item.uyeTip_id.ToString() });

            }
            ViewBag.uyeTip_id = kategoriler;

            uyeler model = entities.uyeler.Find(id);
            return View(model);
           
            
        }
        [HttpPost]
        public ActionResult Edit(uyeler model)
        {
            if(ModelState.IsValid)
            {
                entities.Entry(model).State = EntityState.Modified;
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
 

        public ActionResult Delete(int id)
        {
            //var silinecekuye = entities.uyeler.Find(id);
            //entities.uyeler.Remove(silinecekuye);
            //entities.SaveChanges();
            //return RedirectToAction("Index");
            uyeler model = entities.uyeler.Find(id);
            return View(model);

        }


        [HttpPost]
        public ActionResult Delete(int id,uyeler uye)
        {
            uyeler model = new uyeler();
            if (ModelState.IsValid)
            {
                model = entities.uyeler.Find(id);
                entities.uyeler.Remove(model);
                
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }
        public ActionResult Details(int id)
        {
            uyeler model = entities.uyeler.Find(id);
            return View(model);
        }
    }
}