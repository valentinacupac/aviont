using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData
{
    /// <summary>
    /// Represents a group of related query parameters
    /// </summary>
    public class QueryParamGroup
    {
        private Dictionary<string, QueryParam> queryParams;

        /// <summary>
        /// Constructs a query parameter group
        /// </summary>
        /// <param name="queryParams">Series of query parameters</param>
        public QueryParamGroup(IEnumerable<QueryParam> queryParams)
        {
            this.queryParams = queryParams.ToDictionary(e => e.Key, e => e);
        }

        /// <summary>
        /// Retrieves a query parameter using a given key
        /// </summary>
        /// <param name="key">Key to retrieve the query parameter</param>
        /// <returns>Query parameter</returns>
        public QueryParam Get(string key)
        {
            return queryParams[key];
        }

        /// <summary>
        /// Retrieves a query parameter using a given key
        /// </summary>
        /// <param name="key">Key to retrieve the query parameter</param>
        /// <returns>Query parameter</returns>
        public QueryParam this[string key]
        {
            get
            {
                return Get(key);
            }
        }
    }
}
