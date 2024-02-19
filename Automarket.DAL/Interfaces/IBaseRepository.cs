using Automarket.Domain.Entity;

namespace Automarket.DAL.Interfaces;

public interface IBaseRepository<T>{

    Task<bool> Create(T entity);

    Task<Car> Get(int id);
    // T Get(int id);

    Task<List<Car>> Select();

    Task<bool> Delete(T entity);



}