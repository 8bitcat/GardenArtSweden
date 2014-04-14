using GardenArt.Core.Repository;
using GardenArt.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GardenArt.Infrastructure.Database;
using GardenArt.Core.Repository.Interfaces;
using GardenArt.Core.Interfaces.NavData;
using GardenArt.Domain;
using GardenArt.Models.Containers;
namespace GardenArt.Models
{
    public class ProductModel : IModel<ProductModel>, IProductModel
    {

        private IUnitOfWork iUOW = new UnitOfWork();
        private IProductRepository iProdRep;
        private INavData ndata;
        private IEnumerable<ProductListItem> _ListOfProducts;
        private IEnumerable<ProductListItem> _listOfCategories;
        private IEnumerable<ProductListItem> _OneDetailedArticle;
        private ProductContainer _ProductContainer;
        
       //  ListOfProducts { get; set; }
        public ProductModel()
        {
            iProdRep = iUOW.ProductRepository;
            ndata = NavData.getInstance();
            this._ListOfProducts = iProdRep.FetchAllAsListItems();
            this._listOfCategories = ndata.AllCategories;        
        }
        public ProductModel(int id)
        {
            this.ProductContainer = new ProductContainer();
            iProdRep = iUOW.ProductRepository;
            this._OneDetailedArticle = iProdRep.FetchProductByID(id);

            this._ProductContainer.MotherProduct = this._OneDetailedArticle.Select(x =>
                new ProductListItem
                {
                    ProductColors = this._OneDetailedArticle.Select(i => i.MaterialColor).ToList(),
                    ProductFrames = this._OneDetailedArticle.Select(i => i.FrameColor).ToList(),
                    ProductMaterials = this._OneDetailedArticle.Select(i => i.MaterialType).ToList(),
                    ProductName = this._OneDetailedArticle.Select(i => i.ProductName).First(),
                    Description = this._OneDetailedArticle.Select(i => i.Description).First(),
                    ProductSizeWidth = this._OneDetailedArticle.Select(i => i.ProductSizeWidth).First(),
                    ProductSizeHeight = this._OneDetailedArticle.Select(i => i.ProductSizeHeight).First(),
                    ProductSizeDepth = this._OneDetailedArticle.Select(i => i.ProductSizeDepth).First(),
                    GardenArtArticleNumber = this._OneDetailedArticle.Select(i => i.GardenArtArticleNumber).First(),
                    SellingPriceConsumerSEK = this._OneDetailedArticle.Select(i => i.SellingPriceConsumerSEK).First(),
                    SellingPriceWarehouseSEK = this._OneDetailedArticle.Select(i => i.SellingPriceWarehouseSEK).First(),
                    ProductCategoryTypeDisplay = this._OneDetailedArticle.Select(i => i.ProductCategoryTypeDisplay).First(),
                    ImgUrl = this._OneDetailedArticle.Select(i => i.ImgUrl).First()
                    
                }).FirstOrDefault();
           this._ProductContainer.MotherProduct.ProductColors = this._ProductContainer.MotherProduct.ProductColors.GroupBy(x => x).Select(x => x.FirstOrDefault()).ToList();
           this._ProductContainer.MotherProduct.ProductFrames = this._ProductContainer.MotherProduct.ProductFrames.GroupBy(x => x).Select(x => x.FirstOrDefault()).ToList();
           this._ProductContainer.MotherProduct.ProductMaterials = this._ProductContainer.MotherProduct.ProductMaterials.GroupBy(x => x).Select(x => x.FirstOrDefault()).ToList();
           
        }
        public IEnumerable<ProductListItem> ListOfProducts
        {      
            get
            {
                return _ListOfProducts;
            }
            set
            {
                _ListOfProducts = value;
            }
       
        }
        public ProductModel GetDetailedModel<Tinput>(Tinput identifier)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<ProductListItem> OneArticleFromID
        {
            get
            {
                return _OneDetailedArticle;
            }
            set
            {
                _OneDetailedArticle = value;
            }
        }

        public IEnumerable<ProductListItem> ProductCategories
        {
            get
            {
                return _listOfCategories;
            }
            set
            {
                _listOfCategories = value;
            }
        }

        public ProductContainer ProductContainer
        {
            get
            {
                return _ProductContainer;
            }
            set
            {
                _ProductContainer = value;
            }
        }
    }
}