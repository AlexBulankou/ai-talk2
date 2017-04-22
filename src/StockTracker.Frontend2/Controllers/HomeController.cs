namespace StockTracker.Frontend.Controllers
{
    // using Microsoft.ApplicationInsights;
    // using Microsoft.ApplicationInsights.DataContracts;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        /*
        private static TelemetryClient telemetryClient = new TelemetryClient();
        */
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            /*
            DependencyTelemetry customDependency = new DependencyTelemetry();

            // set type, target (server name)
            customDependency.Type = "MySQL";
            customDependency.Target = "mysql.net";
            // data is full statement
            customDependency.Data = "select * from mytable";
            customDependency.Duration = TimeSpan.FromMilliseconds(200);
            customDependency.Name = "mydb | command";
            customDependency.ResultCode = "0";
            customDependency.Success = true;

            telemetryClient.TrackDependency(customDependency);
             */
            return View();
           
        }

        public FileContentResult Header()
        {
            var result = new MemoryStream();
            HttpWebRequest httpClient = (HttpWebRequest)HttpWebRequest.Create(ConfigurationManager.AppSettings["HeaderUrl"]);
            using (var responseStream = httpClient.GetResponse().GetResponseStream())
            {
                responseStream.CopyTo(result);
            }

            return new FileContentResult(result.ToArray(), "image/png");

        }

        public ContentResult Stock(string symbol)
        {
            var result = string.Empty;
            HttpWebRequest httpClient = (HttpWebRequest)HttpWebRequest.Create((ConfigurationManager.AppSettings["NodeServerUrl"] + "/?symbol=" + symbol));
            using (StreamReader reader = new StreamReader(httpClient.GetResponse().GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            if (!string.IsNullOrEmpty(result))
            {
                return Content(result, "application/json");
            }
            else
            {
                throw new HttpException(500, "Invalid dependency response");
            }

        }
    }
}