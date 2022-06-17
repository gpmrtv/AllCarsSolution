using System;
using System.Collections.Generic;
using System.Text;

namespace AllCar.Shared.Entities.References
{
    public class ColorEntity : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Hex { get; set; }
        public virtual Guid? ParentId { get; set; }
        public virtual ColorEntity Parent { get; set; }
        public virtual ICollection<ColorEntity> Childrens { get; set; }
        public virtual ICollection<CarEntity> Cars { get; set; }
    }
}
