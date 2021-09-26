using System.Threading.Tasks;
using WebApplication5.Model;

namespace WebApplication5.Repositories.RepositoryPessoa
{
    public interface IRepositoryEndereco
    {
        Task<long> AddEnderecoAsync(CEPModel cepModel);
    }
}