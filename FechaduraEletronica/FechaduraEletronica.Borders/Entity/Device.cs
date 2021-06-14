using System;

namespace FechaduraEletronica.Borders.Entity
{
    public class Device
    {
        public int id { get; set; }
        public DateTime criado_em { get; set; }
        public DateTime desativado_em { get; set; }
        public string nome { get; set; }
        public string BluetoothId { get; set; }
    }
}
