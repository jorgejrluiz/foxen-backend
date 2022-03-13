using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace TCC.Backend.Domain.Repositories.Base
{
    public interface IDbAccessHelper
    {
        Task<IEnumerable<T>> Query<T>(string sql);
        Task<IEnumerable<T>> Query<T>(string sql, object parametro, int? timeoutComando = null, CommandType? tipoComando = null);
        Task<int> ExecuteAsync(string sql, object parametro, IDbTransaction transaction, int? commandTimeout, CommandType? commandType);
        Task<int> ExecuteAsync(string sql, object parametro);
        Task<int> ExecuteAsync(string sql, object parametro, CommandType tipoComando);
        Task<int> ExecuteRetornandoIdentity(string sql, object parametro);
        string MontarWhereSQLCondicional(List<String> sqlParametros);
        string MontarJoins(List<String> sqlJoins);
    }
}
