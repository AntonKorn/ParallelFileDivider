using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core.Contracts
{
    public interface IFileAccessor
    {
        Stream OpenFileForRead(string fileName, bool allowParallelRead);
        Stream OpenFileForWrite(string fileName, bool allowParallelWrite = false);
        long GetFileSize(string fileName);
        void EnsureFolderExists(string path);
        bool IsFolderExist(string path);
        bool IsFileExist(string path);
        IEnumerable<string> GetFileNames(string directory,string query);
        bool IsDirectoryEmpty(string directory);
    }
}
