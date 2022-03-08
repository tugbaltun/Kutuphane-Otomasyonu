using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proje.Models;
using System.Data.Entity;

namespace proje.Controllers
{
    public class EmanetController :Controller
    {
        Kutuphane1Entities1 entities = new Kutuphane1Entities1();
        public ActionResult Index()
        {
            return View(from kitaplar in entities.kitaplar select kitaplar );
        }
        public ActionResult Listele()
        {
            return View(from emanet in entities.emanet select emanet);
        }
        public ActionResult Create(int? id)
        {

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            
            //if (kitap == null)
            //{
            //    return HttpNotFound();
            //}

           // DateTime date = DateTime.Now;
            ViewBag.emanetTarihi = DateTime.Now.ToShortDateString();
            //var model = new emanet { emanetTarihi = DateTime.Now /*teslimTarihi=date.AddDays(10)*/};
            //ViewBag.uye_id = new SelectList(entities.uyeler, "uye-id", "uyeAd");
            List<SelectListItem> kategoriler = new List<SelectListItem>();
            foreach (var item in entities.uyeler.ToList())
            {
                kategoriler.Add(new SelectListItem { Text = item.uyeAd, Value = item.uye_id.ToString() });

            }

            ViewBag.uye_id = kategoriler;
            var kitap = entities.kitaplar.Find(id);
            ViewBag.kitap_id = kitap.kitap_id.ToString();
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "kitap_id,uye_id,emanetTarihi,teslimTarihi")]*/ emanet model)
        {

            entities.emanet.Add(model);
            entities.SaveChanges();
            return RedirectToAction("Index","Emanet");



        }

        public ActionResult Edit(int id,emanet emanet)
        {
            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            emanet model = entities.emanet
                .Include(b => b.kitaplar)
                .Include(c => c.uyeler)
                .Where(b => b.kitap_id == id && b.teslimTarihi == null)
                .FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // POST: BorrowHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( emanet model)
        {
            if (ModelState.IsValid)
            {
                var borrowHistoryItem = entities.emanet.Find(model.emanet_id);
                if (borrowHistoryItem == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                if (borrowHistoryItem.uyeler.uyeTip_id == 1)
                {
                    if (DateTime.Now > borrowHistoryItem.emanetTarihi.AddDays(10))
                    {
                      var cezagunu =  DateTime.Now - borrowHistoryItem.emanetTarihi.AddDays(10);
                        borrowHistoryItem.ceza = cezagunu.Days * 0.10;
                    }
                }
                if (borrowHistoryItem.uyeler.uyeTip_id == 2)
                {
                    if (DateTime.Now > borrowHistoryItem.emanetTarihi.AddDays(20))
                    {
                        var cezagunu = DateTime.Now - borrowHistoryItem.emanetTarihi.AddDays(20);
                        borrowHistoryItem.ceza = cezagunu.Days * 0.20;
                    }
                }
                borrowHistoryItem.teslimTarihi = DateTime.Now;
                entities.SaveChanges();
                return RedirectToAction("Index", "Emanet");
            }
            return View(model);
        }





    }
}