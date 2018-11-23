using System.Collections.Generic;

namespace AudioNetworkRock.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
