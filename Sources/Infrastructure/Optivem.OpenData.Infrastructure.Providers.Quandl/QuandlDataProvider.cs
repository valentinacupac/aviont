using Optivem.OpenData.Domain;
using Optivem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Infrastructure.Providers.Quandl
{
    /// <summary>
    /// Implementation of the Quandl data provider
    /// </summary>
    public class QuandlDataProvider : IDataProvider
    {
        // TODO: Refactor, configurability
        private static DataHeader STOCK_DATA_HEADER = new DataHeader(new DataField("StockData", CommonTypes.DateTime), new DataField("PriceValue", CommonTypes.Double));

        public DataSet ReadData(DataRequest request)
        {
            DataQuerySchema querySchema = QuandlQueryParamGroup.QueryParamGroup;
            Parser parser = QuandlQueryParser.Parser;

            IQuerySerializer<Dictionary<string, object>> objectMapSerializer = new QuandlQueryObjectMapSerializer();

            IQuery convertedQuery = objectMapSerializer.Deserialize(request.Query.Parameters);
            string url = convertedQuery.ToUrl();

            string results = null;

            using (QueryClient client = new QueryClient())
            {
                results = client.DownloadString(url);
            }



            // TODO: Move
            DataHeader dataHeader = STOCK_DATA_HEADER;

            // TODO: Should be dependent on data paramters passed in
            List<DataRecord> dataRecords = new List<DataRecord>();

            // TODO: Cleanup
            string[] lines = results.Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);

            foreach(string line in lines)
            {
                // TODO: Refactor and generalize

                string[] parts = line.Split(new char[] {','}, StringSplitOptions.None);

                object datePart = parser.Parse(parts[0], CommonTypes.DateTime);
                object pricePart = parser.Parse(parts[1], CommonTypes.Double);

                DataRecord record = new DataRecord(datePart, pricePart);

                dataRecords.Add(record);
            }

            return new DataSet(dataHeader, dataRecords);
        }
    }
}
