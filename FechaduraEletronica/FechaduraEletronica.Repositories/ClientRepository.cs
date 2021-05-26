using Dapper;
using FechaduraEletronica.Borders.Dto;
using FechaduraEletronica.Borders.Entity;
using FechaduraEletronica.Borders.Repositories;
using FechaduraEletronica.Borders.Repositories.Helpers;
using System.Data;
using System.Threading.Tasks;

namespace FechaduraEletronica.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IRepositoryHelper _repositoryHelper;

        public ClientRepository(IRepositoryHelper repositoryHelper)
        {
            _repositoryHelper = repositoryHelper;
        }

        private const string SqlLogin = @"
            select 
                c.id,
                c.bairro,
                c.cep,
                c.cpf,
                c.criado_em,
                c.email,
                c.logradouro,
                c.nome,
                c.numero,
                c.cidade,
                c.uf,
                c.senha
            from Cliente c 
            where c.cpf = @cpf
            and c.senha = @senha";

        private const string SqlCreate = @"
            INSERT INTO fechadura.Cliente
                (nome,
                email, 
                cpf, 
                logradouro, 
                numero, 
                bairro, 
                cep, 
                cidade, 
                uf,
                senha, 
                criado_em)
            VALUES(
                @nome,
                @email,
                @cpf,
                @logradouro, 
                @numero, 
                @bairro,
                @cep,
                @cidade,
                @uf,
                @senha, 
                current_timestamp())";

        private const string SqlGetId = @"SELECT MAX(c.id) FROM Cliente c";

        private const string SqlGetClient = @"
            select
                c.id,
                c.bairro,
                c.cep,
                c.cpf,
                c.criado_em,
                c.email,
                c.logradouro,
                c.nome,
                c.numero,
                c.uf 
            from Cliente c 
            where c.id = @id";

        public async Task<int> Create(ClientDto clientDto)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@nome", clientDto.Name, DbType.String);
            param.Add("@email", clientDto.Email, DbType.String);
            param.Add("@cpf", clientDto.Cpf, DbType.String);
            param.Add("@logradouro", clientDto.Address, DbType.String);
            param.Add("@numero", clientDto.Number, DbType.Int32);
            param.Add("@bairro", clientDto.District, DbType.String);
            param.Add("@cep", clientDto.PostalCode, DbType.String);
            param.Add("@cidade", clientDto.City, DbType.String);
            param.Add("@uf", clientDto.UF, DbType.String);
            param.Add("@senha", clientDto.Password, DbType.String);

            using IDbConnection connection = _repositoryHelper.GetConnection();

            return await connection.ExecuteAsync(SqlCreate, param);
        }

        public async Task<Client> Login(GetClientRequest request)
        {
            using IDbConnection connection = _repositoryHelper.GetConnection();

            return await connection.QueryFirstOrDefaultAsync<Client>(SqlLogin, new { cpf = request.Cpf, senha = request.Password });
        }

        public async Task<int> GetId()
        {
            using IDbConnection connection = _repositoryHelper.GetConnection();

            return await connection.QueryFirstOrDefaultAsync<int>(SqlGetId);
        }

        public async Task<Client> GetClient(int clientId)
        {
            using IDbConnection connection = _repositoryHelper.GetConnection();

            return await connection.QueryFirstOrDefaultAsync<Client>(SqlGetClient, new { id = clientId });
        }
    }
}
