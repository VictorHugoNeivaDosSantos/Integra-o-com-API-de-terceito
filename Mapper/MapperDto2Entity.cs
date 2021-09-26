using AutoMapper;
using WebApplication5.Dto.Pessoa;
using WebApplication5.Model;

namespace WebApplication5.DTO
{
    public class MapperDto2Entity : Profile
    {
        public MapperDto2Entity()
        {
            CreateMap<PessoaEditDto, PessoaModel>();
        }
    }
}
