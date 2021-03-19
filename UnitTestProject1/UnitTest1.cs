using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;
using TimeBinParser;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        BinParser _binParser = new BinParser();
        
        [TestMethod]
        public void BinParserTest1()
        {
            List<TimestampAndValue> timestampAndValuesList = new List<TimestampAndValue>();
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 0.4, Timestamp = new DateTime(2021, 1, 1, 0, 0, 0, 0) });
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 0.0, Timestamp = new DateTime(2021, 1, 1, 0, 1, 0, 0) });
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 1.0, Timestamp = new DateTime(2021, 1, 1, 0, 2, 0, 0) });
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 2.1, Timestamp = new DateTime(2021, 1, 1, 0, 3, 0, 0) });
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 2.1, Timestamp = new DateTime(2021, 1, 1, 0, 4, 0, 0) });
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 8.0, Timestamp = new DateTime(2021, 1, 1, 0, 5, 0, 0) });
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 4.8, Timestamp = new DateTime(2021, 1, 1, 0, 6, 0, 0) });
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 7.0, Timestamp = new DateTime(2021, 1, 1, 0, 7, 0, 0) });
            var binResult = _binParser.GetMeanPerBin(new TimeSpan(0, 0, 5, 0), timestampAndValuesList);
            Assert.AreEqual(Math.Round(binResult[0].Sample,2), 1.12);
        }
        [TestMethod]
        public void BinParserTest2_finalSampleAfter20MinuetsTheLast()
        {
            List<TimestampAndValue> timestampAndValuesList = new List<TimestampAndValue>();
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 0.4, Timestamp = new DateTime(2021, 1, 1, 0, 0, 0, 0) });
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 0.0, Timestamp = new DateTime(2021, 1, 1, 0, 1, 0, 0) });
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 1.0, Timestamp = new DateTime(2021, 1, 1, 0, 2, 0, 0) });
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 2.1, Timestamp = new DateTime(2021, 1, 1, 0, 3, 0, 0) });
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 2.1, Timestamp = new DateTime(2021, 1, 1, 0, 4, 0, 0) });
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 8.0, Timestamp = new DateTime(2021, 1, 1, 0, 5, 0, 0) });
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 4.8, Timestamp = new DateTime(2021, 1, 1, 0, 6, 0, 0) });
            timestampAndValuesList.Add(new TimestampAndValue() { Sample = 7.0, Timestamp = new DateTime(2021, 1, 1, 0, 20, 0, 0) });
            var binResult = _binParser.GetMeanPerBin(new TimeSpan(0, 0, 5, 0), timestampAndValuesList);
            Assert.AreEqual(Math.Round(binResult[0].Sample, 2), 1.12);
            Assert.AreEqual(Math.Round(binResult[4].Sample, 0), 7);
        }
    }
}
