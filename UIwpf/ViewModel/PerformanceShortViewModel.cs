using System;
using System.Collections.Generic;
using System.Text;
using Theater;

namespace UIwpf.ViewModel
{
    internal class PerformanceShortViewModel
    {
        
            private Performance performance;

            public PerformanceShortViewModel(Performance performance)
            {
                this.performance = performance;
            }

            public string FIO
            {
                get => performance.NamePerformance;
            }
    }
}
