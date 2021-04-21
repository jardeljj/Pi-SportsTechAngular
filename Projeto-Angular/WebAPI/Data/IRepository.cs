using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data{
public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Departamento
        Task<Departamento[]> GetAllDepartamentosAsync(bool includeFuncionario);        
        Task<Departamento> GetDepartamentoAsyncById(int departamentoid, bool includeFuncionario);
        
        //Funcionario
        Task<Funcionario[]> GetAllFuncionariosAsync(bool includeDepartamento);
        Task<Funcionario> GetFuncionarioAsyncById(int funcionarioid, bool includeDepartamentos);
    }
}