namespace AllCar.Shared.Dto.References
{
    public class MakeDto : BaseDto
    {
        public string Name { get; set; }
        public virtual string LogoImageUri { get; set; }
        //public virtual EquipmentVariantDto EquipmentVariant { get; set; }
        //public virtual ICollection<ModelDto> Models { get; set; }
    }
}
