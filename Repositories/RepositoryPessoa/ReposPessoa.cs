using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Context;
using WebApplication5.Model;
using WebApplication5.ServicesPessoa.Interface;

namespace WebApplication5.ServicesPessoa
{
    public class ReposPessoa : IReposPessoa
    {

        private readonly PessoaContext _context;

        public ReposPessoa(PessoaContext context)
        {
            _context = context;
        }

        public async Task<PessoaModel> AddPessoaAsync(PessoaModel modelo)
        {
            await _context.Pessoa.AddAsync(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<PessoaModel> GetPessoaIDAsync(long id)
        {
            return await _context.Pessoa.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<PessoaModel>> ListPessoasAsync()
        {
            return await _context.Pessoa.ToListAsync();
        }

        public async Task<string> DeletarPessoaAsync(long id)
        {
            var pessoa = _context.Pessoa.Where(w => w.Id == id);

            if (pessoa != null)
            {
                _context.Pessoa.Remove(pessoa.FirstOrDefault());
                await _context.SaveChangesAsync();
                return "Exclusão realizada com sucesso!";
            }
            else
            {
                return "Pessoa não encontrada";
            }

        }
    }
}
