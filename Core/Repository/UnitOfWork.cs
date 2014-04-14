using GardenArt.Core.Interfaces.Repository;
using GardenArt.Core.Repository.Interfaces;
using GardenArt.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Entities dbContext = new Entities();
        private IProductRepository _productrepo;
        private ICollectionRepository _collectionrepo;
        private INavDataRepository _navDatarepo;
        private INewsRepository _newsrepo;
        IProductRepository IUnitOfWork.ProductRepository
        {
            get { 

                if(this._productrepo == null)
                    this._productrepo = new ProductRepository(dbContext);
                return this._productrepo;
            }
        }
        ICollectionRepository IUnitOfWork.CollectionRepository
        {
            get {
                if (this._collectionrepo == null)
                    this._collectionrepo = new CollectionRepository(dbContext);
                return this._collectionrepo;         
            }
        }

        INavDataRepository IUnitOfWork.NavDataRepository
        {
            get
            {
                if (this._navDatarepo == null)
                    this._navDatarepo = new NavDataRepository(dbContext);
                return this._navDatarepo;
            }
        }

        INewsRepository IUnitOfWork.NewsRepository
        {
            get
            {
                if (this._newsrepo == null)
                    this._newsrepo = new NewsRepository(dbContext);
                return this._newsrepo;
            }
        }
    }
}