using Optivem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Domain
{
    /// <summary>
    /// Represents data field definition (key, type, nullability) for a data field
    /// </summary>
    public class DataField
    {
        /// <summary>
        /// Constructs a data field
        /// </summary>
        /// <param name="key">Represents the unique key by which this field is identified</param>
        /// <param name="dataType">Represents the type of data that the field can hold</param>
        /// <param name="isNullable">Indicates whether the data value in the field can be null</param>
        public DataField(string key, Type type, bool isNullable)
        {
            this.Key = key;
            this.Type = type;
            this.IsNullable = isNullable;
        }

        /// <summary>
        /// Constructs a data field
        /// </summary>
        /// <param name="key">Represents the unique key by which this field is identified</param>
        /// <param name="dataType">Represents the type of data that the field can hold</param>
        public DataField(string key, Type type)
            : this(key, type, false) { }

        /// <summary>
        /// Represents the unique key by which this field is identified
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Represents the type of data that the field can hold
        /// </summary>
        public Type Type { get; private set; }

        /// <summary>
        /// Indicates whether the data value of the field can be null
        /// </summary>
        public bool IsNullable { get; private set; }
    }
}
