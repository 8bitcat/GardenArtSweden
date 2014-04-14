using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GardenArt.Infrastructure.Uploaders
{
    public class PictureUploader
    {

        //private IEnumerable<HttpPostedFileBase> mPictures;
        [Required]
        public HttpPostedFileBase image { get; set; }        
    }
}