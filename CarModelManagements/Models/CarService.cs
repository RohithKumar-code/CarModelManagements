using System.Collections.Generic;
using System.Threading.Tasks;

public class CarService : ICarService
{
    private List<Car> cars = new List<Car>
    {
        new Car { Brand = "Audi", Class = "A-Class", ModelName = "Audi A1", ModelCode = "AUDI12345", Description = "Description", Features = "Features", Price = 30000, DateOfManufacturing = DateTime.Now, Active = true, SortOrder = 1, Images = new List<string>() },
        new Car { Brand = "Jaguar", Class = "B-Class", ModelName = "Jaguar B1", ModelCode = "JAG12345", Description = "Description", Features = "Features", Price = 35000, DateOfManufacturing = DateTime.Now, Active = true, SortOrder = 2, Images = new List<string>() }
    };

    public Task<List<Car>> GetCarsAsync()
    {
        return Task.FromResult(cars);
    }

    public Task<Car> GetCarByModelCodeAsync(string modelCode)
    {
        var car = cars.Find(c => c.ModelCode == modelCode);
        return Task.FromResult(car);
    }

    public Task AddCarAsync(Car car)
    {
        cars.Add(car);
        return Task.CompletedTask;
    }

    public Task DeleteCarAsync(string modelCode)
    {
        var car = cars.Find(c => c.ModelCode == modelCode);
        if (car != null)
        {
            cars.Remove(car);
        }
        return Task.CompletedTask;
    }
}
