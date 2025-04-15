using BusinessGenesis.DAL;
using BusinessGenesis.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BusinessGenesis.Services
{
    public class AliadosClaveService
    {
        private readonly GenesisContex _context;

        public AliadosClaveService(GenesisContex context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.AliadosClaves.AnyAsync(a => a.Id == Id);
        }

        public async Task<bool> Agregar(AliadosClaves aliadosClaves)
        {
            _context.AliadosClaves.Add(aliadosClaves);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(AliadosClaves aliadosClaves)
        {
            _context.Update(aliadosClaves);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(AliadosClaves aliadosClaves)
        {
            if (!await Verificar(aliadosClaves.Id))
                return await Agregar(aliadosClaves);
            else
                return await Modificar(aliadosClaves);
        }

        public async Task<bool> Eliminar(AliadosClaves aliadosClaves)
        {
            var cantidad = await _context.AliadosClaves
                .Where(c => c.Id == aliadosClaves.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<AliadosClaves?> Buscar(int Id)
        {
            return await _context.AliadosClaves
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<AliadosClaves>> Listar(Expression<Func<AliadosClaves, bool>> criterio)
        {
            return await _context.AliadosClaves
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
