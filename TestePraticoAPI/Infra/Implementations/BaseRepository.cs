using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;

namespace Infra.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataBaseContext _dbContext;

        public BaseRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Insert(T obj)
        {
            try
            {
                _dbContext.Set<T>().Add(obj);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(T obj)
        {
            try
            {
                _dbContext.Set<T>().Update(obj);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int codigo)
        {
            try
            {
                var obj = GetById(codigo);
                if (obj == null)
                    throw new Exception($"Produto de código '{codigo}' não encontrado!");
                _dbContext.Set<T>().Remove(obj);
                _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetById(int id)
        {
            try
            {
                return _dbContext.Set<T>().Where(x => x.Codigo == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
