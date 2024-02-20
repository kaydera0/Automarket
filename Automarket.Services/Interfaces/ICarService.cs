using Automarket.Domain.Entity;
using Automarket.Domain.Response;

namespace Automarket.Services.Interfaces;

public interface ICarService
{

    Task<BaseResponse<IEnumerable<Car>>> GetCars();

}