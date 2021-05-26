using FechaduraEletronica.Borders.Repositories.Helpers;
using FechaduraEletronica.Shared.Configurations;
using MySql.Data.MySqlClient;
using System.Data;

namespace FechaduraEletronica.Repositories.Helpers
{
    public class RepositoryHelper : IRepositoryHelper
    {
        public IDbConnection GetConnection()
        {
            return new MySqlConnection(ConnectionStrings.DefaultConnection);
        }
    }
}
