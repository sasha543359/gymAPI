namespace GymDbContext_.Data.Services;

public interface IBaseRepository<T>
{
    Task<List<T>> GetEntities();

    Task<T> GetEntity(int id);

    Task<T> UpdateEntity(T entity, int id);

    Task DeleteEntity(int id);

    Task<T> CreateEntity(T entity);
}
