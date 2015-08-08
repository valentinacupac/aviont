using Optivem.OpenData.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Infrastructure.Web
{
    public abstract class BaseQuerySerializer<T> : IQuerySerializer<T>
    {
        protected BaseQuerySerializer(DataQuerySchema queryParamGroup)
        {
            this.QueryParamGroup = queryParamGroup;
        }

        public DataQuerySchema QueryParamGroup { get; private set; }

        public abstract IQuery Deserialize(T query);

        public abstract T Serialize(IQuery query);
    }
}
