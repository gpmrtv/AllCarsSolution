using System;
using System.Collections.Generic;

namespace AllCar.Shared.Entities.References
{
    public class ModelEntity : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual Guid? ParentId { get; set; }
        public virtual ModelEntity Parent { get; set; }
        public virtual ICollection<ModelEntity> Children { get; set; }
        public virtual Guid MakeId { get; set; }
        public virtual MakeEntity Make { get; set; }
        public virtual EquipmentVariantEntity EquipmentVariant { get; set; }
        public virtual ICollection<GenerationEntity> Generations { get; set; }
    }
}
