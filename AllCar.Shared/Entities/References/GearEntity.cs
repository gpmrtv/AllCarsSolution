namespace AllCar.Shared.Entities.References
{
    public class GearEntity : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual EquipmentVariantEntity EquipmentVariant { get; set; }
    }
}
