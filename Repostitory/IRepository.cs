namespace WinterEquipmentRentalApi.Repostitory;

public interface IRepository<T>
{
    Task<T?> GetById(string id);
    Task<IEnumerable<T>> GetAll();
    Task<string> Add(T entity);
    Task Remove(string id);
    Task Update(T entity);
}
