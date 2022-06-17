using AllCar.Shared.Interfaces.Markers;
using System;

namespace AllCar.Shared.Entities
{
    public class BaseEntity : ILoggable
    {
        public virtual Guid Id { get; set; }
        public virtual Guid CreatedUserId { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }
        public virtual Guid? UpdatedUserId { get; set; }
        public virtual DateTime? UpdatedDateTime { get; set; }
    }
}
