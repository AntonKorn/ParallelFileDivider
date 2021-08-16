using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core
{
    public class JoinOptionsSummary
    {
        public long ApproximateDestinationFileSize { get; set; }
        public int FilesCount { get; set; }
        public bool IsDirectoryValid { get; set; }
        public bool IsFileInUse { get; set; }
    }
}
