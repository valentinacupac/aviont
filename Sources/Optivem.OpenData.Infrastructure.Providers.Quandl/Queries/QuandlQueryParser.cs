using Optivem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Infrastructure.Providers.Quandl
{
    public static class QuandlQueryParser
    {
        private static NumberParser numberParser = new NumberParser(NumberFormatUtilities.DecimalSeparatedNumberFormat);
        private static DateTimeParser dateTimeParser = new DateTimeParser("yyyy-MM-dd");
        private static BooleanParser booleanParser = new BooleanParser();
        private static EnumParser enumParser = new EnumParser(true);

        private static HashSet<Type> enumTypes = new HashSet<Type>
        {
            QuandlTypes.CollapseType,
            QuandlTypes.FileType,
            QuandlTypes.SortOrder,
            QuandlTypes.TransformationType
        };

        public static Parser Parser = ParserFactory.CreateParser(numberParser, dateTimeParser, enumTypes, booleanParser, enumParser);
    }
}
