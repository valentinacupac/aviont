using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Providers.Quandl
{
    /// <summary>
    /// Represents elementary calculation which can be performed on data
    /// </summary>
    public enum TransformationType
    {
        /// <summary>
        /// No transformation will be performed
        /// </summary>
        None,

        /// <summary>
        /// Represents row-on-row change transformation, whereby y'[t] = y[t] - y[t-1]
        /// </summary>
        Diff,

        /// <summary>
        /// Represents row-on-row-percentage-change transformation, whereby y'[t] = (y[t] - y[t-1])/y[t-1]
        /// </summary>
        Rdiff,

        /// <summary>
        /// Represents cumulative-sum transformation, whereby y'[t] = y[t] +y[t-1] + ... + y[0]
        /// </summary>
        Cumul,

        // Represents start-at-100 transformation, whereby y'[t] = (y[t]/y[0]) * 100
        Normalize
    }
}
