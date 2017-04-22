using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StockTracker.Backend.Startup))]
namespace StockTracker.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
        }
    }
}
