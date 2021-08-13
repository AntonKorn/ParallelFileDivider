using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core.Contracts
{
    public interface IStreamFactory
    {
        Stream OpenFileForRead(string fileName, bool allowParallelRead);
        Stream OpenFileForWrite(string fileName, bool allowParallelWrite = false);
    }
}
