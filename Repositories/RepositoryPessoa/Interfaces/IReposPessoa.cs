using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication5.Model;

namespace WebApplication5.ServicesPessoa.Interface

{
    public interface IReposPessoa
    {
        Task<PessoaModel> AddPessoaAsync(PessoaModel modelo);
        Task<PessoaModel>GetPessoaIDAsync(long id);
        Task <List<PessoaModel>> ListPessoasAsync();
    }
}