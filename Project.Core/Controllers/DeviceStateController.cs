using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Monit.Project.Core.Models;
using Monit.Project.Core.Services.DeviceStateService;
using Monit.Project.DAL.Entities;

namespace Monit.Project.Core.Controllers
{
    [Route("api/device/state")]
    [ApiController]
    public class DeviceStateController : ControllerBase
    {
        private readonly IDeviceStateService _stateSerivce;
        public DeviceStateController(IDeviceStateService service)
        {
            _stateSerivce = service;
        }

        [HttpPut("set")]
        public async Task<ActionResult<Guid>> SetState([FromBody] DeviceState systemLogs)
        {
            await _stateSerivce.SetState(systemLogs);

            return Ok();
        }

        [HttpGet("get")]
        public async Task<ActionResult<DeviceSystemLogs>> GetState(Guid id)
        {
            var device = await _stateSerivce.GetStateOrNull(id);

            if (device is null)
                return NotFound();

            return Ok(device);
        }
    }
}
