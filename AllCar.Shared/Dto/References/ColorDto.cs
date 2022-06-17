using System;
using System.Collections.Generic;
using System.Text;

namespace AllCar.Shared.Dto.References
{
    public class ColorDto : BaseDto
    {
        public string Name { get; set; }
        public string Hex { get; set; }
        public Guid? ParentId { get; set; }
        public ColorDto Parent { get; set; }
    }
}
