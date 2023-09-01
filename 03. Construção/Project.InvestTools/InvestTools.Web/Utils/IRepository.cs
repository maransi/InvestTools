namespace investTools.Web.Utils;

public interface IRepository<T, K> where T : BaseEntity
{
    Task<T> InsertAsync(T item);
    Task<T> UpdateAsync(T item);
    Task<bool> DeleteAsync(K id);
    Task<T> GetByIdAsync(K id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<bool> ExistAsync(K id);
}
