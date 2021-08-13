using ParallelFileDivider.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core
{
    public class DefaultClassDivider : IFileDivider
    {
        public Task<FileOperationResult> DivideFile(string sourcePath, string destinationPath, int partsCount, int parallelStreamsCount, int bufferSize)
        {
            throw new NotImplementedException();
        }

        public Task<FileOperationResult> JoinFile(string folderPath, string destinationPath)
        {
            throw new NotImplementedException();
        }
    }
}
