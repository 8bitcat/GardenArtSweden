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
    
    public partial class tProductAttributeValue
    {
        public int ProductAttributeValueID { get; set; }
        public int ProductAttributeID { get; set; }
        public int ProductID { get; set; }
        public string Value { get; set; }
    
        public virtual tProductAttribute tProductAttribute { get; set; }
        public virtual tProduct tProduct { get; set; }
    }
}
