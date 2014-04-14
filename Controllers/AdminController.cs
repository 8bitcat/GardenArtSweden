using GardenArt.Infrastructure.Uploaders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GardenArt.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult ImageUpload()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ImageUpload(List<HttpPostedFileBase> image)
        {          
            ViewBag.AntalBilder = FileSaver(image);
            return View();
        }


        public string FileSaver(List<HttpPostedFileBase> Files)
        {
            string retString = "";

            if (Files != null)
            {
                retString = "Du laddade upp " + Files.Count.ToString() + " bilder!";

                foreach (var picture in Files)
                {
                    if (picture.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(picture.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/Products"), filename);
                        picture.SaveAs(path);
                    }
                }

            }
            else
            {
                retString = "Något gick fel när du laddade upp din bilder!";
            }
            


            return retString;
        }


    }
}
