using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCar.Shared.Entities.References
{
    public class AreaEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUri { get; set; }
        public ICollection<CarEntity> Cars { get; set; }
        public virtual ICollection<CarAreasEntity> CarAreas { get; set; }
    }
}
