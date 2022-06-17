using AllCar.Shared.ViewModels.References;
using System;
using System.ComponentModel.DataAnnotations;

namespace AllCar.Shared.ViewModels
{
    public class CarViewModel : BaseViewModel
    {
        public virtual string Vin { get; set; }
        public virtual string EngineNum { get; set; }
        public virtual string ChassisNum { get; set; }
        public virtual string BodyNum { get; set; }
        public virtual int Year { get; set; }
        public virtual string Notes { get; set; }
        public virtual Guid EquipmentVariantId { get; set; }
        public virtual Guid ColorId { get; set; }
    }
}
