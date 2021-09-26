using System.Threading.Tasks;
using WebApplication5.Model;

namespace WebApplication5.Cliente.Interface
{
    public interface IviaCEP
    {
        Task<CEPModel> GetEnderecoAsync(string cep);
    }
}