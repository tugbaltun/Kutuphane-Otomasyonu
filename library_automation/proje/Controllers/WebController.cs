using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje.ServiceReference1;
namespace proje.Controllers
{
    public class WebController :Controller
    {
        public ActionResult Tarama()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Tarama(String ad)
        {
           
            ServiceReference1.WebService1SoapClient servis = new ServiceReference1.WebService1SoapClient();
            var sonuc = servis.Getmember(ad);
            return View(sonuc);
            
        }
    }
}