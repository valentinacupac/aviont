using Optivem.OpenData.Domain;
using Optivem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Infrastructure.Web
{
    public class QueryStringMapSerializer : BaseQuerySerializer<Dictionary<string, string>>
    {
        // TODO: Parameter which indicates if key checking needs to occur, depending on whether source is trusted...

        public QueryStringMapSerializer(DataQuerySchema paramGroup, Parser parser, 
            IQuerySerializer<Dictionary<string, object>> objectMapSerializer)
            : base(paramGroup)
        {
            this.Parser = parser;
            this.ObjectMapSerializer = objectMapSerializer;
        }

        public Parser Parser { get; private set; }

        public IQuerySerializer<Dictionary<string, object>> ObjectMapSerializer { get; private set; }

        public override IQuery Deserialize(Dictionary<string, string> query)
        {
            Dictionary<string, object> map = ToObjectMap(query);
            return ObjectMapSerializer.Deserialize(map);
        }

        public override Dictionary<string, string> Serialize(IQuery query)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, object> ToObjectMap(Dictionary<string, string> query)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();

            foreach(KeyValuePair<string, string> entry in query)
            {
                string key = entry.Key;

                if(!QueryParamGroup.Contains(key))
                {
                    throw new ArgumentException("Query parameter key does not exist: " + key);
                }

                if (map.ContainsKey(key))
                {
                    throw new ArgumentException("Parameter key occurs multiple times: " + key);
                }

                DataField param = QueryParamGroup[key];

                string stringValue = entry.Value;
                object objectValue = null;

                if (!Parser.CanParse(param.Type))
                {
                    // TODO: Checking of parser recognizability should perhaps be done at the beginning?
                    throw new ArgumentException("Failed to convert parameter " + key + " because the data type " + param.Type.ToString() + " is not recognize type");
                }

                if(stringValue != null)
                {

                    try
                    {
                        objectValue = Parser.Parse(stringValue, param.Type);
                    }
                    catch(Exception ex)
                    {
                        // TODO: Perhaps should catch more specific exception?
                        // TODO: Also for data types, add human friendly versions, perhaps also custom exception
                        throw new ArgumentException("Failed to convert parameter " + key + " value " + stringValue + " to data type " + param.Type.ToString());
                    }
                }

                map.Add(key, objectValue);
            }

            return map;
        }
    }
}
