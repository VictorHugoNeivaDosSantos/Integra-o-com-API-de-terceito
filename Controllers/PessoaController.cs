using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication5.Dto.Pessoa;
using WebApplication5.Model;
using WebApplication5.Services.PessoaServices.Interface;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("pessoa")]
    public class PessoaController : ControllerBase
    {

        private readonly IServicePessoa _servicePessoa;

        public PessoaController(IServicePessoa servicePessoa)
        {
            _servicePessoa = servicePessoa;
        }

        [HttpPost]
        public async Task<PessoaModel> AddPessoa([FromBody] PessoaModel pessoa)
        {
            return await _servicePessoa.AddPessoaAsync(pessoa);
        }

        [HttpGet("{id}")]
        public async Task<PessoaModel> GetPessoa(long id)
        {
            return await _servicePessoa.GetPessoaIDAsync(id);
        }

        [HttpGet("lista")]
        public async Task<List<PessoaModel>> Listagem()
        {
            return await _servicePessoa.ListPessoasAsync();
        }

        [HttpDelete("{id}")]
        public async Task<string> DeletarPessoa(long id)
        {
            return await _servicePessoa.DeletarPessoaAsync(id);
        }

        [HttpPut("{id}")]
        public async Task EditarPessoa([FromRoute] long id, [FromBody] PessoaEditDto pessoa)
        {
            await _servicePessoa.EditarPessoa(id, pessoa);
        }

    }
}
