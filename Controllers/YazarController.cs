using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogsayti.Models;

namespace Blogsayti.Controllers
{
    public class YazarController : Controller
    {

        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Yazarol()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yazarol(kullanici kl,string rdman, string rdwoman)
            {
            if (!string.IsNullOrEmpty(rdman))
            {
                kl.cinsiyyet = true;
            }
            if (!string.IsNullOrEmpty(rdwoman))
            {
                kl.cinsiyyet = false;
            }

            kl.yazar = true;
            kl.onaylandi = false;
            kl.aktif = true;
            kl.kayittarixi = DateTime.Now;
            context.kullanicis.Add(kl);
            context.SaveChanges();

            Roll yazar = context.Rolls.FirstOrDefault(x => x.Rolladi == "Yazar");
            kullanicirol kr = new kullanicirol();
            kr.rolid = yazar.Rollid;
            kr.kullaniciid = kl.kullaniciid;
            context.kullanicirols.Add(kr);
            context.SaveChanges();

            return RedirectToAction("Index","Home");

        }


    }
}