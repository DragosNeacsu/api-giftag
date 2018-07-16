using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace GifTag.Api.Controllers
{
    public class AirlinesController : Controller
    {
        [HttpGet]
        [Route("airlines/{keyword}")]
        public JsonResult GetAirlines(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return Json(new NullReferenceException("Keyword cannot be null or empty"));
            }
            var resultList = new List<AirlineDto>();
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Content", "Airlines");

            var fileNames = Directory.EnumerateFiles(directoryPath, $"*{keyword.ToLower()}*.*", SearchOption.TopDirectoryOnly);

            foreach (var file in fileNames)
            {
                var fileName = file.Substring(file.LastIndexOf("\\") + 1);
                var airlineName = FormatFileName(fileName);
                if (airlineName.ToLower().Contains(keyword.ToLower()))
                {
                    resultList.Add(new AirlineDto
                    {
                        AirlineName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(airlineName),
                        AirlineLogo = $"/AirlineLogo/{fileName}",
                        AirlineCode = fileName
                    });
                }
            }

            return Json(resultList);
        }

        [HttpGet]
        [Route("airlines")]
        public JsonResult GetAll()
        {
            try
            {
                var resultList = new List<dynamic>();
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Content", "Airlines");

                var fileNames = Directory.EnumerateFiles(directoryPath);

                foreach (var file in fileNames)
                {
                    var fileName = file.Substring(file.LastIndexOf("\\") + 1);
                    var airlineName = FormatFileName(fileName);

                    resultList.Add(new
                    {
                        airlineName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(airlineName),
                        airlineLogo = $"/AirlineLogo/{fileName}",
                        airlineCode = fileName
                    });
                }

                return Json(resultList);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        private string FormatFileName(string airlineName)
        {
            airlineName = airlineName.Split('.')[0];
            airlineName = airlineName.Replace("-", " ");
            airlineName = airlineName.Replace("_", " ");

            return airlineName;
        }
    }
}
