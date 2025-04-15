using BusinessGenesis.DAL;
using BusinessGenesis.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BusinessGenesis.Services
{
    public class PropuestaValorServices
    {
        private readonly GenesisContex _context;

        public PropuestaValorServices(GenesisContex context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.PropuestaValor.AnyAsync(a => a.Id == Id);
        }

        public async Task<bool> Agregar(PropuestaValor propuestaValor)
        {
            _context.PropuestaValor.Add(propuestaValor);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(PropuestaValor propuestaValor)
        {
            _context.Update(propuestaValor);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(PropuestaValor propuestaValor)
        {
            if (!await Verificar(propuestaValor.Id))
                return await Agregar(propuestaValor);
            else
                return await Modificar(propuestaValor);
        }

        public async Task<bool> Eliminar(PropuestaValor propuestaValor)
        {
            var cantidad = await _context.PropuestaValor
                .Where(c => c.Id == propuestaValor.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<PropuestaValor?> Buscar(int Id)
        {
            return await _context.PropuestaValor
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<PropuestaValor>> Listar(Expression<Func<PropuestaValor, bool>> criterio)
        {
            return await _context.PropuestaValor
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
