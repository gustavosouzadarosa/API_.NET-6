using Domain.Entities;
using FluentValidation;

namespace Domain.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        void Add<TValidator>(T obj) where TValidator : AbstractValidator<T>;
        void Update<TValidator>(T obj) where TValidator : AbstractValidator<T>;
        void Delete(int codigo);
        T GetById(int id);
    }
}
