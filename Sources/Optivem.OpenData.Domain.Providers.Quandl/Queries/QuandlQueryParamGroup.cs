using Optivem.OpenData.Domain;
using Optivem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Domain.Providers.Quandl
{
    public static class QuandlQueryParamGroup
    {
        public static QueryParamGroup QueryParamGroup = new QueryParamGroup(new List<QueryParam>
        {
            new QueryParam(QuandlQueryKeys.DatabaseCode, CommonTypes.String),
            new QueryParam(QuandlQueryKeys.TableCode, CommonTypes.String),
            new QueryParam(QuandlQueryKeys.FormatCode, typeof(FileType)),
            new QueryParam(QuandlQueryKeys.AuthToken, CommonTypes.String, true),
            new QueryParam(QuandlQueryKeys.TrimStart, CommonTypes.DateTime, true),
            new QueryParam(QuandlQueryKeys.TrimEnd, CommonTypes.DateTime, true),
            new QueryParam(QuandlQueryKeys.SortOrder, typeof(SortOrder), true),
            new QueryParam(QuandlQueryKeys.ExcludeHeader, CommonTypes.Bool, true),
            new QueryParam(QuandlQueryKeys.ExcludeData, CommonTypes.Bool, true),
            new QueryParam(QuandlQueryKeys.Rows, CommonTypes.Int, true),
            new QueryParam(QuandlQueryKeys.Column, CommonTypes.Int, true),
            new QueryParam(QuandlQueryKeys.Frequency, typeof(CollapseType), true),
            new QueryParam(QuandlQueryKeys.Calculation, typeof(TransformationType), true),
        });
    }
}
