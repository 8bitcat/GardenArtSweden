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
    
    public partial class tMaterial
    {
        public tMaterial()
        {
            this.tProductMaterial = new HashSet<tProductMaterial>();
        }
    
        public int MaterialID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<tProductMaterial> tProductMaterial { get; set; }
    }
}