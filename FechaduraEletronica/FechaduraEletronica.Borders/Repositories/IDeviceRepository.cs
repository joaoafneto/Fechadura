using FechaduraEletronica.Borders.Entity;
using System.Threading.Tasks;

namespace FechaduraEletronica.Borders.Repositories
{
    public interface IDeviceRepository
    {
        Task<Device> GetDevice(int deviceId);
        Task<int> Create(string nick, string bluetoothId);
        Task<Device> GetDeviceByBluetoothId(string bluetoothId, int id);
    }
}
