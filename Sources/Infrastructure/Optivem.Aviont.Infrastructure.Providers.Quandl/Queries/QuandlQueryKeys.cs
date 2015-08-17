using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Aviont.Infrastructure.Providers.Quandl
{
    // TODO: Perhaps these keys should be passed, rather than defined here statically

    internal static class QuandlQueryKeys
    {
        public static string DatabaseCode = "DatabaseCode";

        public static string TableCode = "TableCode";

        public static string FormatCode = "FormatCode";

        public static string AuthToken = "AuthToken";

        public static string TrimStart = "TrimStart";

        public static string TrimEnd = "TrimEnd";

        public static string SortOrder = "SortOrder";

        public static string ExcludeHeader = "ExcludeHeader";

        public static string ExcludeData = "ExcludeData";

        public static string Rows = "Rows";

        public static string Column = "Column";

        public static string Frequency = "Frequency";

        public static string Calculation = "Calculation";
    }
}
