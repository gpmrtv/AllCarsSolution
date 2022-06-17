using System;

namespace AllCar.Shared.Dto
{
    public class BaseDto
    {
        public virtual Guid Id { get; set; }
        public virtual Guid CreatedUserId { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }
        public virtual Guid? UpdatedUserId { get; set; }
        public virtual DateTime? UpdatedDateTime { get; set; }
    }
}
