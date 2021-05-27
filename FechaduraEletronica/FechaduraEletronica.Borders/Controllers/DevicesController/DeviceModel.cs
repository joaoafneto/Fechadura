using System;

namespace FechaduraEletronica.Borders.Controllers.DevicesController
{
    public class DeviceModel
    {
        public int Id { get; set; }
        public DateTime CreatedIn { get; set; }
        public DateTime DisabledIn { get; set; }
        public string Nick { get; set; }
    }
}
