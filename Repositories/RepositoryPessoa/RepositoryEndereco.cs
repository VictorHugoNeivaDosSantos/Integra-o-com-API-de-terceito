using System.Threading.Tasks;
using WebApplication5.Context;
using WebApplication5.Model;

namespace WebApplication5.Repositories.RepositoryPessoa
{
    public class RepositoryEndereco : IRepositoryEndereco
    {
        private readonly PessoaContext _context;
        public RepositoryEndereco(PessoaContext context)
        {
            _context = context;
        }

        public async Task<long> AddEnderecoAsync(CEPModel cepModel)
        {
            await _context.Endereco.AddAsync(cepModel);
            await _context.SaveChangesAsync();
            return cepModel.Id;
        }

    }
}
