using Microsoft.EntityFrameworkCore;
using MVCApp.Data.Repository.Interfaces;
using MVCApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCApp.Data.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ProductosContext _context;

        public ProductoRepository(ProductosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            var productos = await _context.Productos.ToListAsync();
            return productos;
        }
        ///GetbyID
        public async  Task<Producto> GetById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            return producto;
        }
        ///Create
        public async Task<int> Create(Producto producto)
        {
            producto.FechaDeAlta = DateTime.Now;
            var newProducto = _context.Add(producto);
            return await _context.SaveChangesAsync();
            
        }
        ///Update
        public async Task<int> Update(Producto producto)
        {
            _context.Update(producto);
            return await _context.SaveChangesAsync();
        }   
        ///Delete
        public async Task<bool> DeleteById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            if (await _context.SaveChangesAsync() >= 0)
                return true;
            return false;    
        }

    }
}