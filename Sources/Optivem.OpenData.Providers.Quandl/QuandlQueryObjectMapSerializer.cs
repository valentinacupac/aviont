using Optivem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Providers.Quandl
{
    public class QuandlQueryObjectMapSerializer : IQuerySerializer<Dictionary<string, object>>
    {
        public IQuery Deserialize(Dictionary<string, object> query)
        {
            // TODO: Add conversions for nullable objects
            // TODO: Add appropriate conversions for enums in utilities

            /*
            object databaseCodeObj = query[QuandlQueryKeys.DatabaseCode];
            object tableCodeObj = query[QuandlQueryKeys.TableCode];
            object formatCodeObj = query[QuandlQueryKeys.FormatCode];
            object authTokenObj = query[QuandlQueryKeys.AuthToken];
            object trimStartObj = query[QuandlQueryKeys.TrimStart];
            object trimEndObj = query[QuandlQueryKeys.TrimEnd];
            object sortOrderObj = query[QuandlQueryKeys.SortOrder];
            object excludeHeaderObj = query[QuandlQueryKeys.ExcludeHeader];
            object excludeDataObj = query[QuandlQueryKeys.ExcludeData];
            object rowsObj = query[QuandlQueryKeys.Rows];
            object columnObj = query[QuandlQueryKeys.Column];
            object frequencyObj = query[QuandlQueryKeys.Frequency];
            object calculationObj = query[QuandlQueryKeys.Calculation];
            */

            string databaseCode = (string)query[QuandlQueryKeys.DatabaseCode];
            string tableCode = (string)query[QuandlQueryKeys.TableCode];
            FileType formatCode = ConvertNonNullable<FileType>(query[QuandlQueryKeys.FormatCode]);
            string authToken = (string)query[QuandlQueryKeys.AuthToken];
            DateTime? trimStart = (DateTime?)query[QuandlQueryKeys.TrimStart];
            DateTime? trimEnd = (DateTime?)query[QuandlQueryKeys.TrimEnd];
            SortOrder sortOrder = ConvertNonNullable<SortOrder>(query[QuandlQueryKeys.SortOrder]);
            bool excludeHeader = ConvertNonNullable<bool>(query[QuandlQueryKeys.ExcludeHeader]);
            bool excludeData = ConvertNonNullable<bool>(query[QuandlQueryKeys.ExcludeData]);
            int? rows = (int?)query[QuandlQueryKeys.Rows];
            int? column = (int?)query[QuandlQueryKeys.Column];
            CollapseType frequency = ConvertNonNullable<CollapseType>(query[QuandlQueryKeys.Frequency]);
            TransformationType calculation = ConvertNonNullable<TransformationType>((TransformationType)query[QuandlQueryKeys.Calculation]);

            return new QuandlQuery(databaseCode, tableCode, formatCode, authToken, trimStart, trimEnd, sortOrder,
                excludeHeader, excludeData, rows, column, frequency, calculation);
        }

        public Dictionary<string, object> Serialize(IQuery query)
        {
            throw new NotImplementedException();
        }

        protected T ConvertNonNullable<T>(object obj, T defaultValue)
        {
            // TODO: Perhaps parameter arguments should also specify default value in case of nullability

            return obj != null ? (T)obj : defaultValue; 
        }

        protected T ConvertNonNullable<T>(object obj)
        {
            return ConvertNonNullable<T>(obj, default(T));
        }
    }







}
