using AllCar.Shared.Interfaces.Markers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllCar.Shared.Dto.References
{
    public class BodyDto : BaseDto
    {
        public virtual string Name { get; set; }
        public virtual Guid? ParentId { get; set; }
    }
}
