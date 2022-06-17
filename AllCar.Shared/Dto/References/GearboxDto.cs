using AllCar.Shared.Interfaces.Markers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllCar.Shared.Dto.References
{
    public class GearboxDto : BaseDto
    {
        public virtual string Name { get; set; }
        public virtual Guid? ParentId { get; set; }
        //public virtual GearboxDto Parent { get; set; }
        //public virtual EquipmentVariantDto EquipmentVariant { get; set; }
        //public virtual ICollection<GearboxDto> Childrens { get; set; }
    }
}
