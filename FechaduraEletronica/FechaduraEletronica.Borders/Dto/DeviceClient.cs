using System;

namespace FechaduraEletronica.Borders.Dto
{
    public class DeviceClient
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedIn { get; set; }
        public DateTime DisabledIn { get; set; }
    }
}
