using Automarket.Domain.Entity;

namespace Automarket.DAL.Interfaces;

public interface IBaseRepository<T>{

    Task<bool> Create(T entity);

    Task<Car> Get(int id);
    // T Get(int id);

    IQueryable<T> GetAll();
    // Task<List<Car>> GetAll();

    Task<bool> Delete(T entity);

    Task<T> Update(T entity);



}