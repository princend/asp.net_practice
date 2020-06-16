



using Microsoft.AspNetCore.Mvc;
using myweb;
using myweb.Models;

namespace myweb.Controllers
{
    [Route("home")]
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

        [HttpPost]
        public IActionResult BodySample([FromBody] UserModel model)
        {
            return Ok(model);
        }

        [HttpGet]
        [Route("Index")]
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