using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.Enum;

public enum TypeCar{
    [Display(Name = "Light")]
    PassengerCar = 0,
    [Display(Name = "Sedan")]
    Sedan = 1,
    [Display(Name = "Hatch")]
    HatchBack = 2,
    [Display(Name = "Minivan")]
    Minivan = 3,
    [Display(Name = "Sport")]
    SportCar = 4,
    [Display(Name = "OffRoad")]
    Suv = 0,
    
    

}