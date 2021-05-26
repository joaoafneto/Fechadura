using FechaduraEletronica.Borders.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FechaduraEletronica.Borders.Repositories
{
    public interface IClientDeviceRepository
    {
        Task Create(Client client, Device device);
        Task<List<ClientDevice>> GetDevices(int clientId);
    }
}
