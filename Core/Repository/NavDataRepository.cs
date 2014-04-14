using GardenArt.Core.Interfaces.Repository;
using GardenArt.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web;
using System.Globalization;
using GardenArt.Helpers;
namespace GardenArt.Core.Repository
{
    public class NavDataRepository :  GenericRepository<tCategory>, INavDataRepository
    {
        private Entities dbContext;

        public NavDataRepository(Entities dbContext) :base(dbContext) 
        {
            // TODO: Complete member initialization
            this.dbContext = dbContext;
        }
        public IEnumerable<Infrastructure.Database.tSet> FetchAllColletionNamesAndIds()
        {
            return dbContext.tSet.ToList<tSet>().GroupBy(x => x.Name).Select(x => x.First()); ;
        }

        public IEnumerable<Infrastructure.Database.tCategory> FetchAllCategoryNamesAndIds()
        {

            return dbContext.tCategory.ToList<tCategory>().GroupBy(x => x.Name).Select(x => x.First());
        }

        public IEnumerable<Infrastructure.Database.tSet> BaseFetchAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Infrastructure.Database.tSet> BaseFindById(int id)
        {
            throw new NotImplementedException();
        }

        public void BaseAdd(Infrastructure.Database.tSet entity)
        {
            throw new NotImplementedException();
        }

        public void BaseDelete(Infrastructure.Database.tSet entity)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<IGrouping<string,tNewsItem>> FetchAllNewsAndIds()
        {
            return dbContext.tNewsItem.ToList<tNewsItem>().OrderByDescending(i => i.DateModified.Month).GroupBy(x => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.DateCreated.Month).UpperCaseFirst()).OrderByDescending(x => DateTime.ParseExact(x.Key, "MMMM", CultureInfo.CurrentCulture).Month).Select(x => x);
        }
    }
}