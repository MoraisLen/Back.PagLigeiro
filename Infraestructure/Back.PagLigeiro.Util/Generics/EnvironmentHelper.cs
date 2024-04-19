using Microsoft.Extensions.Configuration;
using System;

namespace Back.PagLigeiro.Util.Generics
{
    public class EnvironmentHelper
    {
        public static string getConnectionString(IConfiguration settings)
        {
            string environment = settings["Database:Environment"];

            // Configurar string de conexão nas variáveis de ambiente com o nome DbNetConn ou no appsettings.json
            string connection = Environment.GetEnvironmentVariable("DbNetConn") ?? settings[$"Database:ConnectionString:{environment}"];

            if (string.IsNullOrWhiteSpace(connection))
                throw new Exception("Nenhuma string de conexão encontrada no .config ou na variável de ambiente DbNetConn");

            return connection;
        }
    }
}