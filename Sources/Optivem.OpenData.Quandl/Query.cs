using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Quandl
{
    /// <summary>
    /// Represents a Quandl Query which specifies paramters needed to retrieve data
    /// </summary>
    public class Query
    {
        public Query(string databaseCode, string tableCode, FileType formatCode, 
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
    }
}
