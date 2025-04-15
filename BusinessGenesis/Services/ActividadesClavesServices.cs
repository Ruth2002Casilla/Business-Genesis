using System.Linq.Expressions;
using BusinessGenesis.DAL;
using BusinessGenesis.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessGenesis.Services
{
    public class ActividadesClavesServices
    {
        private readonly GenesisContex _context;

        public ActividadesClavesServices(GenesisContex context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.ActividadesClaves.AnyAsync(a => a.Id == Id);
        }

        public async Task<bool> Agregar(ActividadesClaves actividadesClaves)
        {
            _context.ActividadesClaves.Add(actividadesClaves);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(ActividadesClaves actividadesClaves)
        {
            _context.Update(actividadesClaves);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(ActividadesClaves actividadesClaves)
        {
            if (!await Verificar(actividadesClaves.Id))
                return await Agregar(actividadesClaves);
            else
                return await Modificar(actividadesClaves);
        }

        public async Task<bool> Eliminar(ActividadesClaves actividadesClaves)
        {
            var cantidad = await _context.ActividadesClaves
                .Where(c => c.Id == actividadesClaves.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<ActividadesClaves?> Buscar(int Id)
        {
            return await _context.ActividadesClaves
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<ActividadesClaves>> Listar(Expression<Func<ActividadesClaves, bool>> criterio)
        {
            return await _context.ActividadesClaves
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}

