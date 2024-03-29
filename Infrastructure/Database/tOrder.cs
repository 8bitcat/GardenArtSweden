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
    
    public partial class tOrder
    {
        public tOrder()
        {
            this.tOrderDetail = new HashSet<tOrderDetail>();
        }
    
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int OrderStatusID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public decimal TotalPrice { get; set; }
        public string Comment { get; set; }
    
        public virtual tCustomer tCustomer { get; set; }
        public virtual tOrderStatus tOrderStatus { get; set; }
        public virtual ICollection<tOrderDetail> tOrderDetail { get; set; }
    }
}
