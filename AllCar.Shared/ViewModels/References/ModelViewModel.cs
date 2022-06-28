using System;

namespace AllCar.Shared.ViewModels.References
{
    public class ModelViewModel : BaseViewModel
    {
        public virtual string Name { get; set; }
        public virtual Guid? ParentId { get; set; }
        //public virtual ModelViewModel Parent { get; set; }
        //public virtual ICollection<ModelViewModel> Children { get; set; }
        public virtual Guid MakeId { get; set; }
        //public virtual MakeViewModel Make { get; set; }
        //public virtual EquipmentVariantViewModel EquipmentVariant { get; set; }
        //public virtual ICollection<GenerationViewModel> Generations { get; set; }
    }
}
