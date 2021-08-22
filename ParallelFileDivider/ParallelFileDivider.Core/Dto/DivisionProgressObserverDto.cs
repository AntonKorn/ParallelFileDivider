using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core.Dto
{
    public class DivisionProgressObserverDto
    {
        public Action<(int Progress, int WorkerNumber)> ProgressChangedCallback { get; set; }
        public int ExpectedProgressPrecision { get; set; } = 10000;
    }
}
