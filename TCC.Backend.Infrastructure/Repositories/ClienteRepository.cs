using AutoMapper;
using TCC.Backend.Domain.Entities;
using TCC.Backend.Domain.Repositories;
using TCC.Backend.Infrastructure.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TCC.Backend.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMapper _mapper;

        public ClienteRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Incluir(Cliente cliente)
        {
            // Persistir no banco
        }

        public IEnumerable<Cliente> ListarTodos()
        {
            var clientes = RepoFake.Clientes; // Recuperar do banco

            return _mapper.Map<IEnumerable<ClienteDbModel>, IEnumerable<Cliente>>(clientes);
        }

        public Cliente ObterPorId(Guid id)
        {
            var cliente = RepoFake.Clientes.Where(x => x.Id == id).FirstOrDefault(); // Recuperar do banco

            return _mapper.Map<ClienteDbModel, Cliente>(cliente);
        }

        private class RepoFake
        {
            public static IEnumerable<ClienteDbModel> Clientes
            {
                get
                {
                    return new ClienteDbModel[]
                    {
                        new ClienteDbModel()
                        {
                            Id = Guid.Parse("b5d028d5-1c11-40de-88df-832c0c0f36b9"),
                            Nome = "João",
                            Sobrenome = "Silva",
                            Email = "joaosilva@gmail.com",
                            Cpf = "12345678910",
                            Segmento = "abc123",
                            DataCriacao = new DateTime(2011, 2, 2)
                        },

                        new ClienteDbModel()
                        {
                            Id = Guid.Parse("340eefcb-c0b2-4c66-aa45-3a594e349dac"),
                            Nome = "Maria",
                            Sobrenome = "Silva",
                            Email = "mariasilva@gmail.com",
                            Cpf = "01987654321",
                            Ddd = 21,
                            Telefone = "999881122",
                            Segmento = $"xpz789",
                            DataCriacao = new DateTime(2010, 1, 1)
                        }
                    };
                }
            }
        }
    }    
}