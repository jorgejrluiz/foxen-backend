using AutoMapper;
using TCC.Backend.Application.Models;
using TCC.Backend.Domain.Entities;
using TCC.Backend.Domain.ValueObjects;

namespace TCC.Backend.Application.Mapping
{
    public class ClienteMap : Profile
    {
        public ClienteMap()
        {
            CreateMap<Cliente, ClienteModel>()
                .ForMember(dest => dest.Nome, m => m.MapFrom(src => src.Nome.PrimeiroNome))
                .ForMember(dest => dest.Sobrenome, m => m.MapFrom(src => src.Nome.Sobrenome))
                .ForMember(dest => dest.Cpf, m => m.MapFrom(src => src.Cpf.ToString()))
                .ForMember(dest => dest.Ddd, m => m.MapFrom(src => src.Telefone.Ddd))
                .ForMember(dest => dest.Telefone, m => m.MapFrom(src => src.Telefone.Numero))
                .ForMember(dest => dest.Email, m => m.MapFrom(src => src.Email.ToString()));

            CreateMap<ClienteModel, Cliente>()
                .ForMember(dest => dest.Nome, m => m.Ignore())
                .ForMember(dest => dest.Cpf, m => m.Ignore())
                .ForMember(dest => dest.Email, m => m.Ignore())
                .ForMember(dest => dest.Telefone, m => m.MapFrom(src => src.Ddd.HasValue ? new Telefone(src.Ddd.Value, src.Telefone) : null))
                .ConstructUsing(src =>
                    new Cliente(
                        new Nome(src.Nome, src.Sobrenome),
                        new CPF(src.Cpf),
                        new Email(src.Email),
                        src.Segmento)
                    );
        }
    }
}
