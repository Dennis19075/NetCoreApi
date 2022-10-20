using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreApi.Model;

namespace NetCoreApi.Data.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetCarDetails(int id);
        Task<bool> InsertCar(Car car);
        Task<bool> UpdateCar(Car car);
        Task<bool> DeleteCar(Car car);
    }
}

