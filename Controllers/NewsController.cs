using GardenArt.Core.Interfaces;
using GardenArt.Domain.Factory;
using GardenArt.Models;
using GardenArt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GardenArt.Controllers
{
    public class NewsController : Controller
    {
       
        IFactory factory = new Factory();
        public ActionResult Index()
        {
            var mappedModel = factory.BuildAndMap<NewsModel, NewsDisplayViewModel>();
            return View(mappedModel);
        }
        
        public ActionResult newsitem(int id)
        {
            var mappedModel = factory.BuildAndMap<NewsModel, NewsOneViewModel>(id);
            return View(mappedModel);
        }



    }
}
