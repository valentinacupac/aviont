using Optivem.OpenData.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Infrastructure.Providers.Quandl
{
    /// <summary>
    /// Represents a Quandl Query which specifies paramters needed to retrieve data
    /// </summary>
    public class QuandlQuery : IQuery
    {
        private const string URL_BASE = "https://www.quandl.com/api/v1/datasets/{0}/{1}.{2}";
        private const string URL_CONN = "?";
        private const string URL_AND = "&";
        private const string URL_ASSIGN = "=";

        internal static class Keys
        {
            public const string AuthToken = "auth_token";
            public const string TrimStart = "trim_start";
            public const string TrimEnd = "trim_end";
            public const string SortOrder = "sort_order";
            public const string ExcludeHeaders = "exclude_headers";
            public const string ExcludeData = "exclude_data";
            public const string Rows = "rows";
            public const string Column = "column";
            public const string Collapse = "collapse";
            public const string Transformation = "transformation";
        }

        public QuandlQuery(string databaseCode, string tableCode, FileType formatCode, 
            string authToken, DateTime? trimStart, DateTime? trimEnd, SortOrder sortOrder, 
            bool excludeHeader, bool excludeData, int? rows, int? column,
            CollapseType frequency, TransformationType calculation)
        {
            this.DatabaseCode = databaseCode;
            this.TableCode = tableCode;
            this.FormatCode = formatCode;
            this.AuthToken = authToken;
            this.TrimStart = trimStart;
            this.TrimEnd = trimEnd;
            this.SortOrder = sortOrder;
            this.ExcludeHeader = excludeHeader;
            this.ExcludeData = excludeData;
            this.Rows = rows;
            this.Column = column;
            this.Frequency = frequency;
            this.Calculation = calculation;
        }

        /// <summary>
        /// Represents the unique Quandl code which identifies the database
        /// </summary>
        public string DatabaseCode { get; private set; }

        /// <summary>
        /// Represents the Quandl code which identifies the table
        /// </summary>
        public string TableCode { get; private set; }

        /// <summary>
        /// Represents the type of the file in which data will be downloaded
        /// </summary>
        public FileType FormatCode { get; private set; }

        /// <summary>
        /// Represents the authentication token
        /// </summary>
        public string AuthToken { get; private set; }

        /// <summary>
        /// Represents the start date from which data should be retrieved
        /// </summary>
        public DateTime? TrimStart { get; private set; }

        /// <summary>
        /// Represents the end date up to which data should be retrieved
        /// </summary>
        public DateTime? TrimEnd { get; private set; }

        /// <summary>
        /// Represents the sort order
        /// </summary>
        public SortOrder SortOrder { get; private set; }

        /// <summary>
        /// Represents whether headers should be excluded
        /// </summary>
        public bool ExcludeHeader { get; private set; }

        /// <summary>
        /// Represents whether data records should be excluded
        /// </summary>
        public bool ExcludeData { get; private set; }

        /// <summary>
        /// Indicates that query should retrieve only the first N rows of the dataset
        /// </summary>
        public int? Rows { get; private set; }

        /// <summary>
        /// Indicates that the query should retrieve only the specific column N
        /// </summary>
        public int? Column { get; private set; }

        /// <summary>
        /// Indicates frequency of the dataset, whereby Quandl will return only the last observation for the given period
        /// </summary>
        public CollapseType Frequency { get; private set; }

        /// <summary>
        /// Represents the transformation which can be applied to data set prior to downloading
        /// </summary>
        public TransformationType Calculation { get; private set; }

        // TODO: Perhaps url creation is separate?
        public string ToUrl()
        {
            string basePart = GetBaseUrl();
            string queryPart = GetQueryUrl();

            string combined = basePart;

            if(queryPart.Length > 0)
            {
                combined = basePart + URL_CONN + queryPart;
            }

            return combined;
        }

        private string GetBaseUrl()
        {
            return string.Format(URL_BASE, DatabaseCode, TableCode, QuandlUrlConverter.ToString(FormatCode));
        }

        private string GetQueryUrl()
        {
            Dictionary<string, string> parts = new Dictionary<string, string>
            {
                { Keys.SortOrder, QuandlUrlConverter.ToString(SortOrder) },
                { Keys.ExcludeHeaders, QuandlUrlConverter.ToString(ExcludeHeader) },
                { Keys.ExcludeData, QuandlUrlConverter.ToString(ExcludeData) },
                { Keys.Collapse, QuandlUrlConverter.ToString(Frequency) },
                { Keys.Transformation, QuandlUrlConverter.ToString(Calculation) } 
            };

            if(AuthToken != null)
            {
                parts.Add(Keys.AuthToken, AuthToken);
            }

            if(TrimStart != null)
            {
                parts.Add(Keys.TrimStart, QuandlUrlConverter.ToString(TrimStart.Value));
            }

            if(TrimEnd != null)
            {
                parts.Add(Keys.TrimEnd, QuandlUrlConverter.ToString(TrimEnd.Value));
            }

            if(Rows != null)
            {
                parts.Add(Keys.Rows, QuandlUrlConverter.ToString(Rows.Value));
            }

            if(Column != null)
            {
                parts.Add(Keys.Column, QuandlUrlConverter.ToString(Column.Value));
            }

            List<string> elements = new List<string>();

            foreach(KeyValuePair<string, string> entry in parts)
            {
                elements.Add(entry.Key + URL_ASSIGN + entry.Value);
            }

            return string.Join(URL_AND, elements);
        }
    }
}
