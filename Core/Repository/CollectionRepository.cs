using GardenArt.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GardenArt.Models;
using GardenArt.Infrastructure.Database;
using GardenArt.Core.Repository.Interfaces;
namespace GardenArt.Core.Repository
{
    public class CollectionRepository : GenericRepository<tSet>, ICollectionRepository 
    {
        private Entities dbContext;
        public CollectionRepository(Entities dbContext) : base(dbContext)
        {
            // TODO: Complete member initialization
            this.dbContext = dbContext;
        }
        public IEnumerable<CollectionListItem> FetchById(int id)
        {
            return (from x in dbContext.tSet
                    from y in dbContext.tSetPicture
                    from z in dbContext.tPicture

                          where x.SetID == id
                          && x.SetID == y.SetID
                          && y.PictureID == z.PictureID
                          && z.Width == 700
                          select new CollectionListItem
                          {
                              ImgUrl = z.Picture,
                              CollectionName = x.Name,
                              Description = x.Description,
                              CollectionID = x.SetID
                          })
                          .OrderBy(p => p.CollectionName)
                          .ToList<CollectionListItem>();  
        }


        public IEnumerable<CollectionListItem> FetchAll()
        {
            return (from x in dbContext.tSet
                          from y in dbContext.tSetPicture
                          from z in dbContext.tPicture

                          where x.SetID == y.SetID
                          && y.PictureID == z.PictureID
                          && z.Width == 250
                          select new CollectionListItem
                          {
                              ImgUrl = z.Picture,
                              CollectionName = x.Name,
                              Description = x.Description,
                              CollectionID = x.SetID
                          })
                          .OrderBy(p => p.CollectionName)
                          .ToList<CollectionListItem>();              
        }




        public IEnumerable<ProductListItem> FetchFromCollection(int id)
        {
            return (from u in dbContext.tSet
                    from v in dbContext.tProduct
                    from x in dbContext.tProductPicture
                    from y in dbContext.tPicture
                    from z in dbContext.tSetDetail
                    from uu in dbContext.tCategory
                    from ii in dbContext.tProductGroupDetail
                    where u.SetID == id
                    && u.SetID == z.SetID
                    && z.ProductID == v.ProductID
                    && v.ProductID == x.ProductID
                    && x.PictureID == y.PictureID
                    && uu.CategoryID == v.CategoryID
                    && ii.ProductID ==v.ProductID
                    && y.Width == 250
                    select new ProductListItem
                    {
                        ImgUrl = y.Picture,
                        ProductCategoryName = uu.Name,
                        ProductID = v.ProductID,
                        ProductCategoryID = u.SetID,
                        ProductName = v.Name,
                        FatherProduct = ii.ProductGroupID,
                        SupplierArticleNumber = v.SupplierArticleNumber,
                        GardenArtArticleNumber = v.GardenArtArticleNumber,
                        Comment = v.Comment,
                        Description = v.Description,
                        FrameColorID = v.FrameColorID,
                        MaterialColorID = v.MaterialColorID,
                        ProductSizeWidth = v.ProductSizeWidth,
                        ProductSizeHeight = v.ProductSizeHeight,
                        ProductSizeDepth = v.ProductSizeHeight,
                        PackageInfo = v.PackageInfo,
                        Package = v.Package,
                        PackageSize = v.PackageSize,
                        GrossWeight = v.GrossWeight,
                        NetWeight = v.NetWeight,
                        ItemsPerContainer = v.ItemsPerContainer,
                        VolumePerItem = v.VolumePerItem,
                        Factory = v.Factory,
                        Supplier = v.Supplier,
                        CostUSD = v.CostUSD,
                        PurchasePriceUSD = v.PurchasePriceUSD,
                        SellingPriceDirectUSD20 = v.SellingPriceDirectUSD20,
                        SellingPriceDirectUSD10 = v.SellingPriceDirectUSD10,
                        SellingPriceWarehouseSEK = v.SellingPriceWarehouseSEK,
                        SellingPriceConsumerSEK = v.SellingPriceConsumerSEK,

                    }).ToList().GroupBy(x => x.FatherProduct).Select(u => u.FirstOrDefault());

                
                
                
        }
    }
}