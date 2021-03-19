using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace FileParser
{
    public class CSVsamles : ISampleDate
    {
        public string Path { get; set; }
        public CSVsamles()
        {
            Path = "Events.csv";
        }
         public async Task<List<TimestampAndValue>> GetSamples()
        {
            List<TimestampAndValue> returnedSamples = new List<TimestampAndValue>();
            using (var reader = new StreamReader(Path))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    var values = line.Split(',');
                    TimestampAndValue timestampAndValue = new TimestampAndValue();
                    timestampAndValue.Timestamp = DateTime.Parse(values[0], CultureInfo.CurrentCulture);

                    timestampAndValue.Sample = double.Parse(values[1]);
                    returnedSamples.Add(timestampAndValue);
                }
            }
            return returnedSamples;
        }
    }
}
