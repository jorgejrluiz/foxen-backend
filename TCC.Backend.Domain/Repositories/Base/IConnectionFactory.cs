using System;
using System.Data;

namespace TCC.Backend.Domain.Repositories.Base
{
    public interface IConnectionFactory
    {
        void Begin();
        void End();
        IDbConnection GetIDbConnection();
    }
}
