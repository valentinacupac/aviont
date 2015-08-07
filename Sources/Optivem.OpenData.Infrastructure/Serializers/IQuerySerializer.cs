using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Infrastructure
{
    public interface IQuerySerializer<T>
    {
        IQuery Deserialize(T query);

        T Serialize(IQuery query);
    }
}
