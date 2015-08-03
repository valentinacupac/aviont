using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Domain
{
    public abstract class BaseQuerySerializer<T> : IQuerySerializer<T>
    {
        protected BaseQuerySerializer(QueryParamGroup queryParamGroup)
        {
            this.QueryParamGroup = queryParamGroup;
        }

        public QueryParamGroup QueryParamGroup { get; private set; }

        public abstract IQuery Deserialize(T query);

        public abstract T Serialize(IQuery query);
    }
}
