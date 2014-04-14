using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
namespace GardenArt.Infrastructure.Mail
{
    public class Emailer
    {

        public string DispatchEmail(string phone, string name, string message, string email)
        {
            StringBuilder sb = new StringBuilder();
            string from = "kontakt@gardenartsweden.se";
            string subject = "Meddelande från kontaktformuläret på Gardenartsweden.se";

            sb.Append("Namn: " + name + "<br/>");
            sb.Append("Email: " + email + "<br/>");
            sb.Append("Telefon: " + phone + "<br/>");
            sb.Append("Meddelande: " + message + "<br/>");

            return SendMail(from, from, subject, sb.ToString());

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
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Timeout = 10000;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("kontakt@gardenartsweden.se", "gardenartsweden");// Enter senders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);
                ret = "Meddelandet Skickat.";
            }
            catch (Exception ex)
            {
                ret = "Det gick fel när meddelandet skulle skickas: " + ex.Message;
            }

            return ret;
        }



    }
}