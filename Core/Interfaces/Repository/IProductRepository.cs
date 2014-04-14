using GardenArt.Infrastructure.Database;
using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenArt.Core.Repository.Interfaces
{
    interface IProductRepository : IRepository<tProduct>
    {
        IEnumerable<tProduct> FetchAllProducts();
        IEnumerable<tProduct> FetchProductsByTypes(IEnumerable<int> type);
        IEnumerable<tProduct> FetchProductsByType(int type);
        IEnumerable<tProduct> FetchProductsByIDS(IEnumerable<int> id);
        IEnumerable<ProductListItem> FetchProductByID(int id);
        void AddProduct(tProduct product);
        IEnumerable<ProductListItem> FetchAllAsListItems();
        IEnumerable<ProductListItem> FetchProductsByCategory(int id);
    }
}
