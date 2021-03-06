﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Aviont.Domain
{
    /// <summary>
    /// Represents a series of parameters (for filtering, aggregation, computation) which would be performed on data - most of these are optional
    /// </summary>
    public class DataQuerySchema : IEnumerable<DataField>
    {
        private Dictionary<string, DataField> queryParams;

        /// <summary>
        /// Constructs a query parameter group
        /// </summary>
        /// <param name="queryParams">Series of query parameters</param>
        public DataQuerySchema(IEnumerable<DataField> queryParams)
        {
            this.queryParams = queryParams.ToDictionary(e => e.Key, e => e);
        }

        /// <summary>
        /// Retrieves a query parameter using a given key
        /// </summary>
        /// <param name="key">Key to retrieve the query parameter</param>
        /// <returns>Query parameter</returns>
        public DataField Get(string key)
        {
            return queryParams[key];
        }

        /// <summary>
        /// Indicates whether there exists a query paramter corresponding to a certain key
        /// </summary>
        /// <param name="key">Paramter key whose existence is being tested</param>
        /// <returns>True if there exists query parameter with the given key, false otherwise</returns>
        public bool Contains(string key)
        {
            return queryParams.ContainsKey(key);
        }

        /// <summary>
        /// Retrieves a query parameter using a given key
        /// </summary>
        /// <param name="key">Key to retrieve the query parameter</param>
        /// <returns>Query parameter</returns>
        public DataField this[string key]
        {
            get
            {
                return Get(key);
            }
        }

        public IEnumerator<DataField> GetEnumerator()
        {
            return queryParams.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
