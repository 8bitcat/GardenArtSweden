using GardenArt.Core.Repository;
using GardenArt.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GardenArt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            IUnitOfWork iuo = new UnitOfWork();

            IProductRepository ipo = iuo.ProductRepository;

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
         //   var sture = "muhahhaha har ni fått in mig har ni laddat det senaste!";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult History()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult New()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
