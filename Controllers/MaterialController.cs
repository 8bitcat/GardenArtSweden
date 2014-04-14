using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GardenArt.Infrastructure.Database;
using GardenArt.ViewModels;

namespace GardenArt.Controllers
{
    public class MaterialController : Controller
    {
        private MaterialViewModel _materialViewModel;

        public MaterialController()
        {
            _materialViewModel = new MaterialViewModel();
        }

        //
        // GET: /Material/

        public ActionResult Index()
        {
            return _materialViewModel.Index();
        }

        //
        // GET: /Material/Details/5

        public ActionResult Details(int id = 0)
        {
            return _materialViewModel.Details(id);
        }

        //
        // GET: /Material/Create

        public ActionResult Create()
        {
            return _materialViewModel.Create();
        }

        //
        // POST: /Material/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaterialListItemViewModel materialListItem)
        {
            return _materialViewModel.Create(materialListItem);
        }

        //
        // GET: /Material/Edit/5

        public ActionResult Edit(int id = 0)
        {
            return _materialViewModel.Edit(id);
        }

        //
        // POST: /Material/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MaterialListItemViewModel materialListItem)
        {
            return _materialViewModel.Edit(materialListItem);
        }

        //
        // GET: /Material/Delete/5

        public ActionResult Delete(int id = 0)
        {
            return _materialViewModel.Delete(id);
        }

        //
        // POST: /Material/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return _materialViewModel.DeleteConfirmed(id);
        }

        protected override void Dispose(bool disposing)
        {
            _materialViewModel.Dispose();
            base.Dispose(disposing);
        }
    }
}