using AllCar.Shared.Interfaces.Markers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllCar.Shared.Dto.References
{
    public class GenerationDto : BaseDto
    {
        public virtual string Name { get; set; }
        public virtual string ImageUri { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual Guid ModelId { get; set; }
        //public virtual ModelDto Model { get; set; }
        //public virtual EquipmentVariantDto EquipmentVariant { get; set; }
    }
}
