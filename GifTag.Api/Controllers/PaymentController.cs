using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace GifTag.Api.Controllers
{
    [Route("Payment")]
    public class PaymentController : Controller
    {
        private ITicketService _ticketService;
        private IEmailService _sendGridService;
        public PaymentController(ITicketService ticketService, IEmailService emailService)
        {
            _ticketService = ticketService;
            _sendGridService = emailService;
        }

        [HttpGet]
        public void PayWithPaypal(string generatedTicketId)
        {
            var price = 1.99;
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
            builder.Append($"&custom={generatedTicketId}");
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
            if (response.ContainsKey("error"))
            {
                throw new Exception(response["error"]);
            }

            var ticket = _ticketService.GetById(int.Parse(Converter.FromBase64(Uri.UnescapeDataString(response["custom"]))));
            ticket.GeneratedTicket = _ticketService.Generate(ticket);
            ticket.IsPaid = true;
            _ticketService.Update(ticket);
            var email = new EmailDto
            {
                EmailAddress = ticket.User.EmailAddress,
                Body = "to do",
                Subject = "Your fancy boarding pass",
                Attachments = new List<EmailAttachmentDto>
                {
                    new EmailAttachmentDto {
                        Name = "boarding_pass.png",
                        Path =  Path.Combine(Directory.GetCurrentDirectory(), "Content", "GeneratedTickets", ticket.GeneratedTicket)
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
