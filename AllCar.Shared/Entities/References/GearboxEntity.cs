using System;
using System.Collections.Generic;

namespace AllCar.Shared.Entities.References
{
    public class GearboxEntity : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual Guid? ParentId { get; set; }
        public virtual GearboxEntity Parent { get; set; }
        public virtual EquipmentVariantEntity EquipmentVariant { get; set; }
        public virtual ICollection<GearboxEntity> Childrens { get; set; }
    }
}
