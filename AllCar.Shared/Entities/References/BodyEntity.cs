using System;
using System.Collections.Generic;
using System.Text;

namespace AllCar.Shared.Entities.References
{
    public class BodyEntity : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual Guid? ParentId { get; set; }
        public virtual BodyEntity Parent { get; set; }
        public virtual EquipmentVariantEntity EquipmentVariant { get; set; }
        public virtual ICollection<BodyEntity> Childrens { get; set; }
    }
}
