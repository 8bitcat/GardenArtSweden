using GardenArt.Core.Repository.Interfaces;
using GardenArt.Infrastructure.Database;
using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
namespace GardenArt.Core.Repository
{
    public class ProductRepository : GenericRepository<tProduct>,IProductRepository
    {
        private Entities dbContext;     
        public ProductRepository(Entities dbContext) : base(dbContext)
        {
            // TODO: Complete member initialization
            this.dbContext = dbContext;
         
        }
        IEnumerable<tProduct> IProductRepository.FetchAllProducts()
        {
            return (from x in dbContext.tProduct select x).AsEnumerable<tProduct>();
        }


        IEnumerable<tProduct> IProductRepository.FetchProductsByTypes(IEnumerable<int> type)
        {
            throw new NotImplementedException();
        }


        IEnumerable<tProduct> IProductRepository.FetchProductsByType(int type)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tProduct> IProductRepository.FetchProductsByIDS(IEnumerable<int> id)
        {
            throw new NotImplementedException();
        }

      
        void IRepository<tProduct>.BaseAdd(tProduct entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<tProduct>.BaseDelete(tProduct entity)
        {
            throw new NotImplementedException();
        }


        void IProductRepository.AddProduct(tProduct product)
        {
            try
            {
                this.dbContext.tProduct.Add(product);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
            
            
            
        }


        IEnumerable<tProduct> IRepository<tProduct>.BaseFetchAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<tProduct> IRepository<tProduct>.BaseFindById(int id)
        {
            throw new NotImplementedException();
        }


        IEnumerable<ProductListItem> IProductRepository.FetchAllAsListItems()
        {

            var allProductMothers = (from u in dbContext.tProductPicture
                                     from v in dbContext.tProductGroup
                                     from y in dbContext.tProduct
                                     from x in dbContext.tProductGroupDetail
                                     from z in dbContext.tPicture
                                     where v.ProductGroupID == x.ProductGroupID
                                     && x.ProductID == y.ProductID
                                     && u.ProductID == y.ProductID
                                     && u.PictureID == z.PictureID
                                     && z.Width == 250
                                     select new ProductListItem
                                     {
                                         ImgUrl = z.Picture,
                                         ProductName = v.Name,
                                         ProductID = x.ProductID,
                                         FatherProduct = x.ProductGroupID,
                                         ProductCategoryName = y.tCategory.Name,
                                         ProductCategoryID = (int)y.CategoryID
                                     }
                            ).ToList<ProductListItem>().GroupBy(x => x.FatherProduct).Select(x => x.FirstOrDefault()).GroupBy(y => y.ProductCategoryName).Select(y => y.FirstOrDefault());

            return (IEnumerable<ProductListItem>)allProductMothers.OrderBy(o => o.ProductCategoryName);    
        }

        IEnumerable<ProductListItem> IProductRepository.FetchProductsByCategory(int id)
        {
            var testList = (
                            from u in dbContext.tProductGroup
                            from uu in dbContext.tProductGroupDetail
                            from v in dbContext.tCategory
                            from x in dbContext.tProduct
                            from y in dbContext.tProductPicture
                            from z in dbContext.tPicture
                            where u.ProductGroupID == uu.ProductGroupID
                            && uu.ProductID == x.ProductID
                            && x.ProductID == y.ProductID
                            && y.PictureID == z.PictureID
                            && v.CategoryID == x.CategoryID
                            && x.CategoryID == id
                            
                            select new ProductListItem
                            {
                                ImgUrl = z.Picture,
                                ProductCategoryName = v.Name,
                                ProductID = x.ProductID,
                                FatherProduct = uu.ProductGroupID,
                                ProductCategoryID = v.CategoryID,
                                ProductName = u.Name, // Här måste vi hämta in PappaProduktensnamn!
                                SupplierArticleNumber = x.SupplierArticleNumber,
                                GardenArtArticleNumber = x.GardenArtArticleNumber,
                                Comment = x.Comment,
                                Description = x.Description,
                                ProductSizeWidth = x.ProductSizeWidth,
                                ProductSizeHeight = x.ProductSizeHeight,
                                ProductSizeDepth = x.ProductSizeHeight,
                                PackageInfo = x.PackageInfo,
                                Package = x.Package,
                                PackageSize = x.PackageSize,
                                GrossWeight = x.GrossWeight,
                                NetWeight = x.NetWeight,
                                ItemsPerContainer = x.ItemsPerContainer,
                                VolumePerItem = x.VolumePerItem,
                                Factory = x.Factory,
                                Supplier = x.Supplier,
                                CostUSD = x.CostUSD,
                                SellingPriceDirectUSD20 = x.SellingPriceDirectUSD20,
                                SellingPriceDirectUSD10 = x.SellingPriceDirectUSD10,
                                SellingPriceWarehouseSEK = x.SellingPriceWarehouseSEK,

                            }
                            ).ToList<ProductListItem>().GroupBy(u => u.FatherProduct).Select(x => x.FirstOrDefault());

            return (IEnumerable<ProductListItem>)testList;
        }


        IEnumerable<ProductListItem> IProductRepository.FetchProductByID(int id)
        {
            /* SQL:EN FÖR ATT HÄMTA UT ALLTING
             * 
             *    select * from tProductGroup as tpg, tProductGroupDetail as tgd, tProduct as tp, tMaterialColor as tmc, tProductPicture as tpp, tPicture as tpi
                  where tpg.ProductGroupID = 3
                  and tpg.ProductGroupID = tgd.ProductGroupID
                  and tgd.ProductID = tp.ProductID
                  and tp.MaterialColorID = tmc.MaterialColorID
                  and tp.ProductID = tpp.ProductID
                  and tpp.PictureID = tpi.PictureID
		     */
          
            var productgroupID = (from u in dbContext.tProduct
                                  from xx in dbContext.tProductGroupDetail
                                  where u.ProductID == id
                                  && u.ProductID == xx.ProductID
                                  select xx.ProductGroupID).Single<int>();

            var test =
             (from u in dbContext.tProductGroup
              from v in dbContext.tProductGroupDetail
              from x in dbContext.tProduct
              from y in dbContext.tProductPicture
              from z in dbContext.tPicture
              from zz in dbContext.tMaterialColor
              from xx in dbContext.tFrameColor
              from yy in dbContext.tCategory
              from uu in dbContext.tCategoryType
              from ii in dbContext.tMaterial
              from jj in dbContext.tProductMaterial
              where v.ProductGroupID == productgroupID 
              && v.ProductID == x.ProductID
              && u.ProductGroupID == v.ProductGroupID
              && v.ProductID == x.ProductID
              && x.MaterialColorID == zz.MaterialColorID
              && x.FrameColorID == xx.FrameColorID 
              && x.ProductID == y.ProductID
              && y.PictureID == z.PictureID
              && z.Width == 700
              && x.CategoryID == yy.CategoryID
              && yy.CategoryTypeID == uu.CategoryTypeID
              && x.ProductID == jj.ProductID
              && jj.MaterialID == ii.MaterialID
              select new ProductListItem
              {
                  ImgUrl = z.Picture,
                  ProductID = x.ProductID,
                  ProductName = u.Name, // Här måste vi hämta in PappaProduktensnamn!
                  SupplierArticleNumber = x.SupplierArticleNumber,
                  GardenArtArticleNumber = x.GardenArtArticleNumber,
                  Comment = x.Comment,
                  Description = x.Description,
                  MaterialColor = zz.CssName,
                  MaterialType = ii.Name,
                  FrameColor =  xx.CssName,
                  ProductSizeWidth = x.ProductSizeWidth,
                  ProductSizeHeight = x.ProductSizeHeight,
                  ProductSizeDepth = x.ProductSizeDepth,
                  PackageInfo = x.PackageInfo,
                  Package = x.Package,
                  PackageSize = x.PackageSize,
                  GrossWeight = x.GrossWeight,
                  NetWeight = x.NetWeight,
                  ItemsPerContainer = x.ItemsPerContainer,
                  VolumePerItem = x.VolumePerItem,
                  Factory = x.Factory,
                  Supplier = x.Supplier,
                  CostUSD = x.CostUSD,
                  SellingPriceDirectUSD20 = x.SellingPriceDirectUSD20,
                  SellingPriceDirectUSD10 = x.SellingPriceDirectUSD10,
                  SellingPriceWarehouseSEK = x.SellingPriceWarehouseSEK,
                  ProductCategoryTypeDisplay = uu.Name
                  

              }
              ).ToList<ProductListItem>(); //.GroupBy(u => u.MaterialColor).Select(x => x.FirstOrDefault());

            return test;
        }
    }
}