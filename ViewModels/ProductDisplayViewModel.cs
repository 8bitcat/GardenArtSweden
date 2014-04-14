using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GardenArt.Models;
using GardenArt.Core.Interfaces;

namespace GardenArt.ViewModels
{
    public class ProductDisplayViewModel : IViewModel<ProductDisplayViewModel>
    {
         
        private IEnumerable<ProductListItem> _ListOfProducts;
        private IEnumerable<ProductListItem> _ProductCategories;

        public ProductDisplayViewModel GetViewModel()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductListItem> ListOfProducts
        { 
            get
            {
                return _ListOfProducts;
            }
            set
            {
                _ListOfProducts = value;
            }
    
        }

        public IEnumerable<ProductListItem> ProductCategories
        {
            get
            {
                return _ProductCategories;
            }
            set
            {
                _ProductCategories = value;
            }

        }
    }
}