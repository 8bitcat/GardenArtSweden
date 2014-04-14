using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GardenArt.Infrastructure.Database;
using GardenArt.Models;
using GardenArt.ViewModels;

namespace GardenArt.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryViewModel _categoryViewModel;
      
        public CategoryController()
        {
            _categoryViewModel = new CategoryViewModel();
        }

        //
        // GET: /Category/

        public ActionResult Index()
        {
            return _categoryViewModel.Index();
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id = 0)
        {
            return _categoryViewModel.Details(id);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return _categoryViewModel.Create();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryListItemViewModel categoryListItem)
        {
            return _categoryViewModel.Create(categoryListItem);
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id = 0)
        {
            return _categoryViewModel.Edit(id);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryListItemViewModel categoryListItem)
        {
            return _categoryViewModel.Edit(categoryListItem);
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id = 0)
        {
            return _categoryViewModel.Delete(id);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return _categoryViewModel.DeleteConfirmed(id);
        }

        protected override void Dispose(bool disposing)
        {
            _categoryViewModel.Dispose();
            base.Dispose(disposing);
        }
    }
}