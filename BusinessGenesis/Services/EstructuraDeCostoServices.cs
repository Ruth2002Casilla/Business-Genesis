using BusinessGenesis.DAL;
using BusinessGenesis.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BusinessGenesis.Services
{
    public class EstructuraDeCostoServices
    {
        private readonly GenesisContex _context;

        public EstructuraDeCostoServices(GenesisContex context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.EstructuraDeCostos.AnyAsync(a => a.Id == Id);
        }

        public async Task<bool> Agregar(EstructuraDeCostos estructuraDeCostos)
        {
            _context.EstructuraDeCostos.Add(estructuraDeCostos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(EstructuraDeCostos estructuraDeCostos)
        {
            _context.Update(estructuraDeCostos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(EstructuraDeCostos estructuraDeCostos)
        {
            if (!await Verificar(estructuraDeCostos.Id))
                return await Agregar(estructuraDeCostos);
            else
                return await Modificar(estructuraDeCostos);
        }

        public async Task<bool> Eliminar(EstructuraDeCostos estructuraDeCostos)
        {
            var cantidad = await _context.EstructuraDeCostos
                .Where(c => c.Id == estructuraDeCostos.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<EstructuraDeCostos?> Buscar(int Id)
        {
            return await _context.EstructuraDeCostos
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<EstructuraDeCostos>> Listar(Expression<Func<EstructuraDeCostos, bool>> criterio)
        {
            return await _context.EstructuraDeCostos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
