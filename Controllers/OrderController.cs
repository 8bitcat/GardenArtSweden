using GardenArt.Infrastructure.Database;
using GardenArt.Models;
using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GardenArt.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            var model = new OrderModels();

            //JAG HACKADE LITE HÄR VI KAN KÖRA FurnitureTypeItem, men det går ju lika bra med SELECTLISTITEM?! 
            //Säker något senior devloper hack ;) Byt tillbaka om du vill ;)
            //Egentligen ska vi lägga detta anropet i modellen.. i kontruktorn i detta fallet så modellen alltid fylls med data ;) 
            //och så att vi bara jobba rmed EN enda "objectcontext" samma som databasen ;) annars kommer vi få en för varje gång vi kör sidan.
            //eller vad säger du Cliff?

            return View(model);
        }

        //[HttpPost]
        //public ActionResult Index(ProductViewModel model)
        //{
        //    //  check model.SelectedItemId here

        //    return View();
        //}

        public string AjaxAnswerTest(string ModelType)
        {
            string[] test = Request.Params.GetValues("ddlFurnitureTypeList");            
            string value = test[0];

            Entities gadb = new Entities();
            int numOfRows = gadb.tProduct.Where(x => x.CategoryID == int.Parse(value)).Count();

            string result = "Du skickade " + value + "." + Environment.NewLine + 
                            "Det finns " + numOfRows + " st produkter i denna kategori.";

            return result;
        }


        public JsonResult AjaxAnswerJson()
        {
            string[] test = Request.Params.GetValues("ddlFurnitureTypeList");
            string value = test[0];

            using (Entities gadb = new Entities())
            {
                var jss = (from x in gadb.tProduct
                           where SqlFunctions.StringConvert((double)x.CategoryID) == value 
                           select new SelectListItem {  Text = x.GardenArtArticleNumber,
                                                        Value = SqlFunctions.StringConvert((double)x.ProductID) 
                                                       });



                return Json(jss.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult AjaxProductBuilderJson()
        {
            string[] test = Request.Params.GetValues("ddlFurnitureModelList");
            int value = Convert.ToInt32(test[0].Trim());

            using (Entities gadb = new Entities())
            {
                var jss = (from p in gadb.tProduct
                            join pp in gadb.tProductPicture on p.ProductID equals pp.ProductID into join1
                                from j1 in join1.DefaultIfEmpty()
                            join pic in gadb.tPicture on j1.PictureID equals pic.PictureID into join2
                                from j2 in join2.DefaultIfEmpty()
                            where p.ProductID == value
                           select new
                           {
                               ProductID = p.ProductID,
                               ItemNumber = p.GardenArtArticleNumber,
                               Price = p.SellingPriceWarehouseSEK,
                               FullContainer = p.ItemsPerContainer,
                               Description = p.Description,
                               Picture = "../Images/" + (j2.Picture == null ? "noimage.gif" : j2.Picture)
                           }); 

//                select p.*, ISNULL(pic.Picture, '') Picture from tProduct p
//    left outer join tProductPicture pp on pp.ProductID = p.ProductID
//    left outer join tPicture pic on pic.PictureID = pp.PictureID
//where p.ProductID = 1

                //var jss = (from x in gadb.t_ga_product
                //           where x.ProductID == value
                //           select new
                //           {
                //               ProductID = x.ProductID,
                //               ItemNumber = x.ItemNumber,
                //               Price = x.FobGuangzhouUSD,
                //               FullContainer = x.Quantity40GP,
                //               Description = x.Description,
                //               Picture = "../Images/Products/" + x.Picture
                //           }); 

                return Json(jss.ToList(), JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpPost]
        public JsonResult AjaxSendOrderJson(OrderModel order)
        {
            string htmlTable = "<table>" +
                                    "<tr>" +
                                        "<th>Item Number</th>" +
                                        "<th>Price (unit)</th>" +
                                        "<th>Quantity</th>" +
                                    "</tr>";

            foreach (OrderDetailModel orderDetail in order.Products)
            { 
                htmlTable += "<tr>" +
                                "<td>" + orderDetail.ItemNumber + "</td>" +
                                "<td>" + orderDetail.Price + "</td>" +
                                "<td>" + orderDetail.Quantity + "</td>" +
                            "</tr>";
            }

            htmlTable += "</table>";

            var from = "codem.ninja@outlook.com";
            var to = order.EmailToAddress;
            var subject = "Gardenart - New order";
            var body = "<b>Order details</b><br /><br />" +
                        htmlTable + "<br /><br />" +
                        "Price: " + order.TotalPrice;

            var result = SendMail(from, to, subject, body);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private string SendMail(string from, string to, string subject, string body)
        {
            var ret = "";

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress(from);
                mail.Subject = subject;
                string Body = body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.live.com";
                smtp.Port = 587;
                smtp.Timeout = 10000;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("magnus.kihlberg72@gmail.com", "fingroda1972");// Enter senders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);
                ret = "Order sent.";
            }
            catch (Exception ex) {
                ret = "Error message: " + ex.Message;
            }

            return ret;
        }
    }

    // ordermodell:
    public class OrderModel
    {
        public string NumberOfProducts { get; set; }
        public string TotalFullContainer { get; set; }
        public string TotalPrice { get; set; }
        public string OrderID { get; set; }
        public List<OrderDetailModel> Products { get; set; }
        public string EmailToAddress { get; set; }
        
    }

    public class OrderDetailModel
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int FullContainer { get; set; }
        public string Price { get; set; }
        public string ItemNumber { get; set; }
    }
}
