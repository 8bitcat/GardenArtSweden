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
    
    public partial class tSetPicture
    {
        public int SetPictureID { get; set; }
        public int SetID { get; set; }
        public int PictureID { get; set; }
        public int SortOrder { get; set; }
    
        public virtual tPicture tPicture { get; set; }
        public virtual tSet tSet { get; set; }
    }
}