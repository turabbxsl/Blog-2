using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogsayti.Models;
using Blogsayti.AppClasses;

namespace Blogsayti.Controllers
{
    public class HomeController : Controller
    {

        Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Meqalelistele()
        {
            var data = context.meqales.ToList();
            return View("Meqalelistelewidget",data);
        }

        public PartialViewResult Populyarmeqaleler()
        {
            var model = context.meqales.OrderByDescending(x => x.eklenmetarixi).Take(3).ToList();
            return PartialView(model);
        }

        public PartialViewResult Sitehaqqinda()
        {
            return PartialView();
        }


    }
}