using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using Infra.Context;
using Infra.Implementations;

namespace Service.Implementations
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void Add<TValidator>(T obj) where TValidator : AbstractValidator<T>
        {
            try
            {
                _baseRepository.Insert(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update<TValidator>(T obj) where TValidator : AbstractValidator<T>
        {
            try
            {
                _baseRepository.Update(obj);
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
                _baseRepository.Delete(codigo);
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
                return _baseRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
