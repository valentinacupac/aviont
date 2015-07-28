using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Providers.Quandl
{
    public class QuandlQueryStringSerializer : BaseQueryStringSerializer
    {
        public QuandlQueryStringSerializer(QueryParamGroup queryParamGroup, string fieldSeparator, string valueSeparator, StringSplitOptions splitOptions, string[] nullStrings, QuandlQueryStringMapSerializer stringMapSerializer)
            : base(queryParamGroup, fieldSeparator, valueSeparator, splitOptions, nullStrings)
        {
            this.StringMapSerializer = stringMapSerializer;
        }

        public QuandlQueryStringMapSerializer StringMapSerializer { get; private set; }

        public override IQuery Deserialize(string query)
        {
            Dictionary<string, string> map = ToStringMap(query);
            return StringMapSerializer.Deserialize(map);
        }

        public override string Serialize(IQuery query)
        {
            Dictionary<string, string> map = StringMapSerializer.Serialize(query);
            return ToString(map);
        }
    }
}
