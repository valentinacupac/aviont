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
            : base(paramGroup, parser, objectMapSerializer)
        {

        }


    }
}
