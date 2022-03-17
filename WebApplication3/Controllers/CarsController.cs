using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet("getbyid")]
        public IActionResult Get()
        {
            int id = 0;
            var result = carService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);

            }
            return BadRequest(result);
        }
            [HttpGet("getall")]
            public IActionResult GetAll()
            {

            var result = carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("add")]

        public IActionResult Add(Car car )
        {

            var result = carService.Add(car);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
    }
}
