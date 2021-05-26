using System;

namespace FechaduraEletronica.Borders.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string Cpf { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedIn { get; set; }
        public string Password { get; set; }
    }
}