using Cert.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cert.Core.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto> GetByIdAsync(int id);
        Task<Producto> AddAsync(Producto producto);
        Task UpdateAsync(Producto producto);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateCantidadAsync(int id, int cantidad);
    }
}
