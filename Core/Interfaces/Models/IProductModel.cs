using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GardenArt.Core.Interfaces
{
    public interface IProductModel
    {
        IEnumerable<ProductListItem> ListOfProducts { get; set; }
        IEnumerable<ProductListItem> OneArticleFromID { get; set; }
        IEnumerable<ProductListItem> ProductCategories { get; set; }
    }
}
