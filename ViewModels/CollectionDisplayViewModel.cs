using GardenArt.Core.Interfaces;
using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.ViewModels
{
    public class CollectionDisplayViewModel : IViewModel<CollectionDisplayViewModel>
    {
        private CollectionListItem _OneCollectionFromID;
        private IEnumerable<CollectionListItem> _listOfCollections;
        public CollectionListItem OneCollectionFromID
        {
            get { return _OneCollectionFromID;  }
            set { _OneCollectionFromID = value; }
        }
        public IEnumerable<CollectionListItem> ListOfCollections
        {
            get { return _listOfCollections; }
            set { _listOfCollections = value; }
        }
        public CollectionDisplayViewModel GetViewModel()
        {
            throw new NotImplementedException();
        }
    }
}