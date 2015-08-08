using Optivem.OpenData.Domain;
using Optivem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Infrastructure.Providers.Quandl
{
    public static class QuandlQueryParamGroup
    {
        public static DataQuerySchema QueryParamGroup = new DataQuerySchema(new List<DataField>
        {
            new DataField(QuandlQueryKeys.DatabaseCode, CommonTypes.String),
            new DataField(QuandlQueryKeys.TableCode, CommonTypes.String),
            new DataField(QuandlQueryKeys.FormatCode, typeof(FileType)),
            new DataField(QuandlQueryKeys.AuthToken, CommonTypes.String, true),
            new DataField(QuandlQueryKeys.TrimStart, CommonTypes.DateTime, true),
            new DataField(QuandlQueryKeys.TrimEnd, CommonTypes.DateTime, true),
            new DataField(QuandlQueryKeys.SortOrder, typeof(SortOrder), true),
            new DataField(QuandlQueryKeys.ExcludeHeader, CommonTypes.Bool, true),
            new DataField(QuandlQueryKeys.ExcludeData, CommonTypes.Bool, true),
            new DataField(QuandlQueryKeys.Rows, CommonTypes.Int, true),
            new DataField(QuandlQueryKeys.Column, CommonTypes.Int, true),
            new DataField(QuandlQueryKeys.Frequency, typeof(CollapseType), true),
            new DataField(QuandlQueryKeys.Calculation, typeof(TransformationType), true),
        });
    }
}
