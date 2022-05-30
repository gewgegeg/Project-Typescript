using System;

namespace Monit.Project.DAL.Entities
{
    public class Session : BaseEntity
    {
        public string Token { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
