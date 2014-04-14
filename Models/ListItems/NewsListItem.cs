using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GardenArt.Models
{
    public class NewsListItem
    {
        public string NewsText { get; set; }
        public string NewsTitle { get; set; }
        public bool NewsPublished { get; set; }
        public DateTime NewsCreated { get; set; }
        public DateTime NewsModified { get; set; }
        public List<string> Newspicture { get; set; }
    }
}