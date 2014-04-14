using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.Models.Containers
{
    public class ProductContainer
    {
        private ProductListItem _motherProduct;
        private IEnumerable<ProductListItem> _listOfProductsInMotherGroup;
        public ProductListItem MotherProduct
        {
            get { return _motherProduct; }
            set { _motherProduct = value; }
        }
        
        public IEnumerable<ProductListItem> ListOfProductsInMotherGroup
        {
            get { return _listOfProductsInMotherGroup; }
            set { _listOfProductsInMotherGroup = value; }
        }


    }
}