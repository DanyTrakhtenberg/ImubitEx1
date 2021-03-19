using Models;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IBinParser
    {
        List<TimestampAndValue> GetMeanPerBin(TimeSpan timePerBin, List<TimestampAndValue> timestampAndValueList);
    }
}