using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Optivem.OpenData.Quandl.Test
{
    [TestClass]
    public class QueryBuilderTest
    {
        [TestMethod]
        public void TestParamDefaults()
        {
            string databaseCode = "aaa";
            string tableCode = "bbb";
            FileType formatCode = FileType.CSV;

            QueryBuilder queryBuilder = new QueryBuilder(databaseCode, tableCode, formatCode);
            Query actual = queryBuilder.ToQuery();

            Query expected = new Query(databaseCode, tableCode, formatCode, 
                null, null, null, SortOrder.Descending, 
                false, false, null, null, 
                CollapseType.None, TransformationType.None);

            AreEqual(expected, actual);
        }

        private static void AreEqual(Query expected, Query actual)
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
