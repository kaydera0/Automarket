using Automarket.Domain.Enum;

namespace Automarket.Domain.Entity;

public class Car{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Model { get; set; }
    public int Speed { get; set; }
    public DateTime DateCreate { get; set; }
    public int Price { get; set; }
    public string TypeCar { get; set; }

}