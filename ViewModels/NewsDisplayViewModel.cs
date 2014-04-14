using GardenArt.Core.Interfaces;
using GardenArt.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.ViewModels
{
    public class NewsDisplayViewModel : IViewModel<NewsDisplayViewModel>
    {

        IEnumerable<IGrouping<string,tNewsItem>> _listOfNews;

        public IEnumerable<IGrouping<string,tNewsItem>> ListOfNews
        {
            get
            {
                return _listOfNews;
            }
            set
            {
                _listOfNews = value;
            }
        }

        public NewsDisplayViewModel GetViewModel()
        {
            throw new NotImplementedException();
        }
    }
}