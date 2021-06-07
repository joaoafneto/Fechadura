using Dapper;
using FechaduraEletronica.Borders.Entity;
using FechaduraEletronica.Borders.Repositories;
using FechaduraEletronica.Borders.Repositories.Helpers;
using System.Data;
using System.Threading.Tasks;

namespace FechaduraEletronica.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IRepositoryHelper _repositoryHelper;

        public DeviceRepository(IRepositoryHelper repositoryHelper)
        {
            _repositoryHelper = repositoryHelper;
        }

        private const string SqlCreateDevice = @"
            INSERT INTO fechadura.Dispositivo
                (criado_em,
                nome,
                desativado_em)
            values
                (current_timestamp(),
                @nome,
                NULL);";

        private const string SqlGetLastId = @"SELECT LAST_INSERT_ID()";

        private const string SqlGetDevice = @"
            select 
                d.id ,
                d.criado_em, 
                d.desativado_em, 
                d.nome 
            from Dispositivo d 
                where d.id = @id";

        private const string SqlGetDeviceByName = @"
             select 
                d.id ,
                d.criado_em, 
                d.desativado_em, 
                d.nome 
            from Dispositivo d 
            inner join Dispositivo_cliente dc 
            	on d.id = dc.dispositivo_id and dc.id = @id
            where LOWER(TRIM(TRAILING ' ' FROM d.nome)) = @nome";

        public async Task<int> Create(string nick)
        {
            using IDbConnection connection = _repositoryHelper.GetConnection();

            await connection.ExecuteAsync(SqlCreateDevice, new { nome = nick });

            return await connection.QueryFirstOrDefaultAsync<int>(SqlGetLastId);
        }

        public async Task<Device> GetDevice(int deviceId)
        {
            using IDbConnection connection = _repositoryHelper.GetConnection();

            return await connection.QueryFirstOrDefaultAsync<Device>(SqlGetDevice, new { id = deviceId });
        }

        public async Task<Device> GetDeviceByName(string name, int id)
        {
            using IDbConnection connection = _repositoryHelper.GetConnection();

            return await connection.QueryFirstOrDefaultAsync<Device>(SqlGetDeviceByName, new { nome = name , id = id});
        }
    }
}
