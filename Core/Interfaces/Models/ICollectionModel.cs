using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenArt.Core.Interfaces.Models
{
    interface ICollectionModel
    {
        IEnumerable<CollectionListItem> ListOfCollections {get; set;}
        CollectionListItem OneCollectionFromID { get; set; }
    }
}
