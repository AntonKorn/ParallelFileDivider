using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core
{
    public class FileOperationResult
    {
        public bool IsComplete { get; set; } = true;
        public string[] Messages { get; set; }
    }
}
