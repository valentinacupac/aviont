using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Quandl.Utilities
{
    /// <summary>
    /// Utility conversion class of objects to strings for API calls
    /// </summary>
    internal static class Converter
    {
        private const string _dateFormat = "yyyy-mm-dd";

        private static Dictionary<FileType, string> _fileTypes = new Dictionary<FileType, string>
        {
            { FileType.CSV, "csv" },
            { FileType.JSON, "json"},
            { FileType.XML, "xml" }
        };

        private static Dictionary<CollapseType, string> _collapseTypes = new Dictionary<CollapseType, string>
        {
            { CollapseType.None, "none" },
            { CollapseType.Daily, "daily" },
            { CollapseType.Weekly, "weekly" },
            { CollapseType.Monthly, "monthly" },
            { CollapseType.Quarterly, "quarterly" },
            { CollapseType.Annual, "annual" }
        };

        private static Dictionary<SortOrder, string> sortOrders = new Dictionary<SortOrder, string>
        {
            { SortOrder.Descending, "desc" },
            { SortOrder.Ascending, "asc" }
        };

        private static Dictionary<TransformationType, string> transformationTypes = new Dictionary<TransformationType, string>
        {
            { TransformationType.Diff, "diff" },
            { TransformationType.Rdiff, "rdiff" },
            { TransformationType.Cumul, "cumul" },
            { TransformationType.Normalize, "normalize" } 
        };

        /// <summary>
        /// Converts CollapseType to string
        /// </summary>
        /// <param name="collapseType">Value to be converted</param>
        /// <returns>Converted string</returns>
        public static string ToString(CollapseType collapseType)
        {
            return _collapseTypes[collapseType];
        }

        /// <summary>
        /// Converts CollapseType to string
        /// </summary>
        /// <param name="collapseType">Value to be converted</param>
        /// <returns>Converted string</returns>
        public static string ToString(DateTime dateTime)
        {
            return dateTime.ToString(_dateFormat);
        }

        /// <summary>
        /// Converts FileType to string
        /// </summary>
        /// <param name="collapseType">Value to be converted</param>
        /// <returns>Converted string</returns>
        public static string ToString(FileType fileType)
        {
            return _fileTypes[fileType];
        }

        /// <summary>
        /// Converts SortOrder to string
        /// </summary>
        /// <param name="collapseType">Value to be converted</param>
        /// <returns>Converted string</returns>
        public static string ToString(SortOrder sortOrder)
        {
            return sortOrders[sortOrder];
        }

        /// <summary>
        /// Converts TransformationType to string
        /// </summary>
        /// <param name="collapseType">Value to be converted</param>
        /// <returns>Converted string</returns>
        public static string ToString(TransformationType transformationType)
        {
            return transformationTypes[transformationType];
        }
    }
}
