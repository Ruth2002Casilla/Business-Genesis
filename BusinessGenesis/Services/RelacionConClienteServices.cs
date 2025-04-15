using BusinessGenesis.DAL;
using BusinessGenesis.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BusinessGenesis.Services
{
    public class RelacionConClienteServices
    {
        private readonly GenesisContex _context;

        public RelacionConClienteServices(GenesisContex context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.RelacionConClientes.AnyAsync(a => a.Id == Id);
        }

        public async Task<bool> Agregar(RelacionConClientes relacionConClientes)
        {
            _context.RelacionConClientes.Add(relacionConClientes);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(RelacionConClientes relacionConClientes)
        {
            _context.Update(relacionConClientes);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(RelacionConClientes relacionConClientes)
        {
            if (!await Verificar(relacionConClientes.Id))
                return await Agregar(relacionConClientes);
            else
                return await Modificar(relacionConClientes);
        }

        public async Task<bool> Eliminar(RelacionConClientes relacionConClientes)
        {
            var cantidad = await _context.RelacionConClientes
                .Where(c => c.Id == relacionConClientes.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<RelacionConClientes?> Buscar(int Id)
        {
            return await _context.RelacionConClientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<RelacionConClientes>> Listar(Expression<Func<RelacionConClientes, bool>> criterio)
        {
            return await _context.RelacionConClientes
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
