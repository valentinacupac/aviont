using Optivem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData
{
    /// <summary>
    /// Definition of a query parameter
    /// </summary>
    public class QueryParam
    {
        /// <summary>
        /// Constructs a query parameter
        /// </summary>
        /// <param name="key">Represents the unique key by which this parameter is identified</param>
        /// <param name="dataType">Represents the type of data that the parameter can hold</param>
        /// <param name="isNullable">Indicates whether the data value can be null</param>
        public QueryParam(string key, DataType dataType, bool isNullable)
        {
            this.Key = key;
            this.DataType = dataType;
            this.IsNullable = isNullable;
        }

        /// <summary>
        /// Constructs a query parameter
        /// </summary>
        /// <param name="key">Represents the unique key by which this parameter is identified</param>
        /// <param name="dataType">Represents the type of data that the parameter can hold</param>
        public QueryParam(string key, DataType dataType)
            : this(key, dataType, false) { }

        /// <summary>
        /// Represents the unique key by which this parameter is identified
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Represents the type of data that the parameter can hold
        /// </summary>
        public DataType DataType { get; private set; }

        /// <summary>
        /// Indicates whether the data value can be null
        /// </summary>
        public bool IsNullable { get; private set; }
    }
}
