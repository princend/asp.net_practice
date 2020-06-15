



using Microsoft.AspNetCore.Mvc;
using myweb;

public class HomeController : Controller
{
    private readonly ISampleTransient _transient;
    private readonly ISampleScoped _scoped;
    private readonly ISampleSingleton _singleton;
    public HomeController(
        ISampleTransient transient,
        ISampleScoped scoped,
        ISampleSingleton singleton
    )
    {
        _transient = transient;
        _scoped = scoped;
        _singleton = singleton;
    }

    public IActionResult Index()
    {
        ViewBag.transientId = _transient.Id;
        ViewBag.transientHasCode = _transient.GetHashCode();

        ViewBag.ScopeId = _scoped.Id;
        ViewBag.ScopeHashCode = _scoped.GetHashCode();

        ViewBag.SingletonId = _singleton.Id;
        ViewBag.SingletonHashCode = _singleton.GetHashCode();

        var user = new UserModel();
        return View(model: user);
    }

    public string getDescription()
    {
        return "this is homecontroller description";
    }
}
