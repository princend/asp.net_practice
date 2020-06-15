



using Microsoft.AspNetCore.Mvc;
using myweb;
namespace myweb.Controllers
{
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


        public IActionResult BodySample([FromBody] UserModel model)
        {
            return Ok(model);
        }

        public IActionResult Index(int id)
        {
            return Content($"id:{id}");
        }

        public string getDescription()
        {
            return "this is homecontroller description";
        }


    }
}