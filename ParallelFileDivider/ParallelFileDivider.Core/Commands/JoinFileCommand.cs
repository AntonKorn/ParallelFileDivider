using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core.Commands
{
    public class JoinFileCommand
    {
        public string SourceFolderPath { get; set; }
        public string DestinationPath { get; set; }
        public int BufferSize { get; set; }
        public Action<(int Progress, int WorkerNumber)> ProgressChangedCallback { get; set; }
        public int ExpectedProgressPrecision { get; set; } = 10000;
    }
}
