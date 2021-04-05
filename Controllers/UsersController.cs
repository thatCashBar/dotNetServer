using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dotNetServer.Models;
using dotNetServer.DummyData;

namespace dotNetServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> GetEnumerable()
        {
            return Users.GetUsers();
        }

        [HttpPost("post")]
        public void PostUser(User user)
        {
            Users.PostUser(user);
        }
    }
}