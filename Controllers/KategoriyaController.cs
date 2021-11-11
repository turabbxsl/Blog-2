using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogsayti.Models;

namespace Blogsayti.Controllers
{
    public class KategoriyaController : Controller
    {
        
        Context context = new Context();
        public ActionResult Index(int id)
        {
            return View(id);
        }

        public PartialViewResult Kategoriyawidget()
        {
            return PartialView(context.kategoriyas.ToList());
        }


        public ActionResult Meqalelistele(int id)
        {
            var data = context.meqales.Where(x => x.kategoriyaid == id).ToList();
            return View("Meqalelistelewidget",data);
        }



    }
}