using System;
using System.Threading.Tasks;
using Monit.Project.Core.Models;

namespace Monit.Project.Core.Services.DeviceSystemLogsService
{
    public interface IDeviceSystemLogsService
    {
        public Task<Guid> SetLogs(DeviceSystemLogs entity);
        public Task AddTerminalLog(Guid id, string terminalLog);
        public Task<DeviceSystemLogs> GetLogsOrNull(Guid id);
    }
}
