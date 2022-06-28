using System.Collections.Generic;

namespace AllCar.Shared.Entities.References
{
    public class MakeEntity : BaseEntity
    {
        public string Name { get; set; }
        public virtual string LogoImageUri { get; set; }
        public virtual EquipmentVariantEntity EquipmentVariant { get; set; }
        public virtual ICollection<ModelEntity> Models { get; set; }
    }
}
