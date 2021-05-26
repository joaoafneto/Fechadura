using System.Data;

namespace FechaduraEletronica.Borders.Repositories.Helpers
{
    public interface IRepositoryHelper
    {
        IDbConnection GetConnection();
    }
}
