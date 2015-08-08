using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Infrastructure.Web
{
    public abstract class BaseQueryObjectMapSerializer : IQuerySerializer<Dictionary<string, object>>
    {
        public abstract IQuery Deserialize(Dictionary<string, object> query);

        public abstract Dictionary<string, object> Serialize(IQuery query);

        protected T ConvertNonNullable<T>(object obj, T defaultValue)
        {
            // TODO: Perhaps parameter arguments should also specify default value in case of nullability

            return obj != null ? (T)obj : defaultValue;
        }

        protected T ConvertNonNullable<T>(object obj)
        {
            return ConvertNonNullable<T>(obj, default(T));
        }
    }
}
