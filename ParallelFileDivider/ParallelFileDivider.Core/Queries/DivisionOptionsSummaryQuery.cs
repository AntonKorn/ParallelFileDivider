using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core.Queries
{
    public class DivisionOptionsSummaryQuery
    {
        public string DestinationFolder { get; set; }
        public string SourceFile { get; set; }
        public int PartsCount { get; set; }
    }
}
