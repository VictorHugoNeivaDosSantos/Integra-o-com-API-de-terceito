using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication5.Cliente.Interface;
using WebApplication5.Model;
using WebApplication5.Services.PessoaServices.Interface;
using WebApplication5.ServicesPessoa.Interface;

namespace WebApplication5.Services.PessoaServices
{
    public class ServicePessoa : IReposPessoa, IServicePessoa
    {
        private readonly IviaCEP _viacep;
        private readonly IReposPessoa _pessoa;

        public ServicePessoa(IviaCEP viacep, IReposPessoa pessoa)
        {
            _viacep = viacep;
            _pessoa = pessoa;
        }

        public async Task<PessoaModel> AddPessoaAsync(PessoaModel modelo)
        {
            string readStream = await _viacep.GetEnderecoAsync(modelo.CEP);
            var validation = JsonConvert.DeserializeObject<PessoaModel>(readStream);
            modelo.UF = validation.UF;
            modelo.Rua = validation.Rua;
            modelo.Cidade = validation.Cidade;
            modelo.Bairro = validation.Bairro;         
            await _pessoa.AddPessoaAsync(modelo);
            return modelo;
        }


        public Task<PessoaModel> GetPessoaIDAsync(long id)
        {
            return _pessoa.GetPessoaIDAsync(id);
        }

        public Task<List<PessoaModel>> ListPessoasAsync()
        {
            return _pessoa.ListPessoasAsync();
        }
    }
}
