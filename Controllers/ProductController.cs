using GardenArt.Core.Interfaces;
using GardenArt.Core.Interfaces.Mapper;
using GardenArt.Domain;
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
    public class ProductController : Controller
    {

        IFactory factory = new Factory();
        
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            //Jag mellanlagrade för syns skull, vill någon av er kan vi putta ner allt i return view.
            var mappedViewModel = factory.BuildAndMap<ProductModel, ProductDisplayViewModel>();
            return View(mappedViewModel);
            
        }

        [HttpPost]
        public ActionResult Article()
        {
            var mappedViewModel = factory.BuildAndMap<ProductModel, ArticleDisplayViewModel>();
            return View(mappedViewModel);  
        }

        public ActionResult Article(int id)
        {
            var mappedViewModel = factory.BuildAndMap<ProductModel, ArticleDisplayViewModel>(id);
            return View(mappedViewModel);
        }

        public ActionResult Collections()
        {
            return View();
        }


        public ActionResult Collection(int id)
        {
            var mappedViewModel = factory.BuildAndMap<CollectionModel, CollectionDisplayViewModel>(id);
            return View(mappedViewModel);
        }

       

        public ActionResult Category(int id)
        {
            var mappedViewModel = factory.BuildAndMap<CategoryModel, ProductCategoryViewModel>(id);
            return View(mappedViewModel);
        }
    }
}
