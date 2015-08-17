using Optivem.Aviont.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Aviont.Infrastructure.Web
{
    public class QueryStringSerializer : BaseQuerySerializer<string>
    {
        private const int indexKey = 0;
        private const int indexValue = 1;

        private const int elementParts = 2;

        private string[] fieldSeparatorArray;
        private string[] valueSeparatorArray;

        public QueryStringSerializer(DataQuerySchema paramGroup, IQuerySerializer<Dictionary<string, string>> stringMapSerializer, string fieldSeparator, string valueSeparator, StringSplitOptions splitOptions, string[] nullStrings)
            : base(paramGroup)
        {
            this.StringMapSerializer = stringMapSerializer;
            this.FieldSeparator = fieldSeparator;
            this.ValueSeparator = valueSeparator;
            this.SplitOptions = splitOptions;
            this.NullStrings = nullStrings;

            this.fieldSeparatorArray = new [] { fieldSeparator };
            this.valueSeparatorArray = new [] { valueSeparator };
        }

        public IQuerySerializer<Dictionary<string, string>> StringMapSerializer { get; private set; }

        public string FieldSeparator { get; private set; }

        public string ValueSeparator { get; private set; }

        public StringSplitOptions SplitOptions { get; private set; }

        public string[] NullStrings { get; private set; }

        public override IQuery Deserialize(string query)
        {
            Dictionary<string, string> stringMap = ToStringMap(query);
            return StringMapSerializer.Deserialize(stringMap);
        }

        public override string Serialize(IQuery query)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, string> ToStringMap(string query)
        {
            string[] queryFields = query.Split(fieldSeparatorArray, SplitOptions);

            Dictionary<string, string> map = new Dictionary<string, string>();

            foreach(string queryField in queryFields)
            {
                string[] queryParts = queryField.Split(valueSeparatorArray, SplitOptions);

                if(queryParts.Length != elementParts)
                {
                    throw new ArgumentException("Failed to recognize part: " + queryField);
                }

                string key = queryParts[indexKey].Trim();
                string value = queryParts[indexValue].Trim();

                if(!QueryParamGroup.Contains(key))
                {
                    throw new ArgumentException("Failed to recognize parameter: " + key);
                }

                if(map.ContainsKey(key))
                {
                    throw new ArgumentException("The parameter appeared multiple times: " + key);
                }

                if(NullStrings.Contains(value))
                {
                    value = null;
                }

                map.Add(key, value);
            }

            return map;
        }

        protected string ToString(Dictionary<string, string> query)
        {
            throw new NotImplementedException();
        }


    }
}
