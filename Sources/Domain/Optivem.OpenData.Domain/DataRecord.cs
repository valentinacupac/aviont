using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Domain
{
    /// <summary>
    /// Represents a data record
    /// </summary>
    public class DataRecord
    {
        public DataRecord(params object[] values)
        {
            this.Values = values;
        }

        public object[] Values { get; private set; }

        public override bool Equals(object obj)
        {
            return Values.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Values.GetHashCode();
        }
    }
}
