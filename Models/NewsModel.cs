using GardenArt.Core.Interfaces;
using GardenArt.Core.Interfaces.Models;
using GardenArt.Core.Interfaces.NavData;
using GardenArt.Core.Interfaces.Repository;
using GardenArt.Core.Repository;
using GardenArt.Core.Repository.Interfaces;
using GardenArt.Domain;
using GardenArt.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.Models
{
    public class NewsModel:IModel<NewsModel>, INewsModel
    {
        private IUnitOfWork iUOW = new UnitOfWork();
        private INewsRepository iNewsRep;
        private INavData ndata;
        private NewsListItem _OneNewsById;
        private IEnumerable<IGrouping<string,tNewsItem>> _ListOfNews;
        private IEnumerable<ProductListItem> _listOfCategories;
        public NewsModel()
        {
            ndata = NavData.getInstance();
            this._ListOfNews = ndata.AllNews;
        }

        public NewsModel(int id)
        {
            ndata = NavData.getInstance();
            this._ListOfNews = ndata.AllNews;
            iNewsRep = iUOW.NewsRepository;
            this._OneNewsById = iNewsRep.FetchNewsById(id);
        }

        public NewsModel GetDetailedModel<Tinput>(Tinput identifier)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGrouping<string,tNewsItem>> ListOfNews
        {
            get { return _ListOfNews; }
        }

        public NewsListItem OneNewsById
        {
            get {return _OneNewsById;}
        }
    }
}