using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core.Dto
{
    public class JoinProgressObsererDto
    {
        public long ExpectedDestiationFileSize { get; set; }
        public Action<(int Progress, int WorkerNumber)> ProgressChangedCallback { get; set; }
        public int ExpectedProgressPrecision { get; set; } = 10000;
    }
}
