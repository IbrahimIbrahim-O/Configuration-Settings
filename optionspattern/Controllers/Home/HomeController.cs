using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using optionspattern.ConfigOptions;

namespace optionspattern.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly AppSettingsOptions _options;

        public HomeController(IConfiguration configuration, IOptions<AppSettingsOptions> options)
        {
            _configuration = configuration;
            _options = options.Value;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Title = _configuration["weatherapi:title"];
            ViewBag.clientId = _configuration.GetSection("weatherapi")["clientid"];
            ViewBag.clientSecret = _configuration.GetValue("weatherapi:clientSecret", "default client secret");

            return View();
        }

        [Route("/about")]
        public IActionResult About()
        {
            var a = _configuration.GetSection("Logging:LogLevel").Get<AppSettingsOptions>();
            var weatherapi = _configuration.GetSection("weatherapi").Get<AppSettingsOptions>();
            ViewBag.clientId = weatherapi.ClientID;
            ViewBag.clientSecret = weatherapi.ClientSecret;
            ViewBag.test = a.test;

            return View();
        }

        [Route("/contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact us";
            ViewBag.clientId = _options.ClientID;
            ViewBag.clientSecret = _options.ClientSecret;
            ViewBag.test = _options.test;
            return View();
        }
    }
}
