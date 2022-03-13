using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Backend.Domain.Entities;
using TCC.Backend.Domain.Repositories;
using TCC.Backend.Domain.Repositories.Base;
using TCC.Backend.Infrastructure.DbModels;
using TCC.Backend.Infrastructure.Repositories.Base;
using TCC.Backend.Infrastructure.Scripts;

namespace TCC.Backend.Infrastructure.Repositories
{
    public class TipoUsuarioRepository : BaseRepository<TipoUsuarioDbModel>, ITipoUsuarioRepository
    {
        public TipoUsuarioRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<IEnumerable<TipoUsuario>> Listar()
        {
            var tiposUsuario = await Listar(TipoUsuarioScripts.LISTAR, null);

            throw new NotImplementedException();
        }
    }
}
