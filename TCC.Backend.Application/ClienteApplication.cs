using AutoMapper;
using TCC.Backend.Application.Interfaces;
using TCC.Backend.Application.Models;
using TCC.Backend.Domain.Entities;
using TCC.Backend.Domain.Repositories;

namespace TCC.Backend.Application
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public ClienteApplication(IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public Result<Cliente> Salvar(ClienteModel clienteModel)
        {
            var cliente = _mapper.Map<ClienteModel, Cliente>(clienteModel);

            if (cliente.Valid)
            {
                _clienteRepository.Incluir(cliente);
                return Result<Cliente>.Ok(cliente);
            }

            return Result<Cliente>.Error(cliente.Notifications);
        }
    }
}
