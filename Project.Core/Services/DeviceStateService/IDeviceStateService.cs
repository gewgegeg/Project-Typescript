using System;
using System.Threading.Tasks;
using Monit.Project.Core.Models;

namespace Monit.Project.Core.Services.DeviceStateService
{
    public interface IDeviceStateService
    {
        public Task<Guid> SetState(DeviceState entity);
        public Task<DeviceState> GetStateOrNull(Guid id);
    }
}
