using Interfaces;
using Models;
using System;
using System.Collections.Generic;

namespace TimeBinParser
{
    /// <summary>
    /// Parses the CSV result into time bins
    /// </summary>
    public class BinParser : IBinParser
    {
        public List<TimestampAndValue> GetMeanPerBin(TimeSpan timePerBin, List<TimestampAndValue> timestampAndValueList)
        {
            if (timestampAndValueList is null)
            {
                throw new ArgumentNullException(nameof(timestampAndValueList));
            }
            if (timestampAndValueList.Count == 0)
            {
                return timestampAndValueList;
            }

            List<TimestampAndValue> afterBinningList = new List<TimestampAndValue>();
            double valueSumPerBin = 0, mean = 0;
            int sampleCountPerBin = 0;
            DateTime binStartSample = timestampAndValueList[0].Timestamp;
            DateTime maxTimeStamp = binStartSample.Add(timePerBin);
            for (int i = 0; i < timestampAndValueList.Count; i++)
            {
                var timestampAndValue = timestampAndValueList[i];

                if (isSampleInSameBin(maxTimeStamp, timestampAndValue))
                {
                    valueSumPerBin += timestampAndValue.Sample;
                    sampleCountPerBin++;
                }
                else
                {
                    if (isBinWithNoSamples(sampleCountPerBin))
                    {
                        afterBinningList.Add(new TimestampAndValue() { Sample = 0, Timestamp = binStartSample });
                    }
                    else
                    {
                        mean = valueSumPerBin / sampleCountPerBin;
                        afterBinningList.Add(new TimestampAndValue() { Sample = mean, Timestamp = binStartSample });
                    }
                    binStartSample = binStartSample.Add(timePerBin);
                    maxTimeStamp = binStartSample.Add(timePerBin);
                    i--;
                    valueSumPerBin = 0;
                    sampleCountPerBin = 0;
                }

            }
            mean = valueSumPerBin / sampleCountPerBin;
            afterBinningList.Add(new TimestampAndValue() { Sample = mean, Timestamp = binStartSample });
            return afterBinningList;
        }

        private static bool isSampleInSameBin(DateTime maxTimeStamp, TimestampAndValue timestampAndValue)
        {
            return timestampAndValue.Timestamp < maxTimeStamp;
        }

        private static bool isBinWithNoSamples(int sampleCountPerBin)
        {
            return sampleCountPerBin == 0;
        }
    }
}
