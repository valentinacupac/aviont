using Optivem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Providers.Quandl
{
    public class QuandlQueryStringMapSerializer : BaseQueryStringMapSerializer
    {
        public QuandlQueryStringMapSerializer(QueryParamGroup paramGroup, Parser parser, QuandlQueryObjectMapSerializer objectMapSerializer)
            : base(paramGroup, parser)
        {
            this.ObjectMapSerializer = objectMapSerializer;
        }

        public QuandlQueryObjectMapSerializer ObjectMapSerializer { get; private set; }

        public override IQuery Deserialize(Dictionary<string, string> query)
        {
            Dictionary<string, object> map = ToObjectMap(query);
            return ObjectMapSerializer.Deserialize(map);
        }

        public override Dictionary<string, string> Serialize(IQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
