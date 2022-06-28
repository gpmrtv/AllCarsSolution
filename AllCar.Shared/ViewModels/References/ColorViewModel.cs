using System;

namespace AllCar.Shared.ViewModels.References
{
    public class ColorViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Hex { get; set; }
        public Guid? ParentId { get; set; }
        public ColorViewModel Parent { get; set; }
    }
}
