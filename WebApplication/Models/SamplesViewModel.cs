using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class SamplesViewModel
    {
        public List<TimestampAndValue> EventList { get; set; }
        public List<TimestampAndValue> SampledList { get; set; }

    }
}
