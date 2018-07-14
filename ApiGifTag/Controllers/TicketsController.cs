using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ApiGifTag.Controllers
{
    [Route("Ticket")]
    public class TicketsController : Controller
    {
        private TicketService _ticketService;
        private SendGridService _sendGridService;
        public TicketsController()
        {
            _ticketService = new TicketService();
            _sendGridService = new SendGridService();
        }
        [HttpPost]
        public JsonResult Generate([FromBody]Ticket ticket)
        {
            try
            {
                var generatedTicket = _ticketService.Generate(ticket);
                var email = new Email
                {
                    EmailAddress = generatedTicket.Email,
                    Body = "to do",
                    Subject = "Your fancy boarding pass",
                    Attachments = new List<EmailAttachment>
                {
                    new EmailAttachment {
                        Name = "boarding_pass.png",
                        Path = Path.Combine(Directory.GetCurrentDirectory(), "Content", "GeneratedTickets", generatedTicket.GeneratedTicket.FileName)
                    }
                }
                };
                _sendGridService.SendEmail(email);
                return Json(generatedTicket);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}
