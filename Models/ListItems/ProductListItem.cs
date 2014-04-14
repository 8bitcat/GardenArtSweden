using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.Models 
{
    public class ProductListItem : IEnumerable
    {
        public string ImgUrl { get; set; }
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public int FatherProduct { get; set; }
        public string ProductCategoryName { get; set; }
        public int ProductCategoryID { get; set; }
        public string SupplierArticleNumber { get; set; }
        public string GardenArtArticleNumber { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public string MaterialType { get; set; }
        public int? FrameColorID { get; set; }
        public int? MaterialColorID { get; set; }
        public string MaterialColor { get; set; }
        public string FrameColor { get; set; }
        public int ProductSizeWidth { get; set; }
        public int ProductSizeHeight { get; set; }
        public int ProductSizeDepth { get; set; }
        public string PackageInfo { get; set; }
        public string Package { get; set; }
        public string PackageSize { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public int ItemsPerContainer { get; set; }
        public decimal VolumePerItem { get; set; }
        public string Factory { get; set; }
        public string Supplier { get; set; }
        public decimal CostUSD { get; set; }
        public decimal PurchasePriceUSD { get; set; }
        public decimal SellingPriceDirectUSD20 { get; set; }
        public decimal SellingPriceDirectUSD10 { get; set; }
        public decimal SellingPriceWarehouseSEK { get; set; }
        public decimal SellingPriceConsumerSEK { get; set; }

        public string ProductCategoryTypeDisplay { get; set; }

        public List<string> ProductColors { get; set; }

        public List<string> ProductFrames { get; set; }

        public List<string> ProductMaterials { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}