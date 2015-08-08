using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Infrastructure
{
    public class FieldSchema
    {
        public FieldSchema(string name, Type type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; private set; }

        public Type Type { get; private set; }
    }
}
