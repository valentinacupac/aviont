using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Quandl
{
    /// <summary>
    /// Represents the sampling frequency
    /// </summary>
    public enum CollapseType
    {
        /// <summary>
        /// No collapse should be applied
        /// </summary>
        None,

        /// <summary>
        /// Returns the last data point for each day
        /// </summary>
        Daily,

        /// <summary>
        /// Returns the last data point for each week
        /// </summary>
        Weekly,

        /// <summary>
        /// Returns the last data point for each month
        /// </summary>
        Monthly,

        /// <summary>
        /// Returns the last data point for each quarter
        /// </summary>
        Quarterly,

        /// <summary>
        /// Returns the last data point for each year
        /// </summary>
        Annual
    }
}
