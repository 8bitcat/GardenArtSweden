using GardenArt.Infrastructure.Database;
using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenArt.Core.Interfaces.Models
{
    interface INewsModel
    {
        IEnumerable<IGrouping<string,tNewsItem>> ListOfNews { get; }
        NewsListItem OneNewsById { get; }
    }
}
