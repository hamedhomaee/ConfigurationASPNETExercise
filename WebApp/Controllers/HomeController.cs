using ConfigurationSocialMedia.WebApp.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationSocialMedia.Controllers;

public class HomeController : Controller
{
    private readonly SocialMediaLinksOptions _options;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public HomeController(IOptions<SocialMediaLinksOptions> options, IWebHostEnvironment webHostEnvironment)
    {
        _options = options.Value;
        _webHostEnvironment = webHostEnvironment;
    }

    [Route("/")]
    public IActionResult Index()
    {
        ViewBag.Title = "Welcome to Social Media Links";
        
        ViewBag.Facebook = _options.Facebook;

        if (!string.Equals(_webHostEnvironment.EnvironmentName, "Development"))
            ViewBag.Instagram = _options.Instagram;

        ViewBag.Twitter = _options.Twitter;

        ViewBag.Youtube = _options.Youtube;

        return View();
    }
}