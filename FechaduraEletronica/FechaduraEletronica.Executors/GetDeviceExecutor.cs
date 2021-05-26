using FechaduraEletronica.Borders.Dto;
using FechaduraEletronica.Borders.Entity;
using FechaduraEletronica.Borders.Executors.Device;
using FechaduraEletronica.Borders.Repositories;
using FechaduraEletronica.Borders.Shared.Converters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FechaduraEletronica.Executors
{
    public class GetDeviceExecutor : IGetDeviceExecutor
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IClientDeviceRepository _clientDeviceRepository;

        public GetDeviceExecutor(IDeviceRepository deviceRepository, IClientDeviceRepository clientDeviceRepository)
        {
            _deviceRepository = deviceRepository;
            _clientDeviceRepository = clientDeviceRepository;
        }

        public async Task<GetDeviceResponse> Execute(GetDeviceRequest request)
        {
            try
            {
                List<ClientDevice> listDevice = await _clientDeviceRepository.GetDevices(request.ClientId);

                List<DeviceDto> devices = new();

                listDevice.ForEach(async device =>
                    {
                        Device dev = await _deviceRepository.GetDevice(device.dispositivo_id);
                        devices.Add(dev.ToDto());
                    });

                return new GetDeviceResponse { ListDeviceDto = devices };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
