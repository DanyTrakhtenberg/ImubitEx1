using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISampleDate
    {
        Task<List<TimestampAndValue>> GetSamples();
    }
}
