using GardenArt.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GardenArt.Models;

namespace GardenArt.Core.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        public CategoryListItem FetchById(int id)
        {
            return null;
        }

        public IEnumerable<CategoryListItem> FetchAll()
        {
            return null;
        }
    }
}