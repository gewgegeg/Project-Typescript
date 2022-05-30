using System;
using Monit.Project.DAL.Enums;

namespace Monit.Project.DAL.Entities
{
    public class DeviceStaticInfo : BaseEntity
    {
        public string Name { get; set; }
        public string Os { get; set; }
        public double[] Coordinates { get; set; }
    }
}
