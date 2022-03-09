using TCC.Backend.Application.Models;
using TCC.Backend.Domain.Entities;

namespace TCC.Backend.Application.Interfaces
{
    public interface IClienteApplication
    {
        Result<Cliente> Salvar(ClienteModel clienteModel);
    }
}