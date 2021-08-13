using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core.Commands
{
    public class DivideFileCommand
    {
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public int PartsCount { get; set; }
        public int ParallelStreamsCount { get; set; }
        public int BufferSize { get; set; }
    }
}
