using UnitOfWork.Context;

namespace UnitOfWork.Abstractions;

public interface IQuerys<T> where T : EntityBase
{
    IQueryable<T>? Read();
    T? ReadById(int entityId);
}
