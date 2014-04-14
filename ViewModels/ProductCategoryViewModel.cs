using GardenArt.Core.Interfaces;
using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.ViewModels
{
    public class ProductCategoryViewModel : IViewModel<ProductCategoryViewModel>
    {

        private IEnumerable<ProductListItem> _listOfProductsFromCategory;
        private IEnumerable<ProductListItem> _listOfCategories;

        public IEnumerable<ProductListItem> ListOfProductsFromCategory
        { 
            get
            {
                return _listOfProductsFromCategory;
            }
            set
            {
                _listOfProductsFromCategory = value;
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


        public ProductCategoryViewModel GetViewModel()
        {
            throw new NotImplementedException();
        }
    }
}