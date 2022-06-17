using System;

namespace AllCar.Shared.Entities
{
    public class LogEntity : BaseEntity
    {
        public virtual Guid ContextId { get; set; }
        public virtual string OldJson { get; set; }
        public virtual string NewJson { get; set; }
        public virtual string DifferentsJson { get; set; }
        public virtual Guid ModifiedUserId { get; set; }
        public virtual DateTime ModifiedDateTime { get; set; }
        public virtual OperationType Operation { get; set; }
    }

    public enum OperationType
    {
        Create,
        Update,
        Delete
    }
}
