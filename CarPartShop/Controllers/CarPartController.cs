using CarPartShop.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPartController : ControllerBase
    {
        private readonly CarPartService _service;
        public CarPartController(CarPartService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _service.GetAllCarParts();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = _service.GetCarPartById(id);
            if (response == null)
                return NotFound();
            else
                return Ok(response);
        }
    }
}
