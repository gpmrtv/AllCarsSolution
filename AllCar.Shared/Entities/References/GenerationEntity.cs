using System;

namespace AllCar.Shared.Entities.References
{
    public class GenerationEntity : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string ImageUri { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual Guid ModelId { get; set; }
        public virtual ModelEntity Model { get; set; }
        public virtual EquipmentVariantEntity EquipmentVariant { get; set; }
    }
}
