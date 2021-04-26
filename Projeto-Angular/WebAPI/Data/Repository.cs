
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data{
public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Departamento[]> GetAllDepartamentosAsync(bool includeFuncionario = false)
        {
            IQueryable<Departamento> query = _context.Departamento;

            query = query.AsNoTracking()
                         .OrderBy(c => c.id);

            return await query.ToArrayAsync();
        }


            public async Task<Departamento> GetDepartamentoAsyncById(int departamentoId, bool includeFuncionario)
        {
            IQueryable<Departamento> query = _context.Departamento;

            query = query.AsNoTracking()
                         .OrderBy(departamento => departamento.id)
                         .Where(departamento => departamento.id == departamentoId);

            return await query.FirstOrDefaultAsync();
        }




    }
}