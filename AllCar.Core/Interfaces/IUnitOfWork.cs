using AllCar.Core.Interfaces.Common;
using AllCar.Shared.Entities;

namespace AllCar.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
