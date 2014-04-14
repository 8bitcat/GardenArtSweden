using GardenArt.Core.Repository.Interfaces;
using GardenArt.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenArt.Core.Interfaces.Repository
{
    interface INavDataRepository : IRepository<tSet>
    {
        IEnumerable<tSet> FetchAllColletionNamesAndIds();
        IEnumerable<tCategory> FetchAllCategoryNamesAndIds();
        IEnumerable<IGrouping<string, tNewsItem>> FetchAllNewsAndIds();
    }
}
