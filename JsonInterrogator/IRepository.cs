using System.Collections.Generic;

namespace JsonInterrogator
{
    public interface IRepository
    {
        IEnumerable<T> Get<T>();
    }
}
