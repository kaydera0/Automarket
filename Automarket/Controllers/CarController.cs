using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Automarket.Controllers;

public class CarController:Controller
{

    private readonly ICarService _carService;

    public CarController(ICarService carService){
        _carService = carService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCars(){

        
        var response = await _carService.GetCars();

        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(response.Data);
        }
        else
        {
            return RedirectToAction("Error");
        }
        
    }


    public IActionResult Error(){
        return View();
    }

}