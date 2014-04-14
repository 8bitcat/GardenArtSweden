using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenArt.Core.Interfaces.Models
{
    interface ICategoryModel
    {
        IEnumerable<ProductListItem> ListOfProductsFromCategory { get; set; }
        IEnumerable<ProductListItem> ListOfCategories { get; set; }


    }
}
