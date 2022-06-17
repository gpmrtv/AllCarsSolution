using System;

namespace AllCar.Shared.ViewModels
{
    public class HistoryViewModel<TView>
    {
        public virtual TView Old { get; set; }
        public virtual TView New { get; set; }
        public virtual TView Difference { get; set; }
        public virtual Guid ModifiedUserId { get; set; }
        public virtual DateTime ModifiedDateTime { get; set; }
        public virtual string Operation { get; set; }
    }
}
