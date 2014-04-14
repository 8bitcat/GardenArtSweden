using GardenArt.Core.Interfaces;
using GardenArt.Core.Interfaces.Models;
using GardenArt.Core.Interfaces.NavData;
using GardenArt.Core.Interfaces.Repository;
using GardenArt.Core.Repository;
using GardenArt.Core.Repository.Interfaces;
using GardenArt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.Models
{
    public class SetModel : IModel<SetModel>, ISetModel
    {
        private IUnitOfWork iUOW = new UnitOfWork();
        private ICollectionRepository iRepo;
        private IEnumerable<ProductListItem> _ProductsInSet;
        private CollectionListItem _OneDetailedCollection;
        private IEnumerable<ProductListItem> _ListOfCollections;

        public SetModel()
        {

        }
        public SetModel(int id)
        {
            INavData ndata = NavData.getInstance();
            _ListOfCollections = ndata.AllCollections;
            iRepo = iUOW.CollectionRepository;
            _ProductsInSet = iRepo.FetchFromCollection(id);
        }

        public IEnumerable<ProductListItem> ProductsInSet
	    {
            get { return _ProductsInSet; }
            set { _ProductsInSet = value; }
	    }


        public IEnumerable<ProductListItem> ListOfCollections
	    {
		    get { return _ListOfCollections;}
		    set { _ListOfCollections = value;}
	    }


        public SetModel GetDetailedModel<Tinput>(Tinput identifier)
        {
            throw new NotImplementedException();
        }
    }
}