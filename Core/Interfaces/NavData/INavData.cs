using GardenArt.Infrastructure.Database;
using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenArt.Core.Interfaces.NavData
{
    interface INavData
    {
        IEnumerable<ProductListItem> AllCollections { get; }
        IEnumerable<ProductListItem> AllCategories { get; }
        IEnumerable<IGrouping<string,tNewsItem>>  AllNews { get; }


    }
}
