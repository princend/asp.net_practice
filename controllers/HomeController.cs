
using Microsoft.AspNetCore.Mvc;

[MiddlewareFilter(typeof(FirstMiddleware))]
public class HomeController : Controller
{
    // [MiddlewareFilter(typeof(FirstMiddleware))]
    // public IActionResult Index()
    // {
    //     string a = "g";
    //     return a;
    // }
}