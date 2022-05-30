using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monit.Project.DAL.Enums;

namespace Monit.Project.Core.Models
{
    public class DeviceState: IDevicePartialData
    {
        public Guid SourceDeviceId { get; set; }
        public DeviceStatus Status { get; set; }
        public int RunTimeS { get; set; }
        public double LastAnswerTime { get; set; }
    }
}
