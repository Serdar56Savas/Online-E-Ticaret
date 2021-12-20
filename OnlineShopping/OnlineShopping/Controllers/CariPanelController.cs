using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping.Models.Sınıflar;

namespace OnlineShopping.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["cariMail"];
            var degerler = c.Carilers.FirstOrDefault(x => x.cariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["cariMail"];
            var id = c.Carilers.Where(x => x.cariMail == mail.ToString()).Select(y => y.cariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.cariid == id).ToList();
            return View(degerler);
        }
    }
}