using ParallelFileDivider.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core.Contracts
{
    public interface IFileDivider
    {
        Task<FileOperationResult> DivideFile(string sourcePath, string destinationPath, int partsCount, int parallelStreamsCount, int bufferSize);
        Task<FileOperationResult> JoinFile(string folderPath, string destinationPath);
    }
}
