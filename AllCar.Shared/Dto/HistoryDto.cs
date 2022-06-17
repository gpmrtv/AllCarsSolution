using System;

namespace AllCar.Shared.Dto
{
    public class HistoryDto<TDto>
    {
        public virtual TDto Old { get; set; }
        public virtual TDto New { get; set; }
        public virtual TDto Difference { get; set; }
        public virtual Guid ModifiedUserId { get; set; }
        public virtual DateTime ModifiedDateTime { get; set; }
        public virtual string Operation { get; set; }
    }
}
