using System;

namespace BinaryClock.Universal.Features.Clock
{
    public class ClockViewModelDesign : ClockViewModel
    {
        public ClockViewModelDesign() : base()
        {
            base.LoadDateTime(DateTime.Now);
        }
    }
}
