using BusinessGenesis.DAL;
using BusinessGenesis.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BusinessGenesis.Services
{
    public class NegocioServices
    {
        private readonly GenesisContex _context;

        public NegocioServices(GenesisContex context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.Negocio.AnyAsync(a => a.Id == Id);
        }

        public async Task<bool> Agregar(Negocio negocio)
        {
            _context.Negocio.Add(negocio);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Negocio negocio)
        {
            _context.Update(negocio);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Negocio negocio)
        {
            if (!await Verificar(negocio.Id))
                return await Agregar(negocio);
            else
                return await Modificar(negocio);
        }

        public async Task<bool> Eliminar(Negocio negocio)
        {
            var cantidad = await _context.Negocio
                .Where(c => c.Id == negocio.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Negocio?> Buscar(int Id)
        {
            return await _context.Negocio
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<Negocio>> Listar(Expression<Func<Negocio, bool>> criterio)
        {
            return await _context.Negocio
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
