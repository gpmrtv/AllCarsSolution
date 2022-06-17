using AllCar.Shared.Dto.References;
using AllCar.Shared.Interfaces.Markers;
using System;

namespace AllCar.Shared.Dto
{
    public class CarDto : BaseDto, ICacheble
    {
        public virtual string Vin { get; set; }
        public virtual string EngineNum { get; set; }
        public virtual string ChassisNum { get; set; }
        public virtual string BodyNum { get; set; }
        public virtual short Year { get; set; }
        public virtual string Notes { get; set; }
        public virtual Guid EquipmentVariantId { get; set; }
        public virtual Guid ColorId { get; set; }
    }
}
