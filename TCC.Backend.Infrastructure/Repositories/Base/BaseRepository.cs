using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TCC.Backend.Domain.Repositories.Base;

namespace TCC.Backend.Infrastructure.Repositories.Base
{
    [ExcludeFromCodeCoverage]
    public class BaseRepository<TObject> : DbAccessHelper
    {
        protected BaseRepository(IConnectionFactory connectionFactory) : base(connectionFactory) { }

        public async Task<List<TObject>> Listar(string sql, object parametros, int? commandTimeout)
        {
            List<TObject> lista = TrimStrings(await Query<TObject>(sql, parametros, commandTimeout: commandTimeout)).ToList();
            return lista;
        }

        public async Task<List<TObject>> Listar(string sql, object parametros)
        {
            List<TObject> lista = TrimStrings(await Query<TObject>(sql, parametros)).ToList();
            return lista;
        }

        public async Task<TObject> Obter(string sql, object parametros)
        {
            TObject ret = TrimStrings(await Query<TObject>(sql, parametros)).FirstOrDefault();
            return ret;
        }

        public async Task<T> Obter<T>(string sql, object parametros)
        {
            T ret = TrimStrings(await Query<T>(sql, parametros)).FirstOrDefault();
            return ret;
        }

        public async Task<IEnumerable<T>> Query<T>(string sql, object parametros)
        {
            return TrimStrings(await base.Query<T>(sql, parametros));
        }

        public async Task<IEnumerable<T>> Query<T>(string sql, object parametros, int? commandTimeout)
        {
            return TrimStrings(await base.Query<T>(sql, parametros, timeoutComando: commandTimeout));
        }

        public new async Task<IEnumerable<TPai>> QueryComListaFilho<TPai, TFilho>(string sql, object parametros, string colunaDemarcacao,
            Func<TPai, TFilho, Dictionary<object, TPai>, TPai> funcaoMapeamento)
        {
            return await base.QueryComListaFilho(sql, parametros, colunaDemarcacao, funcaoMapeamento);
        }

        public async Task<int> Execute(string sql, object parametros)
        {
            return await base.ExecuteAsync(sql, parametros);
        }

        #region Métodos Privados
        private static IEnumerable<T> TrimStrings<T>(IEnumerable<T> objetos)
        {
            var propriedadesTipoString = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.PropertyType == typeof(string) && x.CanRead && x.CanWrite);
            foreach (var prop in propriedadesTipoString)
            {
                foreach (var obj in objetos)
                {
                    var valor = (string)prop.GetValue(obj);
                    var valorTrim = SafeTrim(valor);
                    prop.SetValue(obj, valorTrim);
                }
            }
            return objetos;
        }

        private static string SafeTrim(string original)
        {
            if (original == null)
            {
                return null;
            }
            return original.Trim();
        }
        #endregion
    }
}
