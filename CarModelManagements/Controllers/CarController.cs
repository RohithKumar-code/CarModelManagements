using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Car>>> GetCars()
    {
        var cars = await _carService.GetCarsAsync();
        return Ok(cars);
    }

    [HttpGet("{modelCode}")]
    public async Task<ActionResult<Car>> GetCarByModelCode(string modelCode)
    {
        var car = await _carService.GetCarByModelCodeAsync(modelCode);
        if (car == null)
        {
            return NotFound();
        }
        return Ok(car);
    }

    [HttpPost]
    public async Task<ActionResult> AddCar([FromBody] Car car)
    {
        await _carService.AddCarAsync(car);
        return CreatedAtAction(nameof(GetCarByModelCode), new { modelCode = car.ModelCode }, car);
    }

    [HttpDelete("{modelCode}")]
    public async Task<ActionResult> DeleteCar(string modelCode)
    {
        await _carService.DeleteCarAsync(modelCode);
        return NoContent();
    }
}
