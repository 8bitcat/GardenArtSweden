using GardenArt.Core.Interfaces.Repository;
using GardenArt.Infrastructure.Database;
using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.Core.Repository
{
    public class NewsRepository : GenericRepository<tNewsItem>, INewsRepository
    {
        private Entities dbcontext; 
        public NewsRepository(Entities dbcontext) : base(dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public NewsListItem FetchNewsById(int id)
        {

            var xx= (from x in dbcontext.tNewsItem
                     where x.NewsItemID == id
                    select new NewsListItem
                    {
                        NewsCreated = x.DateCreated,
                        NewsModified = x.DateModified,
                        NewsPublished = x.Published,
                        NewsText = x.Text,
                        NewsTitle = x.Title
                    }
                    ).FirstOrDefault<NewsListItem>();

            xx.Newspicture = (from x in dbcontext.tNewsItem
                              from y in dbcontext.tNewsItemPicture
                              from z in dbcontext.tPicture
                              where x.NewsItemID == id
                              && x.NewsItemID == y.NewsItemID
                              && y.PictureID == z.PictureID
                              select z.Picture).ToList<string>();
            return xx;

        }
    }
}