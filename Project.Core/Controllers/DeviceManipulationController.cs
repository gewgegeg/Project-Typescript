using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Monit.Project.Core.Services.DeviceManipulationService;

namespace Monit.Project.Core.Controllers
{
    [Route("api/device/manipulation")]
    [ApiController]
    public class DeviceManipulationController : ControllerBase
    {
        private readonly IDeviceManiupalationService _maniupalationService;
        public DeviceManipulationController(IDeviceManiupalationService service)
        {
            _maniupalationService = service;
        }

        [HttpGet("execute")]
        public async Task<ActionResult<List<string>>> Execute(Guid id, string command)
        {
            return Ok(await _maniupalationService.Execute(id, command));
        }
    }
}
