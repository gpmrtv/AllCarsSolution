using AllCar.Shared.Interfaces.Markers;
using System;

namespace AllCar.Shared.Dto.References
{
    public class BodyDto : BaseDto, ICacheble
    {
        public virtual string Name { get; set; }
        public virtual Guid? ParentId { get; set; }
    }
}
