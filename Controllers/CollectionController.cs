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
    public class CollectionController : Controller
    {
        //
        // GET: /Collection/
        IFactory factory = new Factory();
        public ActionResult Collections()
        {
            var mappedViewModel = factory.BuildAndMap<CollectionModel, CollectionListViewModel>();
            return View(mappedViewModel);
        }

        public ActionResult Collection(int id)
        {
            var mappedViewModel = factory.BuildAndMap<CollectionModel, CollectionDisplayViewModel>(id);
            return View(mappedViewModel);
        }


        public ActionResult CollectionView(int id)
        {
            var mappedViewModel = factory.BuildAndMap<SetModel, SetDisplayViewModel>(id);
            return View(mappedViewModel);
        }

    }
}
