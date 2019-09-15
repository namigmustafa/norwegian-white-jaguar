using NorwegianWhiteJaguar.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorwegianWhiteJaguar.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
