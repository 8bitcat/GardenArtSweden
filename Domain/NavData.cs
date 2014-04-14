using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GardenArt.Core.Repository;
using GardenArt.Core.Repository.Interfaces;
using GardenArt.Infrastructure.Database;
using GardenArt.Models;
using GardenArt.Core.Interfaces.NavData;

namespace GardenArt.Domain
{
    public class NavData : INavData
    {
        private static NavData _navdata; 
        private IUnitOfWork iUow = new UnitOfWork();
        private IEnumerable<ProductListItem> _allCollections;
        private IEnumerable<ProductListItem> _allCategories;
        private IEnumerable<IGrouping<string,tNewsItem>>  _allNews;
        private NavData()
        {
            this._allCollections = iUow.NavDataRepository.FetchAllColletionNamesAndIds()
                .Select(x =>
                            new ProductListItem
                            {
                                ProductCategoryName = x.Name,
                                ProductCategoryID = x.SetID
                            }
                       )
                .ToList()
                .GroupBy(x => x.ProductCategoryName)
                .Select(y => y.First());

            this._allCategories = iUow.NavDataRepository.FetchAllCategoryNamesAndIds()               
                .Select(x =>
                            new ProductListItem
                            {
                                ProductCategoryName = x.Name,
                                ProductCategoryID = x.CategoryID
                            }
                       )
               .ToList()
               .GroupBy(x => x.ProductCategoryName)
               .Select(y => y.First()).OrderBy(o => o.ProductCategoryName);

            this._allNews = iUow.NavDataRepository.FetchAllNewsAndIds();


        }
        public static NavData getInstance()
        {           
            if(_navdata == null)
            {   //Ensure only one gets created!
                _navdata = new NavData();
                return _navdata;
            }
            else
            {
                return _navdata;
            }
        }
        public IEnumerable<ProductListItem> AllCollections
        {
            get { return _allCollections; }
        }

        public IEnumerable<ProductListItem> AllCategories
        {
            get { return _allCategories; }
        }

        public IEnumerable<IGrouping<string,tNewsItem>> AllNews
        {
            get { return _allNews; }
        }


    }
}