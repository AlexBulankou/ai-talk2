namespace StockTracker.Backend.Controllers
{
    using System.IO;
    using System.Net;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        [HttpGet]
        public ContentResult Stock(string symbol)
        {
            var result = string.Empty;
            HttpWebRequest httpClient = (HttpWebRequest)HttpWebRequest.Create("http://finance.google.com/finance/info?client=ig&q=" + symbol);
            using (StreamReader reader = new StreamReader(httpClient.GetResponse().GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            return Content(result.Substring(3), "application/json");
        }
    }
}