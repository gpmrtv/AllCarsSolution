using AllCar.Shared.Entities.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCar.Shared.Entities
{
    public class CarAreasEntity : BaseEntity
    {
        public Guid CarId { get; set; }
        public Guid AreaId { get; set; }
        public decimal Cost { get; set; }
        public CarEntity Car { get; set; }
        public AreaEntity Area { get; set; }
    }
}
