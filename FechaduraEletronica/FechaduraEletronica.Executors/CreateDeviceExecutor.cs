using FechaduraEletronica.Borders.Dto;
using FechaduraEletronica.Borders.Entity;
using FechaduraEletronica.Borders.Executors.Device;
using FechaduraEletronica.Borders.Repositories;
using System;
using System.Threading.Tasks;

namespace FechaduraEletronica.Executors
{
    public class CreateDeviceExecutor : ICreateDeviceExecutor
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IClientDeviceRepository _clientDeviceRepository;
        private readonly IClientRepository _clientRepository;

        public CreateDeviceExecutor(IDeviceRepository deviceRepository, IClientDeviceRepository clientDeviceRepository, IClientRepository clientRepository)
        {
            _deviceRepository = deviceRepository;
            _clientDeviceRepository = clientDeviceRepository;
            _clientRepository = clientRepository;
        }

        public async Task<CreateDeviceResponse> Execute(CreateDeviceRequest request)
        {
            try
            {
                var deviceExist = await _deviceRepository.GetDeviceByName(request.Nick.Trim().ToLower(), request.ClientId);

                if (deviceExist != null)
                {
                    Task<Client> client = _clientRepository.GetClient(request.ClientId);
                    int deviceId = await _deviceRepository.Create(request.Nick, request.BluetoothId);
                    Task<Device> device = _deviceRepository.GetDevice(deviceId);

                    await _clientDeviceRepository.Create(await client, await device);

                    return new CreateDeviceResponse { DeviceId = deviceId };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
