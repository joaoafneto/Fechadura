using FechaduraEletronica.Borders.Dto;
using FechaduraEletronica.Borders.Entity;
using System.Threading.Tasks;

namespace FechaduraEletronica.Borders.Repositories
{
    public interface IClientRepository
    {
        Task<int> Create(ClientDto clientDto);
        Task<Client> Login(GetClientRequest request);
        Task<int> GetId();
        Task<Client> GetClient(int clientId);
    }
}
