using FechaduraEletronica.Borders.Controllers.ClientController;
using FechaduraEletronica.Borders.Entity;

namespace FechaduraEletronica.Borders.Shared.Converters
{
    public static class ClientConverter
    {
        public static ClientModel ToClientModel(this Client client)
        {
            ClientModel clientModel = new ClientModel
            {
                Address = client.logradouro,
                City = client.cidadde,
                Cpf = client.cpf,
                PostalCode = client.cep,
                District = client.bairro,
                Email = client.email,
                Name = client.nome,
                Number = client.numero,
                UF = client.uf,
            };

            clientModel.SetClientId(client.id);

            return clientModel;
        }
    }
}
