using System.Diagnostics;
using Automarket.DAL.Interfaces;
using Automarket.DAL.Repositories;
using Automarket.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Automarket.Models;

namespace Automarket.Controllers;

public class HomeController : Controller{


    private readonly ICarRepository _carRepository;

    public HomeController(ICarRepository carRepository){
        _carRepository = carRepository;
    }

    public async Task<IActionResult> Index(){

        
        var response = await _carRepository.GetAll();
        
        return View(response);
    }

    public IActionResult Privacy(){
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel{ RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}