using System;

namespace FechaduraEletronica.Borders.Controllers.DevicesController
{
    public class DeviceModel
    {
        public int IdDevice { get; set; }
        public DateTime CreatedIn { get; set; }
        public DateTime DisabledIn { get; set; }
        public string Nick { get; set; }
    }
}
