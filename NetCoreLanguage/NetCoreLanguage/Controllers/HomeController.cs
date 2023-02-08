using Microsoft.AspNetCore.Mvc;
using NetCoreLanguage.Models;
using System.Diagnostics;

//HB Language
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;

namespace NetCoreLanguage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStringLocalizer<HomeController> _stringLocalizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> stringLocalizer)
        {
            _logger = logger;
            _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Privacy = _stringLocalizer["Privacy"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //HB Save Culture
        [HttpPost]
        public IActionResult SetCulture(string newCulture, string returnUrl)
        {
            Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(newCulture)),
                    new CookieOptions
                    {
                        Expires= DateTimeOffset.UtcNow.AddDays(1)
                    }
                );

            return LocalRedirect(returnUrl);
        }

    }
}