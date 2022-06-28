using System;
using System.Collections.Generic;

namespace AllCar.Shared.Entities.References
{
    public class EquipmentVariantEntity : BaseEntity
    {
        public Guid BodyId { get; set; }
        public Guid GearboxId { get; set; }
        public virtual Guid GearId { get; set; }
        public virtual Guid GenerationId { get; set; }
        public virtual Guid MakeId { get; set; }
        public virtual Guid ModelId { get; set; }
        public virtual BodyEntity Body { get; set; }
        public virtual GearboxEntity Gearbox { get; set; }
        public virtual GearEntity Gear { get; set; }
        public virtual GenerationEntity Generation { get; set; }
        public virtual MakeEntity Make { get; set; }
        public virtual ModelEntity Model { get; set; }
        public virtual ICollection<CarEntity> Cars { get; set; }
    }
}
