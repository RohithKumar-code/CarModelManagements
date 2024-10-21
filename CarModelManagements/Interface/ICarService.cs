using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICarService
{
    Task<List<Car>> GetCarsAsync();
    Task<Car> GetCarByModelCodeAsync(string modelCode);
    Task AddCarAsync(Car car);
    Task DeleteCarAsync(string modelCode);
}