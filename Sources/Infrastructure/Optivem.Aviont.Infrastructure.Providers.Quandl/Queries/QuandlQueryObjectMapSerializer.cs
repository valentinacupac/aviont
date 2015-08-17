using Optivem.Aviont.Domain;
using Optivem.Aviont.Infrastructure.Web;
using Optivem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Aviont.Infrastructure.Providers.Quandl
{
    public class QuandlQueryObjectMapSerializer : BaseQueryObjectMapSerializer
    {
        public override IQuery Deserialize(Dictionary<string, object> query)
        {
            string databaseCode = (string)query[QuandlQueryKeys.DatabaseCode];
            string tableCode = (string)query[QuandlQueryKeys.TableCode];
            FileType formatCode = ConvertNonNullable<FileType>(query[QuandlQueryKeys.FormatCode]);
            string authToken = (string)query[QuandlQueryKeys.AuthToken];
            DateTime? trimStart = (DateTime?)query[QuandlQueryKeys.TrimStart];
            DateTime? trimEnd = (DateTime?)query[QuandlQueryKeys.TrimEnd];
            SortOrder sortOrder = ConvertNonNullable<SortOrder>(query[QuandlQueryKeys.SortOrder]);
            bool excludeHeader = ConvertNonNullable<bool>(query[QuandlQueryKeys.ExcludeHeader]);
            bool excludeData = ConvertNonNullable<bool>(query[QuandlQueryKeys.ExcludeData]);
            int? rows = (int?)query[QuandlQueryKeys.Rows];
            int? column = (int?)query[QuandlQueryKeys.Column];
            CollapseType frequency = ConvertNonNullable<CollapseType>(query[QuandlQueryKeys.Frequency]);
            TransformationType calculation = ConvertNonNullable<TransformationType>((TransformationType)query[QuandlQueryKeys.Calculation]);

            return new QuandlQuery(databaseCode, tableCode, formatCode, authToken, trimStart, trimEnd, sortOrder,
                excludeHeader, excludeData, rows, column, frequency, calculation);
        }

        public override Dictionary<string, object> Serialize(IQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
