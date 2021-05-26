using FechaduraEletronica.Borders.Dto;
using FechaduraEletronica.Borders.Entity;
using FechaduraEletronica.Borders.Executors.Client;
using FechaduraEletronica.Borders.Repositories;
using FechaduraEletronica.Borders.Shared.Converters;
using System;
using System.Threading.Tasks;

namespace FechaduraEletronica.Executors
{
    public class GetClientExecutor : IGetClientExecutor
    {
        private readonly IClientRepository _clientRepository;

        public GetClientExecutor(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<GetClientResponse> Execute(GetClientRequest request)
        {
            try
            {
                Client client = await _clientRepository.Login(request);

                if (client != null)
                    return new GetClientResponse { Client = client.ToClientModel() };

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
