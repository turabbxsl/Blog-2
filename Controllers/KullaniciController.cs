using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Blogsayti.Models;

namespace Blogsayti.Controllers
{
    public class KullaniciController : Controller
    {

        Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Girisyap()
        {
            return View();
        }


        [HttpPost]
        
        public ActionResult Girisyap(kullanici kl)
        {
            string KA = Validateuser(kl.kullaniciadi, kl.parol);
            if (!string.IsNullOrEmpty(KA))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,kl.kullaniciadi,DateTime.Now,DateTime.Now.AddMinutes(15),true,KA,FormsAuthentication.FormsCookiePath);

                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName);

                if (ticket.IsPersistent)
                {
                    ck.Expires = ticket.Expiration;
                }
              
                Response.Cookies.Add(ck);

                FormsAuthentication.RedirectFromLoginPage(kl.kullaniciadi, true);

                if (KA == "spartal55")
                {
                    Session["admin"] = KA;
                }
                else
                {
                    Session["istifadeci"] = KA;
                }

                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Girisyap");
        }

        string Validateuser(string ka, string pwd)
        {
            kullanici kl = context.kullanicis.FirstOrDefault(x => x.kullaniciadi == ka && x.parol == pwd);
            if (kl != null)
            {
                return kl.kullaniciadi;
            }
            else
            {
                return "";
            }
        }

        public ActionResult Cikisyap(string redirectUrl)
        {
            if (Session["admin"] != null)
            {
                Session["admin"] = null;
                return RedirectToAction("Index", "Home");
            }
            Session["istifadeci"] = null;
            //return RedirectToAction("Index","Home");         

            return Redirect(redirectUrl);
        }

        public ActionResult Uyeol()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Uyeol(kullanici kl,string rdman,string rdwoman)
        {
            if (!string.IsNullOrEmpty(rdman))
            {
                kl.cinsiyyet = true;
            }
            if (!string.IsNullOrEmpty(rdwoman))
            {
                kl.cinsiyyet = false;
            }
            kl.yazar = false;
            kl.onaylandi = true;
            kl.aktif = true;
            kl.dogumtarixi =Convert.ToDateTime(kl.dogumtarixi.Value.ToShortDateString());
            kl.kayittarixi = DateTime.Now;
            context.kullanicis.Add(kl);
            context.SaveChanges();
            return RedirectToAction("Girisyap");
        }

    }
}