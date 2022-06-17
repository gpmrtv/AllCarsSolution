using System;
using System.Collections.Generic;
using System.Text;

namespace AllCar.Shared.ViewModels.References
{
    public class GearboxViewModel : BaseViewModel
    {
        public virtual string Name { get; set; }
        public virtual Guid? ParentId { get; set; }
        //public virtual GearboxViewModel Parent { get; set; }
        //public virtual EquipmentVariantViewModel EquipmentVariant { get; set; }
        //public virtual ICollection<GearboxViewModel> Childrens { get; set; }
    }
}
