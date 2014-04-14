using GardenArt.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GardenArt.ViewModels
{
    public class MaterialViewModel : Controller
    {
        private Entities _db;

        public MaterialViewModel()
        {
            _db = new Entities();
        }

        public ViewResult Index()
        {
            return View(GetMaterialList());
        }

        private List<MaterialListItemViewModel> GetMaterialList()
        {
            List<MaterialListItemViewModel> materialList = new List<MaterialListItemViewModel>();

            foreach (var dbItem in _db.tMaterial.ToList())
            {
                MaterialListItemViewModel listItem = new MaterialListItemViewModel();

                listItem.MaterialID = dbItem.MaterialID;
                listItem.Name = dbItem.Name;
                listItem.Description = dbItem.Description;

                materialList.Add(listItem);
            }

            return materialList;
        }

        public ActionResult Details(int id)
        {
            return this.GetMaterialListItem(id);
        }

        public ActionResult GetMaterialListItem(int id)
        {
            tMaterial tmaterial = _db.tMaterial.Find(id);

            MaterialListItemViewModel materialItem = new MaterialListItemViewModel();

            if (tmaterial == null)
            {
                return HttpNotFound();
            }
            else
            {
                materialItem.MaterialID = tmaterial.MaterialID;
                materialItem.Name = tmaterial.Name;
                materialItem.Description = tmaterial.Description;
            }

            return View(materialItem);
        }

        public ActionResult Edit(int id)
        {
            return this.GetMaterialListItem(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MaterialListItemViewModel materialListItem)
        {
            if (ModelState.IsValid)
            {
                tMaterial tmaterial = _db.tMaterial.Find(materialListItem.MaterialID);

                tmaterial.Name = materialListItem.Name;
                tmaterial.Description = materialListItem.Description;

                _db.Entry(tmaterial).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materialListItem);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaterialListItemViewModel materialListItem)
        {
            if (ModelState.IsValid)
            {
                tMaterial tmaterial = new tMaterial();
                tmaterial.Name = materialListItem.Name;
                tmaterial.Description = materialListItem.Description;

                _db.tMaterial.Add(tmaterial);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materialListItem);
        }

        public ActionResult Delete(int id = 0)
        {
            return this.GetMaterialListItem(id);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tMaterial tmaterial = _db.tMaterial.Find(id);
            _db.tMaterial.Remove(tmaterial);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}