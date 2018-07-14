using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace ApiGifTag.Controllers
{
    [Route("airports")]
    public class AirportsController : Controller
    {
        [HttpGet]
        [Route("{keyword}")]
        public JsonResult GetAirport(string keyword)
        {
            var locale = "en-GB";
            string url = $"https://www.skyscanner.net/dataservices/geo/v2.0/autosuggest/UK/{locale}/{keyword}";

            WebRequest request = HttpWebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var responseJson = JsonConvert.DeserializeObject<Airport>(reader.ReadToEnd());

            return Json(responseJson);
        }
    }
}
