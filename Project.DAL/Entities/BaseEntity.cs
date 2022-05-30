using System;
using Monit.Project.DAL.Interfaces;

namespace Monit.Project.DAL.Entities
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; } = new Guid();
    }
}
