using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.ViewModels.Car;
using Automarket.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
            return View(response.Data.ToList());
        }
        else
        {
            return RedirectToAction("Error");
        }
        
    }


    public IActionResult Error(){
        return View();
    }

    public async Task<IActionResult> GetCar(int id){
        var response = await _carService.GetCar(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK )  
        {
            return View(response.Data);
        }

        return RedirectToAction("Error");
    }

    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCar(int id){
        var response = await _carService.DeleteCar(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("GetCars");
            
        }

        return RedirectToAction("Error");
    }

    [HttpGet]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Save(int id){

        if (id==0)
        {
            // return View();
            return View();
        }

        var response = await _carService.GetCar(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View();
            // return View(response.Data);
        }

        return RedirectToAction("Error");
    }

    [HttpPost]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Save(CarViewModel model){

        if (ModelState.IsValid)
        {
            if (model.Id==0)
            {
                await _carService.CreateCar(model);
            }
            else
            {
                await _carService.Edit(model.Id, model);
            }
        }

        return RedirectToAction("GetCars");
    }
    
}