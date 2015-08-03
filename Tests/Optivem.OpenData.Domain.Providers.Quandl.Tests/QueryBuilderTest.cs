using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Optivem.Utilities;
using System.Collections.Generic;
using Optivem.OpenData.Domain;
using Optivem.OpenData.Domain.Providers.Quandl;

namespace Optivem.OpenData.Domain.Providers.Quandl.Tests
{
    [TestClass]
    public class QueryBuilderTest
    {
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

            List<string> lines = new List<string>
            {
                "2013-03-31,-0.16820266496096",
                "2013-06-30,-0.10421090679077",
                "2013-09-30,0.2023049958389"
            };

            string expectedResults = string.Join("\n", lines) + "\n";

            QueryParamGroup queryParamGroup = QuandlQueryParamGroup.QueryParamGroup;
            Parser parser = QuandlQueryParser.Parser;


            IQuerySerializer<Dictionary<string, object>> objectMapSerializer = new QuandlQueryObjectMapSerializer();

            QueryStringMapSerializer stringMapSerializer = new QueryStringMapSerializer(queryParamGroup, parser, objectMapSerializer);
            
            string fieldSeparator = ",";
            string valueSeparator = ":";
            StringSplitOptions splitOptions = StringSplitOptions.RemoveEmptyEntries;
            string[] nullStrings = new string[] { "NULL" };
            
            QueryStringSerializer stringSerializer = new QueryStringSerializer(queryParamGroup, stringMapSerializer, fieldSeparator, valueSeparator, splitOptions, nullStrings);

            string input = "DatabaseCode:WIKI,TableCode:AAPL,FormatCode:CSV,AuthToken:NULL,TrimStart:2012-11-01,TrimEnd:2013-11-30,SortOrder:Ascending,ExcludeHeader:true,ExcludeData:NULL,Rows:3,Column:4,Frequency:Quarterly,Calculation:rdiff";

            IQuery query = stringSerializer.Deserialize(input);
            string url = query.ToUrl();


            // TODO: Also add conversion from ready-made url into an actual object, which means if user had already done query, that he/she
            // can also save that query directly, and it will be converted into some internal representation

            string actualResults = null;

            using(QueryClient client = new QueryClient())
            {
                actualResults = client.DownloadString(url);
            }


            Assert.AreEqual(expectedResults, actualResults);


            // https://www.quandl.com/api/v1/datasets/WIKI/AAPL.csv?sort_order=asc&exclude_headers=true&rows=3&trim_start=2012-11-01&trim_end=2013-11-30&column=4&collapse=quarterly&transformation=rdiff
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
    }
}
