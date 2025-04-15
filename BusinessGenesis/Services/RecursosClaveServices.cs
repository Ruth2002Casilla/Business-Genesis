using BusinessGenesis.DAL;
using BusinessGenesis.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BusinessGenesis.Services
{
    public class RecursosClaveServices
    {
        private readonly GenesisContex _context;

        public RecursosClaveServices(GenesisContex context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.RecursosClaves.AnyAsync(a => a.Id == Id);
        }

        public async Task<bool> Agregar(RecursosClaves recursosClaves)
        {
            _context.RecursosClaves.Add(recursosClaves);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(RecursosClaves recursosClaves)
        {
            _context.Update(recursosClaves);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(RecursosClaves recursosClaves)
        {
            if (!await Verificar(recursosClaves.Id))
                return await Agregar(recursosClaves);
            else
                return await Modificar(recursosClaves);
        }

        public async Task<bool> Eliminar(RecursosClaves recursosClaves)
        {
            var cantidad = await _context.RecursosClaves
                .Where(c => c.Id == recursosClaves.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<RecursosClaves?> Buscar(int Id)
        {
            return await _context.RecursosClaves
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<RecursosClaves>> Listar(Expression<Func<RecursosClaves, bool>> criterio)
        {
            return await _context.RecursosClaves
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
