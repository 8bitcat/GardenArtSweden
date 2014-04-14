using GardenArt.Core.Interfaces;
using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.ViewModels
{
    public class SetDisplayViewModel : IViewModel<SetDisplayViewModel>
    {

        IEnumerable<ProductListItem> _ProductsInSet;
        IEnumerable<ProductListItem> _ListOfCollections;

        public IEnumerable<ProductListItem> ProductsInSet
        {
            get { return _ProductsInSet; }
            set { _ProductsInSet = value; }
        }


        public IEnumerable<ProductListItem> ListOfCollections
        {
            get { return _ListOfCollections; }
            set { _ListOfCollections = value; }
        }

        public SetDisplayViewModel GetViewModel()
        {
            throw new NotImplementedException();
        }
    }
}