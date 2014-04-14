using GardenArt.Core.Interfaces;
using GardenArt.Core.Interfaces.Models;
using GardenArt.Core.Interfaces.Repository;
using GardenArt.Core.Repository;
using GardenArt.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.Models
{
    public class CollectionModel : IModel<CollectionModel>, ICollectionModel
    {
        private IUnitOfWork iUOW = new UnitOfWork();
        private IEnumerable<CollectionListItem> _ListOfCollections;
        private CollectionListItem _OneDetailedCollection;

        public CollectionModel()
        {
            this._ListOfCollections = iUOW.CollectionRepository.FetchAll();
        }

        public CollectionModel(int id)
        {

            var fetchedAllinCategory = iUOW.CollectionRepository.FetchById(id);

            this._OneDetailedCollection = fetchedAllinCategory.Select(x => new CollectionListItem
            {
                CollectionID = x.CollectionID,
                CollectionName = x.CollectionName,
                Description = x.Description,
                ImgUrl = x.ImgUrl,
                ImgList = fetchedAllinCategory.Select(i => i.ImgUrl).ToList()
            }).FirstOrDefault<CollectionListItem>();

       

            this._ListOfCollections = iUOW.CollectionRepository.FetchAll().Select(x => new CollectionListItem
            {
                CollectionName = x.CollectionName,
                CollectionID = x.CollectionID,
            });
        }

        public CollectionModel GetDetailedModel<Tinput>(Tinput identifier)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CollectionListItem> ListOfCollections
        {
            get { return  _ListOfCollections;  }
            set { _ListOfCollections = value; }
        }

        public CollectionListItem OneCollectionFromID
        {
            get { return _OneDetailedCollection;  }
            set { _OneDetailedCollection = value; }
        }
    }
}