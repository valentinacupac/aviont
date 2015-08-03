using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Domain.Providers.Quandl
{
    /// <summary>
    /// Builder for Quandl queries (using fluent syntax)
    /// </summary>
    public class QuandlQueryBuilder
    {
        /// <summary>
        /// Constructs the builder
        /// </summary>
        /// <param name="databaseCode">Represents the unique Quandl code which identifies the database</param>
        /// <param name="tableCode">Represents the Quandl code which identifies the table</param>
        /// <param name="formatCode">Represents the type of the file in which data will be downloaded</param>
        public QuandlQueryBuilder(string databaseCode, string tableCode, FileType formatCode)
        {
            this.DatabaseCode = databaseCode;
            this.TableCode = tableCode;
            this.FormatCode = formatCode;
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

        /// <summary>
        /// Sets the authentication code
        /// </summary>
        /// <param name="authToken">Represents the authentication token</param>
        /// <returns>The current builder instance</returns>
        public QuandlQueryBuilder SetAuthToken(string authToken)
        {
            this.AuthToken = authToken;
            return this;
        }

        /// <summary>
        /// Represents the start and end date from which data should be retrieved
        /// </summary>
        /// <param name="trimStart">Represents the start date from which data should be retrieved</param>
        /// <param name="trimEnd">Represents the end date up to which data should be retrieved</param>
        /// <returns>The current builder instance</returns>
        public QuandlQueryBuilder SetTrimRange(DateTime trimStart, DateTime trimEnd)
        {
            this.TrimStart = trimStart;
            this.TrimEnd = trimEnd;
            return this;
        }

        /// <summary>
        /// Sets the sort order
        /// </summary>
        /// <param name="sortOrder">Represents the sort order</param>
        /// <returns>The current builder instance</returns>
        public QuandlQueryBuilder SetSortOrder(SortOrder sortOrder)
        {
            this.SortOrder = sortOrder;
            return this;
        }

        /// <summary>
        /// Sets whether the header should be excluded from the download
        /// </summary>
        /// <param name="excludeHeader">Indicates that the header should be excluded</param>
        /// <returns>The current builder instance</returns>
        public QuandlQueryBuilder SetExcludeHeader(bool excludeHeader)
        {
            this.ExcludeHeader = excludeHeader;
            return this;
        }

        /// <summary>
        /// Sets whether the data should be excluded from the download
        /// </summary>
        /// <param name="excludeData">Indicates that the data should be excluded</param>
        /// <returns>The current builder instance</returns>
        public QuandlQueryBuilder SetExcludeData(bool excludeData)
        {
            this.ExcludeData = excludeData;
            return this;
        }

        /// <summary>
        /// Sets the row count of the first N rows which should be retrieved
        /// </summary>
        /// <param name="rows">Number of rows which should be retrieved</param>
        /// <returns>The current builder instance</returns>
        public QuandlQueryBuilder SetRows(int? rows)
        {
            this.Rows = rows;
            return this;
        }

        /// <summary>
        /// Sets the column which should be retrieved
        /// </summary>
        /// <param name="column">Column number</param>
        /// <returns>The current builder instance</returns>
        public QuandlQueryBuilder SetColumn(int? column)
        {
            this.Column = column;
            return this;
        }

        /// <summary>
        /// Sets the frequency at which collapse should occur
        /// </summary>
        /// <param name="frequency">Collpase frequency</param>
        /// <returns>The current builder instance</returns>
        public QuandlQueryBuilder SetFrequency(CollapseType frequency)
        {
            this.Frequency = frequency;
            return this;
        }

        /// <summary>
        /// Sets the transformation type which should be applied prior to download
        /// </summary>
        /// <param name="calculation">Transformation type which should be applied</param>
        /// <returns>The current builder instance</returns>
        public QuandlQueryBuilder SetCalculation(TransformationType calculation)
        {
            this.Calculation = calculation;
            return this;
        }

        /// <summary>
        /// Constructs the query
        /// </summary>
        /// <returns>Query instance</returns>
        public QuandlQuery ToQuery()
        {
            return new QuandlQuery(DatabaseCode, TableCode, FormatCode, AuthToken,
                TrimStart, TrimEnd, SortOrder, ExcludeHeader, ExcludeData,
                Rows, Column, Frequency, Calculation);
        }
    }
}
