using FechaduraEletronica.Borders.Dto;
using FechaduraEletronica.Borders.Entity;
using FechaduraEletronica.Borders.Executors.Client;
using FechaduraEletronica.Borders.Repositories;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace FechaduraEletronica.Executors
{
    public class CreateClientExecutor : ICreateClientExecutor
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientExecutor(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<CreateClientResponse> Execute(CreateClientRequest request)
        {
            try
            {
                if (request != null)
                {
                    Client client = await _clientRepository.Login(new GetClientRequest() { Cpf = request.ClientDto.Cpf, Password = request.ClientDto.Password });

                    if (client != null)
                        throw new Exception($"Client already: {JsonConvert.SerializeObject(client)}");

                    if (await _clientRepository.Create(request.ClientDto) == 1)
                        return new CreateClientResponse { Id = await _clientRepository.GetId() };

                    throw new Exception(message: $"It was not possible to create client: {JsonConvert.SerializeObject(request)}");
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
