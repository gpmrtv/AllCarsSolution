using System;

namespace AllCar.Shared.ViewModels.References
{
    public class EquipmentVariantViewModel : BaseViewModel
    {
        public Guid BodyId { get; set; }
        public Guid GearboxId { get; set; }
        public virtual Guid GearId { get; set; }
        public virtual Guid GenerationId { get; set; }
        public virtual Guid MakeId { get; set; }
        public virtual Guid ModelId { get; set; }
        public virtual BodyViewModel Body { get; set; }
        public virtual GearboxViewModel Gearbox { get; set; }
        public virtual GearViewModel Gear { get; set; }
        public virtual GenerationViewModel Generation { get; set; }
        public virtual MakeViewModel Make { get; set; }
        public virtual ModelViewModel Model { get; set; }
        //public virtual ICollection<CarViewModel> Cars { get; set; }
    }
}
