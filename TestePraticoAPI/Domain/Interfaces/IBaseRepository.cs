using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(int codigo);
        T GetById(int id);
    }
}
