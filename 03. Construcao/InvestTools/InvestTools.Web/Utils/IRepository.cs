namespace investTools.Web.Utils;

public interface IRepository<T, K, C> where T : AuditEntity
{
    Task<int> InsertAsync(C viewModel);
    Task<T> UpdateAsync(C viewModel);
    Task<bool> DeleteAsync(C viewModel);
    Task<T> GetByIdAsync(C viewModel);
    Task<List<T>> GetAllAsync();
    Task<bool> ExistAsync(C viewModel);

}