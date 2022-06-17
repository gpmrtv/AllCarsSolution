namespace AllCar.Core.Utilities.Exchange
{
    public class PageParameters
    {
        private readonly int _maxPageSize = 1000;
        private int pageSize = 10;
        private int pageNumber = 1;

        public virtual int PageNumber
        {
            get => pageNumber;
            set => pageNumber = (value > 0) ? value : 1;
        }

        public int PageSize
        {
            get => pageSize;
            set
            {
                pageSize = value > _maxPageSize ? _maxPageSize : value;
                pageSize = pageSize > 0 ? pageSize : 1;
            }
        }

        public string Filter { get; init; }
    }
}
