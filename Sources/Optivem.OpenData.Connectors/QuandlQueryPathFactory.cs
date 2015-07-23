using Optivem.OpenData.Quandl;
using Optivem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Connectors
{
    public class QuandlQueryPathFactory : BaseQueryPathFactory
    {
        public QuandlQueryPathFactory()
            : base(QuandlQueryPathFactoryHelper.Parser, QuandlQueryPathFactoryHelper.QueryParamGroup) { }

        protected override string Create(Dictionary<string, object> data)
        {
            // TODO: Add conversions for nullable objects
            // TODO: Add appropriate conversions for enums in utilities

            string databaseCode = (string) data[QuandlQueryKeys.DatabaseCode];
            string tableCode = (string) data[QuandlQueryKeys.DatabaseCode];
            FileType formatCode = (FileType) data[QuandlQueryKeys.DatabaseCode];
            string authToken = (string) data[QuandlQueryKeys.DatabaseCode];
            DateTime? trimStart = (DateTime?) data[QuandlQueryKeys.DatabaseCode];
            DateTime? trimEnd = (DateTime?) data[QuandlQueryKeys.DatabaseCode];
            SortOrder sortOrder = (SortOrder) data[QuandlQueryKeys.DatabaseCode];
            bool excludeHeader = (bool) data[QuandlQueryKeys.DatabaseCode];
            bool excludeData = (bool) data[QuandlQueryKeys.DatabaseCode];
            int? rows = (int?) data[QuandlQueryKeys.DatabaseCode];
            int? column = (int?) data[QuandlQueryKeys.DatabaseCode];
            CollapseType frequency = (CollapseType) data[QuandlQueryKeys.DatabaseCode];
            TransformationType calculation = (TransformationType) data[QuandlQueryKeys.DatabaseCode];

            Query query = new Query(databaseCode, tableCode, formatCode, authToken, trimStart, trimEnd, sortOrder,
                excludeHeader, excludeData, rows, column, frequency, calculation);

            // TODO: Create query string from the query, add ToString() method

            // TODO: Complete this method
            throw new NotImplementedException();
        }
    }

    internal static class QuandlQueryPathFactoryHelper
    {
        private static NumberParser numberParser = new NumberParser(NumberFormatUtilities.DecimalSeparatedNumberFormat);
        private static DateTimeParser dateTimeParser = new DateTimeParser("yyyy-MM-dd");
        
        public static Parser Parser = new Parser(numberParser, dateTimeParser);

        public static QueryParamGroup QueryParamGroup = new QueryParamGroup(new List<QueryParam>
        {
            new QueryParam(QuandlQueryKeys.DatabaseCode, DataType.String),
            new QueryParam(QuandlQueryKeys.TableCode, DataType.String),
            new QueryParam(QuandlQueryKeys.FormatCode, DataType.String),
            new QueryParam(QuandlQueryKeys.AuthToken, DataType.String, true),
            new QueryParam(QuandlQueryKeys.TrimStart, DataType.DateTime, true),
            new QueryParam(QuandlQueryKeys.TrimEnd, DataType.DateTime, true),
            new QueryParam(QuandlQueryKeys.SortOrder, DataType.DateTime, true),
            new QueryParam(QuandlQueryKeys.ExcludeHeader, DataType.Boolean, true),
            new QueryParam(QuandlQueryKeys.ExcludeData, DataType.Boolean, true),
            new QueryParam(QuandlQueryKeys.Rows, DataType.Integer, true),
            new QueryParam(QuandlQueryKeys.Column, DataType.Integer, true),
            new QueryParam(QuandlQueryKeys.Frequency, DataType.String, true),
            new QueryParam(QuandlQueryKeys.Calculation, DataType.String, true),
        });
    }

    // TODO: Perhaps these keys should be passed, rather than defined here statically

    internal static class QuandlQueryKeys
    {
        public static string DatabaseCode = "DatabaseCode";

        public static string TableCode = "TableCode";

        public static string FormatCode = "FormatCode";

        public static string AuthToken = "AuthToken";

        public static string TrimStart = "TrimStart";

        public static string TrimEnd = "TrimEnd";

        public static string SortOrder = "SortOrder";

        public static string ExcludeHeader = "ExcludeHeader";

        public static string ExcludeData = "ExcludeData";

        public static string Rows = "Rows";

        public static string Column = "Column";

        public static string Frequency = "Frequency";

        public static string Calculation = "Calculation";
    }
}
