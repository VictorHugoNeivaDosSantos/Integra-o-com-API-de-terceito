using System.ComponentModel.DataAnnotations.Schema;

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
        public CEPModel Endereco { get; set; }
        public long EnderecoId { get; set; }

    }
}
