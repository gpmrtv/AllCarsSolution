using System;

namespace AllCar.Shared.Dto.References
{
    public class ModelDto : BaseDto
    {
        public virtual string Name { get; set; }
        public virtual Guid? ParentId { get; set; }
        //public virtual ModelDto Parent { get; set; }
        //public virtual ICollection<ModelDto> Children { get; set; }
        public virtual Guid MakeId { get; set; }
        //public virtual MakeDto Make { get; set; }
        //public virtual EquipmentVariantDto EquipmentVariant { get; set; }
        //public virtual ICollection<GenerationDto> Generations { get; set; }
    }
}
