using Automarket.Domain.Entity;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;

namespace Automarket.Services.Interfaces;

public interface ICarService
{

    Task<BaseResponse<IEnumerable<Car>>> GetCars();
    Task<BaseResponse<Car>> GetCar(int id);
    Task<BaseResponse<Car>> GetCarByName(string name);
    Task<BaseResponse<bool>> DeleteCar(int id);
    Task<BaseResponse<bool>> CreateCar(CarViewModel carViewModel);
    Task<BaseResponse<Car>> Edit(int id, CarViewModel model);

}