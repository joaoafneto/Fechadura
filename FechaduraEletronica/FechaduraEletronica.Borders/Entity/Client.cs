using System;

namespace FechaduraEletronica.Borders.Entity
{
    public class Client
    {
        public int id { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string cpf { get; set; }
        public DateTime criado_em { get; set; }
        public string email { get; set; }
        public string logradouro { get; set; }
        public string nome { get; set; }
        public int numero { get; set; }
        public string cidadde { get; set; }
        public string uf { get; set; }
        public string senha { get; set; }
    }
}
