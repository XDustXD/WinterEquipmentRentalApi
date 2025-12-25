namespace WinterEquipmentRentalApi.Repostitory.Abstraction;

public interface IRepository<T>
{
    Task<T?> GetById(string id);
    Task<IEnumerable<T>> GetAll();
    Task<string> Add(T entity);
    Task<bool> Remove(string id);
    Task<bool> Update(T entity);
}
