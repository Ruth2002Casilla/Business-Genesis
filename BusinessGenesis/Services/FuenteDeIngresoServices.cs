using BusinessGenesis.DAL;
using BusinessGenesis.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BusinessGenesis.Services
{
    public class FuenteDeIngresoServices
    {
        private readonly GenesisContex _context;

        public FuenteDeIngresoServices(GenesisContex context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.FuenteDeIngresos.AnyAsync(a => a.Id == Id);
        }

        public async Task<bool> Agregar(FuenteDeIngresos fuenteDeIngresos)
        {
            _context.FuenteDeIngresos.Add(fuenteDeIngresos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(FuenteDeIngresos fuenteDeIngresos)
        {
            _context.Update(fuenteDeIngresos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(FuenteDeIngresos fuenteDeIngresos)
        {
            if (!await Verificar(fuenteDeIngresos.Id))
                return await Agregar(fuenteDeIngresos);
            else
                return await Modificar(fuenteDeIngresos);
        }

        public async Task<bool> Eliminar(FuenteDeIngresos fuenteDeIngresos)
        {
            var cantidad = await _context.FuenteDeIngresos
                .Where(c => c.Id == fuenteDeIngresos.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<FuenteDeIngresos?> Buscar(int Id)
        {
            return await _context.FuenteDeIngresos
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<FuenteDeIngresos>> Listar(Expression<Func<FuenteDeIngresos, bool>> criterio)
        {
            return await _context.FuenteDeIngresos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
