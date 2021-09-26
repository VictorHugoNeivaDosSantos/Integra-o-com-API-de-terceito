using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication5.Dto.Pessoa;
using WebApplication5.Model;

namespace WebApplication5.Services.PessoaServices.Interface
{
    public interface IServicePessoa
    {
        Task<PessoaModel> AddPessoaAsync(PessoaModel modelo);
        Task<PessoaModel> GetPessoaIDAsync(long id);
        Task<List<PessoaModel>> ListPessoasAsync();
        Task<string> DeletarPessoaAsync(long id);
        Task EditarPessoa(long id, PessoaEditDto edit);

    }
}