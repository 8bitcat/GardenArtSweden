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
    
    public partial class tFrameColor
    {
        public tFrameColor()
        {
            this.tProduct = new HashSet<tProduct>();
        }
    
        public int FrameColorID { get; set; }
        public string Name { get; set; }
        public string CssName { get; set; }
    
        public virtual ICollection<tProduct> tProduct { get; set; }
    }
}
