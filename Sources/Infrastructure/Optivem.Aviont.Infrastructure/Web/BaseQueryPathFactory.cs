﻿using Optivem.Aviont.Domain;
using Optivem.Immerest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Aviont.Infrastructure.Web
{
    public abstract class BaseQueryPathFactory
    {
        public BaseQueryPathFactory(Parser parser, DataQuerySchema queryParamGroup)
        {
            this.Parser = parser;
            this.QueryParamGroup = queryParamGroup;
        }

        public Parser Parser { get; private set; }

        public DataQuerySchema QueryParamGroup { get; private set; }

        public string Create(Dictionary<string, string> data)
        {
            Dictionary<string, object> convertedData = GetConvertedData(data);
            return Create(convertedData);
        }

        protected abstract string Create(Dictionary<string, object> data);

        private Dictionary<string, object> GetConvertedData(Dictionary<string, string> data)
        {
            Dictionary<string, object> convertedData = new Dictionary<string, object>();

            foreach (KeyValuePair<string, string> e in data)
            {
                string key = e.Key;
                string value = e.Value;

                DataField queryParam = QueryParamGroup[key];
                Type dataType = queryParam.Type;
                bool isNullable = queryParam.IsNullable;

                object convertedValue = null;

                if (string.IsNullOrWhiteSpace(value))
                {
                    if (isNullable)
                    {
                        convertedValue = null;
                    }
                    else
                    {
                        throw new ArgumentNullException("Query parameter " + key + " must not be null.");
                    }
                }
                else
                {
                    convertedValue = Parser.Parse(value, dataType);
                }
            }

            return convertedData;
        }
    }
}
