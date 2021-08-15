using ParallelFileDivider.Core.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core
{
    public class DefaultFileAccessor : IFileAccessor
    {
        public void EnsureFolderExists(string path)
        {
            Directory.CreateDirectory(path);
        }

        public long GetFileSize(string fileName)
        {
            return new FileInfo(fileName).Length;
        }

        public bool IsFolderExist(string path)
        {
            return Directory.Exists(path);
        }

        public bool IsFileExist(string path)
        {
            return File.Exists(path);
        }

        public Stream OpenFileForRead(string fileName, bool allowParallelRead)
        {
            return new FileStream(fileName, FileMode.Open, FileAccess.Read, allowParallelRead ? FileShare.Read : FileShare.None);
        }

        public Stream OpenFileForWrite(string fileName, bool allowParallelWrite = false)
        {
            return new FileStream(fileName, FileMode.Create, FileAccess.Write, allowParallelWrite ? FileShare.Write : FileShare.None);
        }

        public IEnumerable<string> GetFileNames(string directory, string query)
        {
            return Directory.GetFiles(directory, query);
        }
    }
}
