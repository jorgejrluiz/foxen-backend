using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace TCC.Backend.Infrastructure.Repositories.Base
{
    [ExcludeFromCodeCoverage]
    public class CallContext : IDisposable
    {
        [ThreadStatic]
        private static CallContext _instance;
        [ThreadStatic]
        private static int _instanceCounter;

        public Action<IDbConnection, string, object> HistoryCallback { get; set; }
        public Attribute CallerMetadata { get; set; }

        public static CallContext Instance
        {
            get
            {
                if (_instanceCounter++ == 0)
                {
                    _instance = new CallContext();
                }
                return _instance;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
