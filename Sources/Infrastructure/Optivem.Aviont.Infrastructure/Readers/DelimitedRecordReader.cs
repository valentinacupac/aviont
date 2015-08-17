using Optivem.Immerest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Aviont.Infrastructure.Readers
{
    /// <summary>
    /// Used for reading delimited text (e.g. comman-delimited, tab-delimited formats)
    /// </summary>
    public class DelimitedRecordReader : BaseReader<object[], TextReader>
    {
        private bool _readFirst;

        public DelimitedRecordReader(TextReader reader, DelimitedRecordDescriptor descriptor, Parser parser)
            : base(reader)
        {
            this.Descriptor = descriptor;
            this.Parser = parser;
        }

        public DelimitedRecordDescriptor Descriptor { get; private set; }

        public Parser Parser { get; private set; }

        public override object[] Read()
        {
            string line = Reader.ReadLine();

            if (line != null && !_readFirst)
            {
                line = Reader.ReadLine();
                _readFirst = true;
            }

            if (line == null)
            {
                return null;
            }

            string[] parts = line.Split(new[] { Descriptor.FieldDelimiter }, StringSplitOptions.None);

            int length = Descriptor.Types.Length;
            if (parts.Length != length)
            {
                throw new ArgumentException();
            }

            object[] record = new object[length];

            for (int i = 0; i < length; i++)
            {
                // TODO: Treat empty string as null?
                record[i] = Parser.Parse(parts[i], Descriptor.Types[i]);
            }

            return record;
        }

        public override List<object[]> ReadToEnd()
        {
            List<object[]> records = new List<object[]>();

            object[] record = null;

            while ((record = Read()) != null)
            {
                if (record != null && !_readFirst)
                {
                    record = Read();
                    _readFirst = true;
                }

                records.Add(record);
            }

            return records;
        }
    }
}
