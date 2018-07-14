using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ApiGifTag.Controllers
{
    [Route("Payment")]
    public class PaymentController : Controller
    {
        private TicketService _ticketService;
        private SendGridService _sendGridService;
        public PaymentController()
        {
            _ticketService = new TicketService();
            _sendGridService = new SendGridService();
        }

        [HttpGet]
        public void PayWithPaypal(string email, string fileName)
        {
            var custom = JsonConvert.SerializeObject(
                new
                {
                    email = email,
                    file = fileName
                });

            var price = 1;
            var builder = new StringBuilder();
            var uri = Request.GetDisplayUrl().Split('?')[0];
            builder.Append(Settings.PaypalUrl);
            builder.Append("?cmd=_cart");
            builder.Append($"&business={Settings.PaypalEmail}");
            builder.Append("&upload=1");
            builder.Append("&item_name_1=fakeTicket");
            builder.Append("&item_number_1=p1");
            builder.Append($"&amount_1={price}");
            builder.Append("&quantity_1=1");
            builder.Append("&currency_code=GBP");
            builder.Append($"&custom={custom}");
            builder.Append($"&return={uri}/Return");
            builder.Append($"&cancel_return={uri}/Cancel");

            Response.Redirect(builder.ToString());
        }

        [HttpGet]
        [Route("return")]
        public JsonResult Return()
        {
            var query = $"cmd=_notify-synch&tx={Request.Query["tx"]}&at={Settings.PaypalAuthToken}";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Settings.PaypalUrl);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = query.Length;

            // Write the request back IPN strings
            var stream = req.GetRequestStream();
            var stOut = new StreamWriter(stream);
            stOut.Write(query);
            stOut.Close();

            // Do the request to PayPal and get the response
            StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream());
            var response = ProcessPaypalResponse(reader);

            var obj = JsonConvert.DeserializeObject<dynamic>(Uri.UnescapeDataString(response["custom"]));

            var email = new Email
            {
                EmailAddress = obj.email,
                Body = "to do",
                Subject = "Your fancy boarding pass",
                Attachments = new List<EmailAttachment>
                {
                    new EmailAttachment {
                        Name = "boarding_pass.png",
                        Path =  Path.Combine(Directory.GetCurrentDirectory(), "Content", "GeneratedTickets", obj.file.Value)
                    }
                }
            };
            _sendGridService.SendEmail(email);
            return Json(email);
        }

        private Dictionary<string, string> ProcessPaypalResponse(StreamReader reader)
        {
            string line = reader.ReadLine();
            Dictionary<string, string> results = new Dictionary<string, string>();
            if (line == "SUCCESS")
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var result = line.Split('=');
                    results.Add(result[0], result[1]);
                }
            }
            else if (line == "FAIL")
            {
                results.Add("error", "Unable to retrive transaction detail");
            }
            reader.Close();
            return results;
        }

        public void Cancel()
        {
            var asd = Request;
        }
    }
}
