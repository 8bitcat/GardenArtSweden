using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using GardenArt.Infrastructure.Mail;
namespace GardenArt.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Contact()
        {
            return View();
        }

        public JsonResult AjaxMailer(MailerModel model)
        {
            Emailer mailer = new Emailer();
            JsonResult Jr = new JsonResult();
            string result = mailer.DispatchEmail(model.phone, model.name, model.message, model.email);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }

    public class MailerModel
    {
         [Required(ErrorMessage = "Du måste fylla i ett namn!")]
        public string name { get; set; }

        [Required(ErrorMessage = "Du måste fylla i en epost!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Eposten är inte riktig!")]
        public string email { get; set; }
      
        public string phone { get; set; }
       
         [Required(ErrorMessage = "Du måste fylla i ett meddelande!")]
        public string message { get; set; }


    }


}
