using TCC.Backend.Domain.Entities;
using System;
using System.Collections.Generic;

namespace TCC.Backend.Domain.Repositories
{
    public interface IClienteRepository
    {
        void Incluir(Cliente cliente);
        Cliente ObterPorId(Guid id);
        IEnumerable<Cliente> ListarTodos();
    }
}
