using Back.PagLigeiro.Util.Generics;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace Back.PagLigeiro.Infraestructure.Data.Dapper
{
    public class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }

        public DbSession(IConfiguration configuration)
        {
            Connection = new SqlConnection(EnvironmentHelper.getConnectionString(configuration));
            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();

    }
}
