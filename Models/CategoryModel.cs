using GardenArt.Core.Interfaces;
using GardenArt.Core.Interfaces.Models;
using GardenArt.Core.Interfaces.NavData;
using GardenArt.Core.Repository;
using GardenArt.Core.Repository.Interfaces;
using GardenArt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.Models
{
    public class CategoryModel : IModel<CategoryModel>, ICategoryModel
    {
        private IUnitOfWork iUOW = new UnitOfWork();
        private IProductRepository iprod;
        private IEnumerable<ProductListItem> _ListOfProductsFromCategory;
        private IEnumerable<ProductListItem> _listOfCategories;

        public CategoryModel()
        {

        }
        public CategoryModel(int id)
        {

            iprod = iUOW.ProductRepository;
            INavData ndata = NavData.getInstance();

            this._ListOfProductsFromCategory = iprod.FetchProductsByCategory(id);
            this._listOfCategories = ndata.AllCategories;
        }


        public IEnumerable<ProductListItem> ListOfProductsFromCategory
        {
            get
            {
                return _ListOfProductsFromCategory;
            }
            set
            {
                _ListOfProductsFromCategory = value;
            }
        }

        public IEnumerable<ProductListItem> ListOfCategories
        {
            get
            {
                return _listOfCategories;
            }
            set
            {
                _listOfCategories = value;
            }
        }

        public CategoryModel GetDetailedModel<Tinput>(Tinput identifier)
        {
            throw new NotImplementedException();
        }
    }
}