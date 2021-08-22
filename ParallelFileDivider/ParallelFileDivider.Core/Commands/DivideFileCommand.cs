using ParallelFileDivider.Core.Dto;
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
        public long BufferSize { get; set; } = 50000;
        public DivisionProgressObserverDto DivisionProgressObserver { get; set; } = new DivisionProgressObserverDto();
    }
}
