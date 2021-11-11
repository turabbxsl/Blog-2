using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogsayti.AppClasses;
using Blogsayti.Models;

namespace Blogsayti.Controllers
{
    [Authorize]
    public class MeqaleController : Controller
    {
        Context context = new Context();
        // GET: Meqale

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Detay(int id)
        {
            var data = context.meqales.FirstOrDefault(x => x.meqaleid == id);
            return View(data);
        }

        //[Authorize(Roles = "Admin")]
        //public ActionResult Meqaleekle()
        //{
        //    //string str = Session["istifadeci"].ToString();
        //    //var data = context.kullanicis.Where(x => x.kullaniciadi == str);
        //    //if (data != null)
        //    //{
        //    //    return View();
        //    //}
        //    //return RedirectToAction("Index", "Home");
        //    return View();
        //}

        [AllowAnonymous]
        public string Begen(int id)
        {
            meqale mql = context.meqales.FirstOrDefault(x => x.meqaleid == id);
            mql.begenme++;
            context.SaveChanges();
            return mql.begenme.ToString();
        }

        [AllowAnonymous]
        public string Begenme(int id)
        {
            meqale mql = context.meqales.FirstOrDefault(x => x.meqaleid == id);
            mql.begenme--;
            context.SaveChanges();
            return mql.begenme.ToString();
        }


        public ActionResult Ekle()
        {
            ViewBag.Kategoriyalar = context.kategoriyas.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(meqale mql, HttpPostedFileBase resm)
        {
            Image img = Image.FromStream(resm.InputStream);
            Bitmap kicikresm = new Bitmap(img, Settings.Resmkicikboyut);
            Bitmap ortaresm = new Bitmap(img, Settings.Resmortaboyut);
            Bitmap boyukresm = new Bitmap(img, Settings.Resmboyukboyut);

            kicikresm.Save(Server.MapPath("/Content/s/MakaleResim/KucukBoyut/" + resm.FileName));
            ortaresm.Save(Server.MapPath("/Content/s/MakaleResim/OrtaBoyut/" + resm.FileName));
            boyukresm.Save(Server.MapPath("/Content/s/MakaleResim/BuyukBoyut/" + resm.FileName));

            resm rsm = new resm();
            rsm.boyukolculu = "/Content/s/MakaleResim/BuyukBoyut/" + resm.FileName;
            rsm.ortaolculu = "/Content/s/MakaleResim/OrtaBoyut/" + resm.FileName;
            rsm.kicikolculu = "/Content/s/MakaleResim/KucukBoyut/" + resm.FileName;

            context.resms.Add(rsm);
            context.SaveChanges();

            mql.resmid = rsm.resimid;
            mql.eklenmetarixi = DateTime.Now;
            mql.goruntulenmesayi = 0;
            mql.begenme = 0;

            int yazid = context.kullanicis.FirstOrDefault(x => x.kullaniciadi == User.Identity.Name).kullaniciid;
            mql.yazarid = yazid;
            context.meqales.Add(mql);
            context.SaveChanges();

            return RedirectToAction("Index","Home");

        }



    }
}