using FechaduraEletronica.Borders.Controllers.DevicesController;
using FechaduraEletronica.Borders.Dto;
using FechaduraEletronica.Borders.Executors.Device;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FechaduraEletronica.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IGetDeviceExecutor _getDeviceExecutor;
        private readonly ICreateDeviceExecutor _createDeviceExecutor;

        public DevicesController(IGetDeviceExecutor getDeviceExecutor, ICreateDeviceExecutor createDeviceExecutor)
        {
            _getDeviceExecutor = getDeviceExecutor;
            _createDeviceExecutor = createDeviceExecutor;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(int))]
        [ProducesResponseType(404, Type = typeof(BadRequestResult))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> CreateDevice([FromBody] CreateDeviceModel request)
        {
            try
            {
                if (request == null)
                    return BadRequest("Request null.");

                CreateDeviceResponse response = await _createDeviceExecutor.Execute(new CreateDeviceRequest { ClientId = request.ClientId, Nick = request.Nick });

                return Created(string.Empty, response.DeviceId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<DeviceDto>))]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [ProducesResponseType(404, Type = typeof(NotFoundResult))]
        public async Task<IActionResult> GetDevice([FromQuery] int clientId)
        {
            try
            {
                GetDeviceResponse response = await _getDeviceExecutor.Execute(new GetDeviceRequest { ClientId = clientId });

                if (response != null)
                {
                    return Ok(response.ListDeviceDto);
                }

                return NotFound(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
