using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using TCC.Backend.Domain.Repositories.Base;

namespace TCC.Backend.Infrastructure.Repositories.Base
{
    public class DbAccessHelper : IDbAccessHelper
    {
        #region "Propriedades e variáveis"

        public readonly IConnectionFactory _connectionFactory;

        #endregion

        #region Constructor

        public DbAccessHelper(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #endregion

        #region "Métodos Query"

        public async Task<IEnumerable<T>> Query<T>(string sql)
        {
            using var conexao = _connectionFactory.GetIDbConnection();
            return await Dapper.SqlMapper.QueryAsync<T>(conexao, sql, null, null, null, null);
        }

        public async Task<IEnumerable<T>> Query<T>(string sql, object parametro, int? timeoutComando = null, CommandType? tipoComando = null)
        {
            using var conexao = _connectionFactory.GetIDbConnection();
            return await Dapper.SqlMapper.QueryAsync<T>(conexao, sql, parametro, null, timeoutComando, tipoComando);
        }

        public async Task<IEnumerable<TPai>> QueryComListaFilho<TPai, TFilho>(string sql, object parametros, string colunaDemarcacao,
            Func<TPai, TFilho, Dictionary<object, TPai>, TPai> funcaoMapeamento)
        {
            using var conexao = _connectionFactory.GetIDbConnection();
            Dictionary<object, TPai> pais = new Dictionary<object, TPai>();

            await Dapper.SqlMapper.QueryAsync<TPai, TFilho, TPai>(conexao, sql, (pai, filho) =>
            {
                return funcaoMapeamento(pai, filho, pais);
            }, parametros, splitOn: colunaDemarcacao);

            return pais.Values;
        }

        #endregion

        #region "Métodos Execute"

        public async Task<int> ExecuteAsync(string sql, object parametro, IDbTransaction transaction, int? commandTimeout, CommandType? commandType)
        {
            using var conexao = _connectionFactory.GetIDbConnection();
            using (var contexto = CallContext.Instance)
            {
                if (contexto.CallerMetadata != null)
                {
                    contexto.HistoryCallback(conexao, sql, parametro);
                }
            }
            return await Dapper.SqlMapper.ExecuteAsync(conexao, sql, parametro, transaction, commandTimeout, commandType);
        }

        public async Task<int> ExecuteAsync(string sql, object parametro)
        {
            return await ExecuteAsync(sql, parametro, null, null, null);
        }

        public async Task<int> ExecuteAsync(string sql, object parametro, CommandType tipoComando)
        {
            return await ExecuteAsync(sql, parametro, null, null, tipoComando);
        }

        public async Task<int> ExecuteRetornandoIdentity(string sql, object parametro)
        {
            using var conexao = _connectionFactory.GetIDbConnection();
            using (var contexto = CallContext.Instance)
            {
                if (contexto.CallerMetadata != null)
                {
                    contexto.HistoryCallback(conexao, sql, parametro);
                }
            }

            sql = string.Concat(sql, " \nSELECT @@IDENTITY AS int");

            return await Dapper.SqlMapper.ExecuteScalarAsync<int>(conexao, sql, parametro);
        }

        #endregion

        #region "Métodos Para Criação de SQL Condicional"
        public string MontarWhereSQLCondicional(List<String> sqlParametros)
        {
            if (sqlParametros.Count > 0)
            {
                StringBuilder query = new StringBuilder();

                query.Append(" WHERE ");
                query.Append(String.Join(" AND ", sqlParametros));

                return query.ToString();
            }
            return "";
        }

        public string MontarJoins(List<String> sqlJoins)
        {
            if (sqlJoins.Count > 0)
            {
                StringBuilder query = new StringBuilder();

                query.Append(String.Join(" ", sqlJoins));

                return query.ToString();
            }
            return "";
        }
        #endregion
    }
}
