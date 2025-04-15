using BusinessGenesis.DAL;
using BusinessGenesis.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BusinessGenesis.Services
{
    public class CanalServices
    {
        private readonly GenesisContex _context;

        public CanalServices(GenesisContex context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.Canales.AnyAsync(a => a.Id == Id);
        }

        public async Task<bool> Agregar(Canales canales)
        {
            _context.Canales.Add(canales);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Canales canales)
        {
            _context.Update(canales);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Canales canales)
        {
            if (!await Verificar(canales.Id))
                return await Agregar(canales);
            else
                return await Modificar(canales);
        }

        public async Task<bool> Eliminar(Canales canales)
        {
            var cantidad = await _context.Canales
                .Where(c => c.Id == canales.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Canales?> Buscar(int Id)
        {
            return await _context.Canales
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<Canales>> Listar(Expression<Func<Canales, bool>> criterio)
        {
            return await _context.Canales
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
