using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Data.Repositories;
using NetCoreApi.Model;

namespace NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAllCars()
        {
            return Ok(await _carRepository.GetAllCars());
        }

        [HttpGet("{ id }")]
        public async Task<IActionResult> getCarDetails(int id)
        {
            return Ok(await _carRepository.GetCarDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> createCar([FromBody] Car car)
        {
            if (car == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _carRepository.InsertCar(car);
            return Created("created car", created);
        }

        [HttpPut]
        public async Task<IActionResult> updateCar([FromBody] Car car)
        {
            if (car == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _carRepository.UpdateCar(car);
            return NoContent();
        }

        [HttpDelete("{ id }")]
        public async Task<IActionResult> deleteCar(int id)
        {
            await _carRepository.DeleteCar(new Car { Id = id });
            return NoContent();
        }
    }
}