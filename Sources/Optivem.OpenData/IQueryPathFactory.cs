using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData
{
    /// <summary>
    /// Interface for constructing Url paths based on parameters
    /// </summary>
    public interface IQueryPathFactory
    {
        /// <summary>
        /// Creates a Url path
        /// </summary>
        /// <param name="data">Input key-value parameters for constructing the url</param>
        /// <returns>Url path which was constructed using the parameters</returns>
        string Create(Dictionary<string, string> data);
    }
}
