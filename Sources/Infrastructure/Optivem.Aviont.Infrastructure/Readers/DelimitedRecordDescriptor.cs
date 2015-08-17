using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Aviont.Infrastructure.Readers
{
    public class DelimitedRecordDescriptor
    {
        public DelimitedRecordDescriptor(string fieldDelimiter, string lineDelimiter, bool hasHeader, string[] naSymbols, Type[] types)
        {
            this.FieldDelimiter = fieldDelimiter;
            this.LineDelimiter = lineDelimiter;
            this.HasHeader = hasHeader;
            this.NaSymbols = naSymbols;
            this.Types = types;
        }

        public string FieldDelimiter { get; private set; }

        public string LineDelimiter { get; private set; }

        public bool HasHeader { get; private set; }

        public string[] NaSymbols { get; private set; }

        public Type[] Types { get; private set; }
    }
}
