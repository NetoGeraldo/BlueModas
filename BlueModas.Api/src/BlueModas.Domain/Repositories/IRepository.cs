using System;

namespace BlueModas.Domain.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity
    {

    }
}
