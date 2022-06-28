using System;

namespace AllCar.Shared.Dto.References
{
    public class EquipmentVariantDto : BaseDto
    {
        public Guid BodyId { get; set; }
        public Guid GearboxId { get; set; }
        public virtual Guid GearId { get; set; }
        public virtual Guid GenerationId { get; set; }
        public virtual Guid MakeId { get; set; }
        public virtual Guid ModelId { get; set; }
        public virtual BodyDto Body { get; set; }
        public virtual GearboxDto Gearbox { get; set; }
        public virtual GearDto Gear { get; set; }
        public virtual GenerationDto Generation { get; set; }
        public virtual MakeDto Make { get; set; }
        public virtual ModelDto Model { get; set; }
        //public virtual ICollection<CarDto> Cars { get; set; }
    }
}
