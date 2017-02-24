using Newtonsoft.Json;
using System;
using System.IO;

namespace DockerDotNetCoreApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var content = JsonConvert.DeserializeObject<Content>(File.ReadAllText("quotes.json"));

            var r = new Random().Next(content.Quotes.Length);

            Console.WriteLine(content.Quotes[r]);
        }

        public class Content
        {
            public string[] Quotes { get; set; }
        }
    }
}