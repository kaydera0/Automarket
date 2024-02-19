using Automarket.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Automarket.DAL;

public class ApplicationDbContext : DbContext
{
    public DbSet<Car> Car{ get; set; }

    // public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
    public ApplicationDbContext(DbContextOptions options) : base(options){
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
        
        builder.Entity<Car>().HasData(new Car{
            Id = 1,
            Name = "BMW",
            Description = "qweqwewq",
            Model = "i128",
            DateCreate = DateTime.Today,
            Price = 10000,
            Speed = 250,
            TypeCar = "coupe"
        });
        
    }

    

}