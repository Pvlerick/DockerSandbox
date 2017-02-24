using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace DockerAspNetCoreNetFramework
{
    [Route("/[controller]")]
    public class QuotesController : ControllerBase
    {
        static string[] Quotes;

        static QuotesController()
        {
            Quotes = JsonConvert.DeserializeObject<Content>(System.IO.File.ReadAllText("quotes.json")).Quotes;
        }

        [HttpGet]
        public IActionResult Get() => Ok(Quotes[new Random().Next(Quotes.Length)]);

        [HttpGet("{count}")]
        public IActionResult GetMany(int count)
        {
            if (count < 0 || count > Quotes.Length)
                return BadRequest($"number of quotes must be between 0 and {Quotes.Length}");

            var r = new Random();
            return Ok(Quotes.OrderBy(_ => r.Next(Quotes.Length)).Take(count));
        }
    }

    public class Content
    {
        public string[] Quotes { get; set; }
    }
}
