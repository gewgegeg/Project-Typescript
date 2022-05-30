using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monit.Project.DAL.Interfaces;
using System.Drawing;
using Monit.Project.DAL.Enums;

namespace Monit.Project.Core.Models
{
    public class DeviceSystemLogs : IDevicePartialData
    {
        public Guid SourceDeviceId { get; set; }

        public Queue<double>? CpuPerformanceGraph { get; set; }
        public List<string>? TerminalLog { get; set; }
    }
}
