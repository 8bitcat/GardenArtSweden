using GardenArt.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GardenArt.ViewModels
{
    public class CategoryViewModel : Controller
    {
        private Entities _db;

        public CategoryViewModel()
        {
            _db = new Entities();
        }

        public ViewResult Index()
        {
            return View(GetCategoryList());
        }

        private List<CategoryListItemViewModel> GetCategoryList()
        {
            List<CategoryListItemViewModel> categoryList = new List<CategoryListItemViewModel>();

            //CategoryListItemViewModel listItem = new CategoryListItemViewModel();
            //listItem.CategoryID = 0;
            //listItem.Name = "Välj kategori";

            //categoryList.Add(listItem);

            foreach (var dbItem in _db.tCategory.ToList())
            {
                CategoryListItemViewModel listItem = new CategoryListItemViewModel();

                listItem.CategoryID = dbItem.CategoryID;
                listItem.Name = dbItem.Name;
                listItem.Description = dbItem.Description;

                categoryList.Add(listItem);
            }

            return categoryList;
        }

        public ActionResult Details(int id)
        {
            return this.GetCategoryListItem(id);
        }

        public ActionResult GetCategoryListItem(int id)
        {
            tCategory tcategory = _db.tCategory.Find(id);

            CategoryListItemViewModel categoryItem = new CategoryListItemViewModel();

            if (tcategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                categoryItem.CategoryID = tcategory.CategoryID;
                categoryItem.Name = tcategory.Name;
                categoryItem.Description = tcategory.Description;
            }

            return View(categoryItem);
        }

        public ActionResult Edit(int id)
        {
            return this.GetCategoryListItem(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryListItemViewModel categoryListItem)
        {
            if (ModelState.IsValid)
            {
                tCategory tcategory = _db.tCategory.Find(categoryListItem.CategoryID);

                tcategory.Name = categoryListItem.Name;
                tcategory.Description = categoryListItem.Description;

                _db.Entry(tcategory).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryListItem);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryListItemViewModel categoryListItem)
        {
            if (ModelState.IsValid)
            {
                tCategory tcategory = new tCategory();
                tcategory.Name = categoryListItem.Name;
                tcategory.Description = categoryListItem.Description;

                _db.tCategory.Add(tcategory);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryListItem);
        }

        public ActionResult Delete(int id = 0)
        {
            return this.GetCategoryListItem(id);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tCategory tcategory = _db.tCategory.Find(id);
            _db.tCategory.Remove(tcategory);
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