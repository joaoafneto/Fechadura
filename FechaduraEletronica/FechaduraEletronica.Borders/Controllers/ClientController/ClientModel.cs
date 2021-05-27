namespace FechaduraEletronica.Borders.Controllers.ClientController
{
    public class ClientModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string Cpf { get; set; }
        public string PostalCode { get; set; }
        public string Password { get; set; }
        public int ClientId { get; private set; }

        public void SetClientId(int id)
        {
            ClientId = id;
        }
    }
}
