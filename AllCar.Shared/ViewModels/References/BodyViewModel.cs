using System;
using System.Collections.Generic;
using System.Text;

namespace AllCar.Shared.ViewModels.References
{
    public class BodyViewModel : BaseViewModel
    {
        public virtual string Name { get; set; }
        public virtual Guid? ParentId { get; set; }
    }
}
