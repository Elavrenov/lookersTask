using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Car>> GetAllItemsAsync();
        Task<Car> GetItemByIdAsync(string id);
    }
}