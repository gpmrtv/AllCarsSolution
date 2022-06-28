using System;

namespace AllCar.Shared.ViewModels.References
{
    public class GenerationViewModel : BaseViewModel
    {
        public virtual string Name { get; set; }
        public virtual string ImageUri { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual Guid ModelId { get; set; }
        //public virtual ModelViewModel Model { get; set; }
       // public virtual EquipmentVariantViewModel EquipmentVariant { get; set; }
    }
}
