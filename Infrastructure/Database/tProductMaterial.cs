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
    
    public partial class tProductMaterial
    {
        public int ProductMaterialID { get; set; }
        public int ProductID { get; set; }
        public int MaterialID { get; set; }
    
        public virtual tMaterial tMaterial { get; set; }
        public virtual tProduct tProduct { get; set; }
    }
}