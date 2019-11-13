using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Subscriptions
{
    public class SubscriptionFreePeriod
    {
        public string StartDate { get; set; }
        public int DurationOffset { get; set; }
        public string DurationInterval { get; set; }
        public string Metadata { get; set; }
    }
}
