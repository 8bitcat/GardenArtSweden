//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GardenArt.Infrastructure.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class tPicture
    {
        public tPicture()
        {
            this.tCategoryPicture = new HashSet<tCategoryPicture>();
            this.tProductPicture = new HashSet<tProductPicture>();
            this.tSetPicture = new HashSet<tSetPicture>();
            this.tNewsItemPicture = new HashSet<tNewsItemPicture>();
            this.tProductGroupPicture = new HashSet<tProductGroupPicture>();
        }
    
        public int PictureID { get; set; }
        public string Picture { get; set; }
        public int Width { get; set; }
    
        public virtual ICollection<tCategoryPicture> tCategoryPicture { get; set; }
        public virtual ICollection<tProductPicture> tProductPicture { get; set; }
        public virtual ICollection<tSetPicture> tSetPicture { get; set; }
        public virtual ICollection<tNewsItemPicture> tNewsItemPicture { get; set; }
        public virtual ICollection<tProductGroupPicture> tProductGroupPicture { get; set; }
    }
}