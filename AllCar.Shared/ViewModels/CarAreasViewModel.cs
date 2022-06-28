using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCar.Shared.ViewModels
{
    public class CarAreasViewModel : BaseViewModel
    {
        public Guid CarId { get; set; }
        public Guid AreaId { get; set; }
        public decimal Cost { get; set; }
    }
}
