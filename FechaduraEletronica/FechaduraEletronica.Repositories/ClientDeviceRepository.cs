using Dapper;
using FechaduraEletronica.Borders.Entity;
using FechaduraEletronica.Borders.Repositories;
using FechaduraEletronica.Borders.Repositories.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FechaduraEletronica.Repositories
{
    public class ClientDeviceRepository : IClientDeviceRepository
    {
        private readonly IRepositoryHelper _repositoryHelper;

        public ClientDeviceRepository(IRepositoryHelper repositoryHelper)
        {
            _repositoryHelper = repositoryHelper;
        }

        private const string SqlCreate = @"
            INSERT INTO fechadura.Dispositivo_cliente
                (dispositivo_id,
                cliente_id,
                criado_em)
            VALUES(
                @dispositivo_id,
                @cliente_id,
                current_timestamp())";


        private const string SqlGet = @"
            SELECT 
                id, 
                dispositivo_id, 
                cliente_id, 
                criado_em, 
                desativado_em
            FROM fechadura.Dispositivo_cliente
            WHERE cliente_id = @cliente_id";

        public async Task Create(Client client, Device device)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@dispositivo_id", device.id, DbType.Int32);
            param.Add("@cliente_id", client.id, DbType.Int32);

            using IDbConnection connection = _repositoryHelper.GetConnection();

            await connection.ExecuteAsync(SqlCreate, new { dispositivo_id = device.id, cliente_id = client.id });
        }

        public async Task<List<ClientDevice>> GetDevices(int clientId)
        {
            using IDbConnection connection = _repositoryHelper.GetConnection();

            return (await connection.QueryAsync<ClientDevice>(SqlGet, new { cliente_id = clientId })).ToList();
        }
    }
}
