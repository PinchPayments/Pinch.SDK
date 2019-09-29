using System;
using System.Collections.Generic;

namespace Pinch.SDK.Plans
{
    public class PlanFreePeriodSaveOptions
    {
        public int StartDateOffset { get; set; }
        public string StartDateInterval { get; set; }
        public int DurationOffset { get; set; }
        public string DurationInterval { get; set; }
        public string Metadata { get; set; }
        public List<ApiError> Errors { get; set; }
    }
}