using ParallelFileDivider.Core.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core
{
    public class DefaultStreamFactory : IStreamFactory
    {
        public Stream OpenFileForRead(string fileName, bool allowParallelRead)
        {
            return new FileStream(fileName, FileMode.Open, FileAccess.Read, allowParallelRead ? FileShare.Read : FileShare.None);
        }

        public Stream OpenFileForWrite(string fileName, bool allowParallelWrite = false)
        {
            return new FileStream(fileName, FileMode.Create, FileAccess.Write, allowParallelWrite ? FileShare.Write : FileShare.None);
        }
    }
}
