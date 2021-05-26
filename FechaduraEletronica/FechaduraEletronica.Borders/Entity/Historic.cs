using System;

namespace FechaduraEletronica.Borders.Entity
{
    public class Historic
    {
        public int id { get; set; }
        public int dispositivo_id { get; set; }
        public int cliente_id { get; set; }
        public DateTime acesso_em { get; set; }
    }
}
