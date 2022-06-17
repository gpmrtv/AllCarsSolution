using AllCar.Shared.Interfaces.Markers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllCar.Shared.Dto.References
{
    public class GearDto : BaseDto
    {
        public virtual string Name { get; set; }
        //public virtual EquipmentVariantDto EquipmentVariant { get; set; }
    }
}
