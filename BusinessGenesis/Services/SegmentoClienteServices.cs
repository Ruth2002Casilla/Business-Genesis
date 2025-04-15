using BusinessGenesis.DAL;
using BusinessGenesis.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BusinessGenesis.Services
{
    public class SegmentoClienteServices
    {
        private readonly GenesisContex _context;

        public SegmentoClienteServices(GenesisContex context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.SegmentoCliente.AnyAsync(a => a.Id == Id);
        }

        public async Task<bool> Agregar(SegmentoCliente segmentoCliente)
        {
            _context.SegmentoCliente.Add(segmentoCliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(SegmentoCliente segmentoCliente)
        {
            _context.Update(segmentoCliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(SegmentoCliente segmentoCliente)
        {
            if (!await Verificar(segmentoCliente.Id))
                return await Agregar(segmentoCliente);
            else
                return await Modificar(segmentoCliente);
        }

        public async Task<bool> Eliminar(SegmentoCliente segmentoCliente)
        {
            var cantidad = await _context.SegmentoCliente
                .Where(c => c.Id == segmentoCliente.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<SegmentoCliente?> Buscar(int Id)
        {
            return await _context.SegmentoCliente
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<SegmentoCliente>> Listar(Expression<Func<SegmentoCliente, bool>> criterio)
        {
            return await _context.SegmentoCliente
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
