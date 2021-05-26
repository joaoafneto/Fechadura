using System;

namespace FechaduraEletronica.Borders.Entity
{
    public class DeviceClient
    {
        public int id { get; set; }
        public int dispositivo_id { get; set; }
        public int cliente_id { get; set; }
        public DateTime criado_em { get; set; }
        public DateTime desativado_em { get; set; }
    }
}
