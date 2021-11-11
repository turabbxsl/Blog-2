using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogsayti.Models;

namespace Blogsayti.Controllers
{
    public class EtiketController : Controller
    {
        Context context = new Context();
        public ActionResult Index(int id)
        {
            return View(id);
        }

        public PartialViewResult Etiketlerwidget()
        {
            return PartialView(context.etikets.ToList());
        }

        public ActionResult Meqalelistele(int id)
        {
            var data = context.meqales.Where(x => x.etikets.Any(y => y.etiketid == id)).ToList();
            return View("Meqalelistelewidget",data);
        }


    }
}