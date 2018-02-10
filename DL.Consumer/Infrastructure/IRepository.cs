using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL.Consumer.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAsync();

        Task<T> GetAsync(int id);

        Task<T> Insert(T t);

        Task<bool> UpdateAsync(T t);

        Task<bool> DeleteAsync(int id);
    }
}
