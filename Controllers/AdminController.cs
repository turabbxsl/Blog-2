using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogsayti.Models;

namespace Blogsayti.Controllers
{
    public class AdminController : Controller
    {

        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Yazaronaylari()
        {
            var data = context.kullanicis.Where(x => x.yazar == true && x.onaylandi == false).ToList();
            return View(data);
        }

        public ActionResult Onayver(int id)
        {
            kullanici kl = context.kullanicis.FirstOrDefault(x => x.kullaniciid == id);
            kl.onaylandi = true;
            context.SaveChanges();
            return RedirectToAction("Yazaronaylari");
        }


    }
}