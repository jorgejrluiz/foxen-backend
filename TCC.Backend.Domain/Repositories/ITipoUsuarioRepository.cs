using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Backend.Domain.Entities;

namespace TCC.Backend.Domain.Repositories
{
    public interface ITipoUsuarioRepository
    {
        Task<IEnumerable<TipoUsuario>> Listar();
    }
}
