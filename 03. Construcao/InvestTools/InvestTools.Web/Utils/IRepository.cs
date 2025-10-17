namespace investTools.Web.Utils;

public interface IRepository<T, K, C> where T : AuditEntity
{
    Task<int> InsertAsync(C item);
    Task<T> UpdateAsync(T item);
    Task<bool> DeleteAsync(K id);
    Task<T> GetByIdAsync(K id);
    Task<List<T>> GetAllAsync();
    Task<bool> ExistAsync(K id);
}