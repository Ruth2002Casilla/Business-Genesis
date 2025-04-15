using BusinessGenesis.DAL;
using BusinessGenesis.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BusinessGenesis.Services
{
    public class EmpresaServices
    {
        private readonly GenesisContex _context;

        public EmpresaServices(GenesisContex context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.Empresa.AnyAsync(a => a.Id == Id);
        }

        public async Task<bool> Agregar(Empresa empresa)
        {
            _context.Empresa.Add(empresa);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Empresa empresa)
        {
            _context.Update(empresa);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Empresa empresa)
        {
            if (!await Verificar(empresa.Id))
                return await Agregar(empresa);
            else
                return await Modificar(empresa);
        }

        public async Task<bool> Eliminar(Empresa empresa)
        {
            var cantidad = await _context.Empresa
                .Where(c => c.Id == empresa.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Empresa?> Buscar(int Id)
        {
            return await _context.Empresa
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<Empresa>> Listar(Expression<Func<Empresa, bool>> criterio)
        {
            return await _context.Empresa
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
