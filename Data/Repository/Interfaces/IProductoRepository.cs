using MVCApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCApp.Data.Repository.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>>GetAll();
        
        Task<Producto> GetById(int id);
        Task<int> Create(Producto producto);
        Task<int> Update(Producto producto);
        Task<bool> DeleteById(int id);
    }
}

