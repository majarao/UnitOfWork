using UnitOfWork.Context;

namespace UnitOfWork.Abstractions;

public interface ICommands<T> where T : EntityBase
{
    T Create(T entity);
    T Update(T entity);
    bool Delete(int entityId);
}
