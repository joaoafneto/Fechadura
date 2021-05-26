using FechaduraEletronica.Borders.Dto;
using FechaduraEletronica.Borders.Entity;
using System.Collections.Generic;

namespace FechaduraEletronica.Borders.Shared.Converters
{
    public static class DeviceConverter
    {
        public static DeviceDto ToDto(this Device device)
        {
            return new DeviceDto
            {
                CreatedIn = device.criado_em,
                DisabledIn = device.desativado_em,
                Id = device.id,
                Nick = device.nome
            };
        }

        public static List<DeviceDto> ToListDto(this List<Device> devices)
        {
            List<DeviceDto> deviceDtos = new List<DeviceDto>();

            devices.ForEach(device => deviceDtos.Add(device.ToDto()));

            return deviceDtos;
        }
    }
}
