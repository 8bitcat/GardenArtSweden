using GardenArt.Core.Interfaces;
using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.ViewModels
{
    public class CollectionListViewModel : IViewModel<CollectionListViewModel>
    {
        private IEnumerable<CollectionListItem> _ListOfCollections;
        public IEnumerable<CollectionListItem> ListOfCollections
        {
            get { return _ListOfCollections;  }
            set { _ListOfCollections = value; }
        }

        public CollectionDisplayViewModel GetViewModel()
        {
            throw new NotImplementedException();
        }

        CollectionListViewModel IViewModel<CollectionListViewModel>.GetViewModel()
        {
            throw new NotImplementedException();
        }
    }
}