using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Model;

namespace WebApplication5.Context
{
    public class PessoaContext : DbContext
    {

      public  DbSet<PessoaModel> Pessoa { get; set; }

        public PessoaContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
