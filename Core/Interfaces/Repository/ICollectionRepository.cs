using GardenArt.Core.Repository.Interfaces;
using GardenArt.Infrastructure.Database;
using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenArt.Core.Interfaces.Repository
{
    interface ICollectionRepository : IRepository<tSet>
    {
        IEnumerable<CollectionListItem> FetchById(int id);
        IEnumerable<CollectionListItem> FetchAll();
        IEnumerable<ProductListItem> FetchFromCollection(int id);
    }
}
