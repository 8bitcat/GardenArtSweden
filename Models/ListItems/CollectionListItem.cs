using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.Models
{
    public class CollectionListItem
    {

        public List<string> ImgList { get; set; }
       public string ImgUrl { get; set; }
       public string CollectionName { get; set; }
       public string Description { get; set; }
       public int CollectionID { get; set; }
    }
}