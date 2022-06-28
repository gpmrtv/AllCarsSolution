using System;

namespace AllCar.Shared.Dto.References
{
    public class BodyDto : BaseDto
    {
        public virtual string Name { get; set; }
        public virtual Guid? ParentId { get; set; }
    }
}
