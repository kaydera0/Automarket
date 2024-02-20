using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;
using Automarket.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Automarket.Services.Implementations;

public class CarService:ICarService
{

    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository){
        _carRepository = carRepository;
    }

    public async Task<BaseResponse<IEnumerable<Car>>> GetCars(){
        
        var baseResponse = new BaseResponse<IEnumerable<Car>>();

        try
        {
            var cars = await _carRepository.Select();
            if (cars.Count ==0)
            {
                baseResponse.Description = " zero elements were found";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            else
            {
                baseResponse.Data = cars;
                baseResponse.StatusCode = StatusCode.OK;
            }
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Car>>(){
                Description = $"[GetCars] : {e.Message} "
            };
        }
    }

    public async Task<IBaseResponse<Car>> GetCar(int id){

        var baseResponse = new BaseResponse<Car>();
        try
        {
            var car = await _carRepository.Get(id);
            if (car==null)
            {
                baseResponse.Description = "not found";
                baseResponse.StatusCode = StatusCode.NotFound;

                return baseResponse;
            }

            baseResponse.Data = car;
            return baseResponse;
        }
        catch (Exception e)
        {
            baseResponse.Description = $"[GetCar] {e.ToString()}";
            baseResponse.StatusCode = StatusCode.InternalServiceError;

            return baseResponse;
        }
    }

    public async Task<IBaseResponse<Car>> GetCarByName(string name){

        var baseResponse = new BaseResponse<Car>();
        try
        {
            var car = await _carRepository.GetByName(name);
            if (car==null)
            {
                baseResponse.Description = "not found";
                baseResponse.StatusCode = StatusCode.NotFound;

                return baseResponse;
            }

            baseResponse.Data = car;
            return baseResponse;
        }
        catch (Exception e)
        {
            baseResponse.Description = $"[GetCarByName] {e.ToString()}";
            baseResponse.StatusCode = StatusCode.InternalServiceError;

            return baseResponse;
        }
    }

    public async Task<IBaseResponse<bool>> DeleteCar(int id){

        var baseResponse = new BaseResponse<bool>();

        try
        {
            _carRepository.Delete(new Car{ Id = id });   //originally was _carRepository.Get(id)

            baseResponse.Data = true;
            return baseResponse;
        }
        catch (Exception e)
        {
            baseResponse.Description = $"[DeleteCar] {e}";
            baseResponse.StatusCode = StatusCode.InternalServiceError;

            return baseResponse;
        }
    }

    public async Task<IBaseResponse<bool>> CreateCar(CarViewModel carViewModel){ //why not just a Car?

        var baseResponse = new BaseResponse<CarViewModel>();

        try
        {
            var car = new Car(){
                Description = carViewModel.Description,
                DateCreate = DateTime.Now,
                Speed = carViewModel.Speed,
                Model = carViewModel.Model,
                Price = carViewModel.Price,
                Name = carViewModel.Name,
                TypeCar = carViewModel.TypeCar
            };
            await _carRepository.Create(car);
            return new BaseResponse<bool>(){
                Data = true,
                StatusCode = StatusCode.OK
            };

        }
        catch(Exception e)
        {
            return new BaseResponse<bool>(){
                Description = $"[CreateCar] {e}",
                StatusCode = StatusCode.InternalServiceError
            };
        }

    }
}