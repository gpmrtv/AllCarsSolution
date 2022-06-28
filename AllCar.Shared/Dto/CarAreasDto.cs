using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCar.Shared.Dto
{
    public class CarAreasDto : BaseDto
    {
        public Guid CarId { get; set; }
        public Guid AreaId { get; set; }
        public decimal Cost { get; set; }
    }
}
