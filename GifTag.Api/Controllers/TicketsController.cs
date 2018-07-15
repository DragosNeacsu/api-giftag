using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace GifTag.Api.Controllers
{
    [Route("Ticket")]
    public class TicketsController : Controller
    {
        private ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public JsonResult Generate([FromBody]TicketDto ticket)
        {
            try
            {
                var generatedTicket = _ticketService.Generate(ticket);

                return Json(new ApiResponse(new { generatedTicketId = Converter.ToBase64(generatedTicket.Id) }));
            }
            catch (Exception ex)
            {
                Response.StatusCode = ex.GetType() == typeof(FileNotFoundException) ? 400 : 500;
                return Json(new ApiResponse(null, ex.Message));
            }
        }
    }

    public class ApiResponse
    {
        public ApiResponse(dynamic data, dynamic error = null)
        {
            Data = data;
            Error = error;
        }
        public bool IsSuccess => Error == null;
        public dynamic Data { get; set; }
        public dynamic Error { get; set; }
    }
}
