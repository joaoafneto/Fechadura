using System;

namespace FechaduraEletronica.Borders.Dto
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public DateTime CreatedIn { get; set; }
        public DateTime DisabledIn { get; set; }
        public string Nick { get; set; }
        public string BluetoothId { get; set; }
    }
}
