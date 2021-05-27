using FechaduraEletronica.Borders.Controllers.ClientController;
using FechaduraEletronica.Borders.Dto;
using FechaduraEletronica.Borders.Executors.Client;
using FechaduraEletronica.Borders.Shared.Converters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace FechaduraEletronica.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ICreateClientExecutor _createClientExecutor;
        private readonly IGetClientExecutor _getClientExecutor;

        public ClientController(ICreateClientExecutor createClientExecutor, IGetClientExecutor getClientExecutor)
        {
            _createClientExecutor = createClientExecutor;
            _getClientExecutor = getClientExecutor;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreatedResult))]
        [ProducesResponseType(409, Type = typeof(ConflictObjectResult))]
        [ProducesResponseType(500, Type = typeof(ClientModel))]
        public async Task<IActionResult> Create([FromBody] ClientModel request)
        {
            try
            {
                if (request == null || string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.Cpf))
                    return BadRequest(JsonConvert.SerializeObject(request));

                CreateClientResponse response = await _createClientExecutor.Execute(new CreateClientRequest { ClientDto = request.ConvertToDto() });

                if (response == null)
                    return Conflict();

                return Created(string.Empty, response.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("{cpf}/{password}")]
        [ProducesResponseType(200, Type = typeof(ClientModel))]
        [ProducesResponseType(404, Type = typeof(ClientModel))]
        [ProducesResponseType(400, Type = typeof(ClientModel))]
        public async Task<IActionResult> Login(string cpf, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(password))
                    return BadRequest($"Cpf = {cpf} or Password = {password} invalid");

                GetClientResponse response = await _getClientExecutor.Execute(new GetClientRequest { Cpf = cpf, Password = password });

                if (response != null)
                    return Ok(response.Client);

                return NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
