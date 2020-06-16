using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using myweb.Models;

namespace myweb.Controllers
{


    [Route("[controller]")]
    public class UserCotroller : Controller
    {

        private static List<UserModel> _users = new List<UserModel>();


        [Route("GetUser")]
        [HttpGet("{id}")]
        public ResultModel Get(int id)
        {
            var result = new ResultModel();
            result.Data = _users.SingleOrDefault(c => c.Id == id);
            result.IsSuccess = true;
            return result;
        }


        [HttpPost]
        public ResultModel Post([FromBody] UserModel user)
        {
            var result = new ResultModel();
            user.Id = _users.Count() == 0 ? 1 : _users.Max(c => c.Id) + 1;
            _users.Add(user);
            result.Data = user.Id;
            result.IsSuccess = true;
            return result;
        }


    }

}