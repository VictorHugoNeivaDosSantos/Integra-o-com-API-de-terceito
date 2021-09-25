using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Model
{
    [Table("pessoa")]
    public class PessoaModel
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("nome")]
        public string Name { get; set; }
        [Column("cep")]
        public string CEP { get; set; }


        [Column("uf")]
        [JsonProperty("state")]
        public string UF { get; set; }

        [Column("cidade")]
        [JsonProperty("city")]
        public string Cidade { get; set; }

        [Column("bairro")]
        [JsonProperty("district")]
        public string Bairro { get; set; }

        [Column("rua")]
        [JsonProperty("address")]
        public string Rua { get; set; }

    }
}
