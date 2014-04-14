using GardenArt.Core.Interfaces;
using GardenArt.Infrastructure.Database;
using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.ViewModels
{
    public class NewsOneViewModel : IViewModel<NewsOneViewModel>
    {

        NewsListItem _OneNewsById;
        IEnumerable<IGrouping<string, tNewsItem>> _listOfNews;

        public NewsOneViewModel GetViewModel()
        {
            throw new NotImplementedException();
        }
        public NewsListItem OneNewsById
        {
            get { return _OneNewsById; }
            set { _OneNewsById = value; }
        }
        public IEnumerable<IGrouping<string, tNewsItem>> ListOfNews
        {
            get { return _listOfNews; }
            set { _listOfNews = value;}
        }
    }
}