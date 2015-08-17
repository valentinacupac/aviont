using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Aviont.Infrastructure.Readers
{
    /// <summary>
    /// Used for reading database records from SQL Database
    /// </summary>
    public class DatabaseRecordReader : BaseReader<object[], SqlDataReader>
    {
        public DatabaseRecordReader(SqlDataReader reader, int length)
            : base(reader)
        {
            this.Length = length;
        }

        public int Length { get; private set; }

        public override object[] Read()
        {
            if (!Reader.Read())
            {
                return null;
            }

            object[] record = new object[Length];
            Reader.GetValues(record);
            return record;
        }

        public override List<object[]> ReadToEnd()
        {
            List<object[]> records = new List<object[]>();

            object[] record = null;

            while ((record = Read()) != null)
            {
                records.Add(record);
            }

            return records;
        }
    }
}
