using GardenArt.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenArt.Core.Repository.Interfaces
{
    interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICollectionRepository CollectionRepository { get; }
        INavDataRepository NavDataRepository { get; }
        INewsRepository NewsRepository { get; }
    }
}
