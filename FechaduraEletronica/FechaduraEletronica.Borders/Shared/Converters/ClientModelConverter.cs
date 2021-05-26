using FechaduraEletronica.Borders.Controllers.ClientController;
using FechaduraEletronica.Borders.Dto;

namespace FechaduraEletronica.Borders.Shared.Converters
{
    public static class ClientModelConverter
    {
        public static ClientDto ConvertToDto(this ClientModel clientModel)
        {
            return clientModel == null ? null : new ClientDto
            {
                District = clientModel.District,
                City = clientModel.City,
                Cpf = clientModel.Cpf,
                Email = clientModel.Email,
                UF = clientModel.UF,
                Address = clientModel.Address,
                Name = clientModel.Name,
                Number = clientModel.Number,
                PostalCode = clientModel.PostalCode,
                Password = clientModel.Password
            };
        }
    }
}
