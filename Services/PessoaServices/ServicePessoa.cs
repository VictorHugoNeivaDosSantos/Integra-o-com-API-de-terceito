using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication5.Cliente.Interface;
using WebApplication5.Dto.Pessoa;
using WebApplication5.Model;
using WebApplication5.Repositories.RepositoryPessoa;
using WebApplication5.Services.PessoaServices.Interface;
using WebApplication5.ServicesPessoa.Interface;

namespace WebApplication5.Services.PessoaServices
{
    public class ServicePessoa : IServicePessoa
    {
        private readonly IviaCEP _viacep;
        private readonly IReposPessoa _pessoa;
        private readonly IRepositoryEndereco _endereco;
        private readonly IMapper _mapper;


        public ServicePessoa(IviaCEP viacep, IReposPessoa pessoa, IRepositoryEndereco endereco, IMapper mapper)
        {
            _viacep = viacep;
            _pessoa = pessoa;
            _endereco = endereco;
            _mapper = mapper;
        }

        public async Task<PessoaModel> AddPessoaAsync(PessoaModel modelo)
        {
            if (modelo.CEP != null)
            {
                var endereco = await _viacep.GetEnderecoAsync(modelo.CEP);
                modelo.EnderecoId = await _endereco.AddEnderecoAsync(endereco);
            }
            await _pessoa.AddPessoaAsync(modelo);
            return modelo;
        }

        public Task<string> DeletarPessoaAsync(long id)
        {
            return _pessoa.DeletarPessoaAsync(id);
        }

        public Task<PessoaModel> GetPessoaIDAsync(long id)
        {
            return _pessoa.GetPessoaIDAsync(id);
        }

        public Task<List<PessoaModel>> ListPessoasAsync()
        {
            return _pessoa.ListPessoasAsync();
        }

        public async Task EditarPessoa(long id, PessoaEditDto edit)
        {
            var pessoa = await GetPessoaIDAsync(id);
            _mapper.Map(edit, pessoa);
            await _pessoa.EditarPessoa(pessoa);
        }
    }
}
