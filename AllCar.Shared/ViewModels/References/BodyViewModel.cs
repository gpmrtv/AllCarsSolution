using System;

namespace AllCar.Shared.ViewModels.References
{
    public class BodyViewModel : BaseViewModel
    {
        public virtual string Name { get; set; }
        public virtual Guid? ParentId { get; set; }
    }
}
