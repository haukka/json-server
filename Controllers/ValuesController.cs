using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using json_server.Models;
using Newtonsoft.Json;
using json_server.AppData;
using Microsoft.AspNetCore.Cors;

namespace json_server.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        public static string _context;

        public UsersController()
        {
            _context = Users.JSONData;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            List<User> users = new List<User>();
            users = JsonConvert.DeserializeObject<List<User>>(_context);
            return Json(users);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            List<User> users = new List<User>();
            users = JsonConvert.DeserializeObject<List<User>>(_context);
            var getUser = users.SingleOrDefault(user => user.Id == id);
            return Json(getUser);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]User value)
        {
            List<User> users = new List<User>();
            users = JsonConvert.DeserializeObject<List<User>>(_context);
            User newUser = new User()
            {
                Id = users.Max(usr => usr.Id) + 1,
                Name = value.Name,
                Phone = value.Phone
            };
            users.Insert(0, newUser);
            _context = JsonConvert.SerializeObject(users);
            Users.JSONData = _context;
            return Json(users);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User value)
        {
          List<User> users = new List<User>();
          users = JsonConvert.DeserializeObject<List<User>>(_context);
          var getUser = users.SingleOrDefault(user => user.Id == id);
          getUser.Name = value.Name;
          getUser.Phone = value.Phone;
          users[users.FindIndex(user => user.Id == id)] = getUser;
          Users.JSONData = _context;
          return Json(getUser);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            List<User> users = new List<User>();
            users = JsonConvert.DeserializeObject<List<User>>(_context);
            var getUser = users.SingleOrDefault(user => user.Id == id);
            var deleteUser = users.Remove(getUser);
            _context = JsonConvert.SerializeObject(users);
            Users.JSONData = _context;
            return Json(users);
        }
    }
}
