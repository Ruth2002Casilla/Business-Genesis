using BusinessGenesis.DAL;
using BusinessGenesis.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BusinessGenesis.Services
{
    public class TipoProductoServices
    {
        private readonly GenesisContex _context;

        public TipoProductoServices(GenesisContex context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.TipoProductos.AnyAsync(a => a.Id == Id);
        }

        public async Task<bool> Agregar(TipoProducto tipoProducto)
        {
            _context.TipoProductos.Add(tipoProducto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(TipoProducto tipoProducto)
        {
            _context.Update(tipoProducto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(TipoProducto tipoProducto)
        {
            if (!await Verificar(tipoProducto.Id))
                return await Agregar(tipoProducto);
            else
                return await Modificar(tipoProducto);
        }

        public async Task<bool> Eliminar(TipoProducto tipoProducto)
        {
            var cantidad = await _context.TipoProductos
                .Where(c => c.Id == tipoProducto.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<TipoProducto?> Buscar(int Id)
        {
            return await _context.TipoProductos
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<TipoProducto>> Listar(Expression<Func<TipoProducto, bool>> criterio)
        {
            return await _context.TipoProductos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
