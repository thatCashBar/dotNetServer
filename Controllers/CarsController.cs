using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dotNetServer.Models;
using dotNetServer.DummyData;

namespace dotNetServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Car> GetEnumerable()
        {
            return Cars.GetCars();
        }

        
        [HttpPost("post")]
        public void PostCar(Car car)
        {
            Cars.PostCar(car);
        }
    }
}