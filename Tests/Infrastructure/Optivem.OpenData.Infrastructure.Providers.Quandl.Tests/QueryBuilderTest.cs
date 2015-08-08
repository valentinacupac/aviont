using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Optivem.Utilities;
using System.Collections.Generic;
using Optivem.OpenData.Domain;
using Optivem.OpenData.Infrastructure.Providers.Quandl;

namespace Optivem.OpenData.Infrastructure.Providers.Quandl.Tests
{
    [TestClass]
    public class QueryBuilderTest
    {
        private const float FLOAT_DELTA = 0.0001F;
        private const double DOUBLE_DELTA = 0.0001;

        [TestMethod]
        public void TestCase1()
        {
            string databaseCode = "aaa";
            string tableCode = "bbb";
            FileType formatCode = FileType.CSV;

            QuandlQueryBuilder queryBuilder = new QuandlQueryBuilder(databaseCode, tableCode, formatCode);
            QuandlQuery actual = queryBuilder.ToQuery();

            QuandlQuery expected = new QuandlQuery(databaseCode, tableCode, formatCode, 
                null, null, null, SortOrder.Descending, 
                false, false, null, null, 
                CollapseType.None, TransformationType.None);

            AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCase2()
        {
            // Web url is: https://www.quandl.com/api/v1/datasets/WIKI/AAPL.csv?sort_order=asc&exclude_headers=true&rows=3&trim_start=2012-11-01&trim_end=2013-11-30&column=4&collapse=quarterly&transformation=rdiff

            DataField[] expectedDataFields = new DataField[] { new DataField("StockData", CommonTypes.DateTime), new DataField("PriceValue", CommonTypes.Double) };
            DataHeader expectedHeader = new DataHeader(expectedDataFields);

            List<DataRecord> expectedDataRecords = new List<DataRecord>
            {
                new DataRecord(new DateTime(2013, 3, 31), -0.16820266496096),
                new DataRecord(new DateTime(2013, 6, 30), -0.10421090679077),
                new DataRecord(new DateTime(2013, 9, 30), 0.2023049958389),
            };

            DataSet expectedDataSet = new DataSet(expectedHeader, expectedDataRecords);

            QuandlDataProvider provider = new QuandlDataProvider();

            Dictionary<string, string> dataPathParams = new Dictionary<string, string>()
            {
                { "DatabaseCode", "WIKI" },
                { "TableCode", "AAPL" },
                { "FormatCode", "CSV" },
            };

            Dictionary<string, object> dataQueryParams = new Dictionary<string,object>
            {
                { "DatabaseCode", "WIKI" },
                { "TableCode", "AAPL" },
                { "FormatCode", FileType.CSV },
                { "AuthToken", null },
                { "TrimStart", new DateTime(2012, 11, 1)},
                { "TrimEnd", new DateTime(2013, 11, 30) },
                { "SortOrder", SortOrder.Ascending },
                { "ExcludeHeader", true },
                { "ExcludeData", null },
                { "Rows", 3},
                { "Column", 4},
                { "Frequency", CollapseType.Quarterly },
                { "Calculation", TransformationType.Rdiff }
            };

            // TODO: Make it typed

            DataPath dataPath = new DataPath(dataPathParams);
            DataQuery dataQuery = new DataQuery(dataQueryParams);

            DataRequest request = new DataRequest(dataPath, dataQuery);

            DataSet actualDataSet = provider.ReadData(request);

            AreEqual(expectedDataSet, actualDataSet);
        }

        private static void AreEqual(QuandlQuery expected, QuandlQuery actual)
        {
            Assert.AreEqual(expected.DatabaseCode, actual.DatabaseCode);
            Assert.AreEqual(expected.TableCode, actual.TableCode);
            Assert.AreEqual(expected.FormatCode, actual.FormatCode);
            Assert.AreEqual(expected.AuthToken, actual.AuthToken);
            Assert.AreEqual(expected.TrimStart, actual.TrimStart);
            Assert.AreEqual(expected.TrimEnd, actual.TrimEnd);
            Assert.AreEqual(expected.SortOrder, actual.SortOrder);
            Assert.AreEqual(expected.ExcludeHeader, actual.ExcludeHeader);
            Assert.AreEqual(expected.ExcludeData, actual.ExcludeData);
            Assert.AreEqual(expected.Rows, actual.Rows);
            Assert.AreEqual(expected.Column, actual.Column);
            Assert.AreEqual(expected.Frequency, actual.Frequency);
            Assert.AreEqual(expected.Calculation, actual.Calculation);
        }

        private static void AreEqual(DataSet expected, DataSet actual)
        {
            Assert.AreEqual(expected.Header.Fields.Length, actual.Header.Fields.Length);

            int numFields = expected.Header.Fields.Length;

            for (int i = 0; i < numFields; i++)
            {
                DataField expectedField = expected.Header.Fields[i];
                DataField actualField = actual.Header.Fields[i];

                Assert.AreEqual(expectedField.Key, actualField.Key);
                Assert.AreEqual(expectedField.Type, actualField.Type);
                Assert.AreEqual(expectedField.IsNullable, actualField.IsNullable);
            }

            Assert.AreEqual(expected.Records.Count, actual.Records.Count);

            int recordCount = expected.Records.Count;

            for(int i = 0; i < recordCount; i++)
            {
                DataRecord expectedRecord = expected.Records[i];
                DataRecord actualRecord = actual.Records[i];

                Assert.AreEqual(expectedRecord.Values.Length, actualRecord.Values.Length);

                int fieldCount = expectedRecord.Values.Length;

                for(int j = 0; j < fieldCount; j++)
                {
                    object expectedValue = expectedRecord.Values[j];
                    object actualValue = actualRecord.Values[j];

                    if(expectedValue != null && actualValue != null && expectedValue.GetType() == CommonTypes.Float && actualValue.GetType() == CommonTypes.Float)
                    {
                        Assert.AreEqual((float)expectedValue, (float)actualValue, FLOAT_DELTA);
                    }
                    else if(expectedValue != null && actualValue != null && expectedValue.GetType() == CommonTypes.Double && actualValue.GetType() == CommonTypes.Double)
                    {
                        Assert.AreEqual((double)expectedValue, (double)actualValue, DOUBLE_DELTA);
                    }
                    else
                    {
                        Assert.AreEqual(expectedValue, actualValue);
                    }
                }
            }
        }
    }
}
