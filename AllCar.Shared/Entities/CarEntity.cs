using AllCar.Shared.Entities.References;
using System;

namespace AllCar.Shared.Entities
{
    public class CarEntity : BaseEntity
    {
        public virtual string Vin { get; set; }
        public virtual string EngineNum { get; set; }
        public virtual string ChassisNum { get; set; }
        public virtual string BodyNum { get; set; }
        public virtual short Year { get; set; }
        public virtual string Notes { get; set; }
        public virtual Guid ColorId { get; set; }
        public virtual ColorEntity Color { get; set; }
        public virtual Guid EquipmentVariantId { get; set; }
        public virtual EquipmentVariantEntity EquipmentVariant { get; set; }
        public virtual ICollection<AreaEntity> Areas { get; set; }
        public virtual ICollection<CarAreasEntity> CarAreas { get; set; }
    }
}
