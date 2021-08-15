using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core
{
    public class DivisionOptionsSummary
    {
        public bool IsDirectoryInUse { get; set; }
        public bool IsFileValid { get; set; }
        public long TargetFileSizeInBytes { get; set; }
        public long ApproximatePartSizeInBytes { get; set; }
    }
}
